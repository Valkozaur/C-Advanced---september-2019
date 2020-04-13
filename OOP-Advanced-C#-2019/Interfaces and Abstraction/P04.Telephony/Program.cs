using System;
using System.Linq;

namespace P04.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var phone = new Smartphone();

            var phoneNumbers = Console.ReadLine()
                .Split();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(phone.MakeACall(number));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var websites = Console.ReadLine()
                .Split();

            foreach (var website in websites)
            {
                try
                {
                    Console.WriteLine(phone.InternetBrowse(website));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
