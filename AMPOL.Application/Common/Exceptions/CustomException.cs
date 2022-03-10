using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
namespace AMPOL.Application.Common.Exceptions
{
    public class CustomException: Exception 
    {
        public CustomException()
        : base()
        {
        }

        public CustomException(string message)
            : base(message)
        {
        }

        public CustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
