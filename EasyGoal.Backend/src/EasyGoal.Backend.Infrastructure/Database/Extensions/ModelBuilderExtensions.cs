using EasyGoal.Backend.Domain.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace EasyGoal.Backend.Infrastructure.Database.Extensions;
public static class ModelBuilderExtensions
{
    public static ModelBuilder ApplyGlobalBaseEntityConfiguration(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()
            .Where(e => e.ClrType.IsAssignableTo(typeof(BaseEntity))))
        {
            modelBuilder.Entity(entityType.ClrType).Ignore(nameof(BaseEntity.DomainEvents));
        }

        return modelBuilder;
    }

    public static ModelBuilder ApplyGlobalEnumsConfiguration(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType.IsEnum)
                {
                    var enumType = property.ClrType;
                    ApplyEnumConfigurationOnProperty(property, enumType);
                }
                else if (Nullable.GetUnderlyingType(property.ClrType)?.IsEnum is true)
                {
                    var enumType = Nullable.GetUnderlyingType(property.ClrType)!;
                    ApplyEnumConfigurationOnProperty(property, enumType);
                }
            }
        }

        return modelBuilder;
    }

    private static void ApplyEnumConfigurationOnProperty(IMutableProperty enumProperty, Type enumType)
    {
        var converterType = typeof(EnumToStringConverter<>).MakeGenericType(enumType);
        var converter = Activator.CreateInstance(converterType, new ConverterMappingHints()) as ValueConverter;
        enumProperty.SetValueConverter(converter);
        enumProperty.SetMaxLength(128);
    }

    public static ModelBuilder ApplyGlobalAuditableConfiguration(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()
            .Where(e => e.ClrType.IsAssignableTo(typeof(IAuditableEntity))))
        {
            entityType.GetProperty(nameof(IAuditableEntity.CreatedBy))
                .SetMaxLength(256);
            entityType.GetProperty(nameof(IAuditableEntity.ModifiedBy))
                .SetMaxLength(256);
        }

        return modelBuilder;
    }

    public static ModelBuilder ApplyGlobalQueryFilter<TEntity>(this ModelBuilder modelBuilder, Expression<Func<TEntity, bool>> filterExpr)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()
            .Where(e => e.ClrType.IsAssignableTo(typeof(TEntity)) && e.BaseType is null))
        {
            var parameter = Expression.Parameter(entityType.ClrType);
            var filterBody = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);

            var currentQueryFilter = entityType.GetQueryFilter();
            if (currentQueryFilter is not null)
            {
                filterBody = Expression.AndAlso(
                    ReplacingExpressionVisitor.Replace(currentQueryFilter.Parameters.First(), parameter, currentQueryFilter.Body),
                    filterBody);
            }

            entityType.SetQueryFilter(Expression.Lambda(filterBody, parameter));
        }

        return modelBuilder;
    }
}
