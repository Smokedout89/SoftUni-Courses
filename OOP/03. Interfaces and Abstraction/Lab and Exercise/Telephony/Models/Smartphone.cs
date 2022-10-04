using System;
using System.Linq;
using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            if (number.Any(c => char.IsLetter(c)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberException);
            }

            return number.Length == 7
                ? $"Dialing... {number}"
                : $"Calling... {number}";
        }

        public string Browse(string site)
        {
            if (site.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidUrlException);
            }

            return $"Browsing: {site}!";
        }
    }
}