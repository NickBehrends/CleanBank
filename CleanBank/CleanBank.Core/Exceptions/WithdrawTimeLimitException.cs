using System;
using System.Collections.Generic;
using System.Text;

namespace CleanBank.Core.Exceptions
{
    public class WithdrawTimeLimitException : Exception
    {
        public WithdrawTimeLimitException(string message) : base(message)
        {
        }
    }
}
