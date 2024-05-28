using EasyGoal.Backend.Domain.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyGoal.Backend.Infrastructure.Extensions;
public static class ModelBuilderExtensions
{
    public static ModelBuilder ApplyGlobalEnumsConfiguration(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType.IsEnum)
                {
                    var type = typeof(EnumToStringConverter<>).MakeGenericType(property.ClrType);
                    var converter = Activator.CreateInstance(type, new ConverterMappingHints()) as ValueConverter;

                    property.SetValueConverter(converter);
                }
                else if (Nullable.GetUnderlyingType(property.ClrType)?.IsEnum is true)
                {
                    var type = typeof(EnumToStringConverter<>).MakeGenericType(Nullable.GetUnderlyingType(property.ClrType)!);
                    var converter = Activator.CreateInstance(type, new ConverterMappingHints()) as ValueConverter;

                    property.SetValueConverter(converter);
                }
            }
        }

        return modelBuilder;
    }

    public static ModelBuilder ApplyGlobalAuditableConfiguration(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var interfaces = entityType.ClrType.GetInterfaces();
            if (interfaces.Any(i => i == typeof(IAuditableEntity)))
            {
                entityType.GetProperty(nameof(IAuditableEntity.CreatedBy))
                    .SetMaxLength(255);
                entityType.GetProperty(nameof(IAuditableEntity.ModifiedBy))
                    .SetMaxLength(255);
            }
        }

        return modelBuilder;
    }
}
