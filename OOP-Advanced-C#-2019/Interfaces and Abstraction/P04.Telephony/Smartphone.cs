using System;
using System.Linq;

namespace P04.Telephony
{
    class Smartphone : ICallable, IInternetBrowsable
    {
        public string MakeACall(string number)
        {
            if (number.Any(x => !char.IsDigit(x)))
            {
                throw new Exception("Invalid number!");
            }

            if (number.Length == 10)
            {
                return $"Calling... {number}";
            }
            else
            {
                return $"Dialing... {number}";
            }
        }

        public string InternetBrowse(string website)
        {
            if (website.Any(x => char.IsDigit(x)))
            {
                throw new Exception("Invalid URL!");
            }

            return $"Browsing: {website}!";
        }
    }
}
