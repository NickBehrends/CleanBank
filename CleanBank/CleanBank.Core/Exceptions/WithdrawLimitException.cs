using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBank.Core.Exceptions
{
    public class WithdrawLimitException : Exception
    {
        public WithdrawLimitException(string message) : base(message)
        {
        }
    }
}
