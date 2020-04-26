namespace _1._Logger.Models
{
    using System;
    using System.Globalization;
     
    using Errors;
    using Factories;
    using Enumerations;

    public class CommandInterpreter
    {
        public void Run()
        {
            var numberOfAppenders = int.Parse(Console.ReadLine());

            var appenderFactory = new AppenderFactory();
            var logger = new Logger.Logger(appenderFactory.CreateAppenders(numberOfAppenders));

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;  
                }

                var logArgs = input.Split("|");

                var errorLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), logArgs[0], true);
                var time = DateTime.ParseExact(logArgs[1], "M/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                var message = logArgs[2];

                logger.CallAppenders(new Error(time, errorLevel, message));
            }

            foreach (var appender in logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
