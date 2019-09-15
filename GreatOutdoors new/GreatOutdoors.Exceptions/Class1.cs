using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoors.Exceptions
{
    public class AddressException : ApplicationException
    {
        public AddressException()
            : base()
        {
        }

        public AddressException(string message)
            : base(message)
        {
        }
        public AddressException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
    public class Discount_Exception : ApplicationException
    {
        public Discount_Exception()
            : base()
        {
        }

        public Discount_Exception(string message)
            : base(message)
        {
        }
        public Discount_Exception(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class SpecificationExceptions : ApplicationException
    {
        public SpecificationExceptions()
            : base()
        {
        }

        public SpecificationExceptions(string message)
            : base(message)
        {
        }
        public SpecificationExceptions(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

}
