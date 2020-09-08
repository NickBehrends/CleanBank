using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBank.Core.Exceptions
{
    public class DepositLimitException : Exception
    {
        public DepositLimitException(string message) : base(message)
        {
        }
    }
}
