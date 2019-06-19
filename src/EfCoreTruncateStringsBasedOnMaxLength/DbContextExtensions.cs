using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfCoreTruncateStringsBasedOnMaxLength
{
    public static class DbContextExtensions
    {
        public static T TruncateStringsBasedOnMaxLength<T>(this DbContext context, T entityObject, ILogger logger = null)
        {
            var clone = entityObject.Clone();

            var entityTypes = context.Model.GetEntityTypes();
            var properties = entityTypes.First(e => e.Name == clone.GetType().FullName).GetProperties().ToDictionary(p => p.Name, p => p.GetMaxLength());

            foreach (var propertyInfo in clone.GetType().GetProperties().Where(p => p.PropertyType == typeof(string)))
            {
                var value = (string)propertyInfo.GetValue(clone);

                if (value == null)
                    continue;

                // If Property Contains 'Phone'. Assume its a phone number and remove all non-digits
                if (propertyInfo.Name.ToLower().Contains("phone"))
                {
                    value = value.SanitizeToDigitsOnly();
                }

                var maxLenght = properties[propertyInfo.Name];

                if (maxLenght.HasValue)
                {
                    propertyInfo.SetValue(clone, value.Truncate(maxLenght.Value, logger));
                }
            }

            return clone;
        }
    }
}