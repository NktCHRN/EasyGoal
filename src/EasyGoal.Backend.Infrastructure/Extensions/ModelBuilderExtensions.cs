using EasyGoal.Backend.Domain.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var interfaces = entityType.ClrType.GetInterfaces();
            if (interfaces.Any(i => i == typeof(IAuditableEntity)))
            {
                entityType.GetProperty(nameof(IAuditableEntity.CreatedBy))
                    .SetMaxLength(256);
                entityType.GetProperty(nameof(IAuditableEntity.ModifiedBy))
                    .SetMaxLength(256);
            }
        }

        return modelBuilder;
    }

    // TODO: Add SoftDelete Global query filter!!!
}
