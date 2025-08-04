using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public object? Errors { get; }

        public BadRequestException(string message, object? errors = null)
            : base(message)
        {
            Errors = errors;
        }
    }
}
