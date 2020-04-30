namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type typeOfBlackBox = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");

            var ctor = typeOfBlackBox.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null);
            var blackBox = ctor.Invoke(new object[] { });
            MethodInfo[] blackBoxMethods = typeOfBlackBox.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var splitInput = input.Split("_");
                var methodName = splitInput[0];
                var integer = int.Parse(splitInput[1]);

                var methodToCall = blackBoxMethods.FirstOrDefault(m => m.Name == methodName);
                methodToCall?.Invoke(blackBox, new object[] { integer });

                var innerValueField = typeOfBlackBox.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
                var innerValueValue = innerValueField.GetValue(blackBox);

                Console.WriteLine(innerValueValue);
            }
        }
    }
}
