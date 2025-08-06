using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GameStore.Domain.Constraints
{
    public static class GameValidationConstraints
    {
        public static class Limits
        {
            public const int Name = 100;
            public const int Description = 500;
            public const int Key = 50;
            public const double MinPrice = 0;
            public const int MinStock = 0;
            public const int MinDiscount = 0;
            public const int MaxDiscount = 100;
        }

        public static class Patterns
        {
            public const string Key = "^[a-z0-9-]+$";
        }

        public static class Messages
        {
            public const string Required = "{PropertyName} is required.";
            public static readonly string NameLength = $"Name cannot exceed {Limits.Name} characters.";
            public static readonly string KeyLength = $"Key cannot exceed {Limits.Key} characters.";
            public static readonly string KeyFormat = "Key must be lowercase alphanumeric with hyphens.";
            public static readonly string DescriptionLength = $"Description cannot exceed {Limits.Description} characters.";
            public static readonly string PriceMin = $"Price cannot be less than {Limits.MinPrice}.";
            public static readonly string StockMin = $"Stock cannot be less than {Limits.MinStock}.";
            public static readonly string DiscountRange = $"Discount must be between {Limits.MinDiscount}-{Limits.MaxDiscount}%.";

            public const string GenresRequired = "At least one genre is required.";
            public const string PlatformsRequired = "At least one platform is required.";
            public const string IdNotEmpty = "{0} ID cannot be empty.";
        }
    }
}