using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Constraints.Games
{
    public static class PublisherValidationConstraints
    {
        public static class Limits
        {
            public const int CompanyName = 100;
            public const int HomePage = 200;
            public const int Description = 500;
        }
        public static class Messages
        {
            public const string PublisherRequired = "Publisher information is required.";
            public const string PublisherIdRequired = "Publisher ID is required.";
            public const string CompanyNameRequired = "Company name is required.";
            public static readonly string CompanyNameLength = $"Company name cannot exceed {Limits.CompanyName} characters.";
            public static readonly string HomePageLength = $"Home page URL cannot exceed {Limits.HomePage} characters.";
            public const string HomePageFormat = "Home page must be a valid URL (http:// or https://).";
            public static readonly string DescriptionLength = $"Description cannot exceed {Limits.Description} characters.";
        }
    }
}
