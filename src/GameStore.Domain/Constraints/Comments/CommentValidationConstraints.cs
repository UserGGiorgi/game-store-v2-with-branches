using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Constraints.Comments
{
    public static class CommentValidationConstraints
    {
        public static class Limits
        {
            public const int Body = 500;
        }

        public static class Patterns
        {
        }

        public static class Messages
        {
            public const string CommentRequired = "Comment is required.";
            public const string BodyRequired = "Body is required.";
            public static readonly string BodyLength = $"Body must not exceed {Limits.Body} characters.";
            public const string ParentIdFormat = "ParentId must be a valid GUID if provided.";
        }
    }
}
