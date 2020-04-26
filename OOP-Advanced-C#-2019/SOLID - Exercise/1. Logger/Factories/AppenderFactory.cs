namespace _1._Logger.Factories
{
    using System;
    using System.Collections.Generic;

    using Models.Appenders;
    using Models.Enumerations;
    using Models.Logger.Contracts;
    using Models.Layouts.Contracts;
    using Models.Appenders.Contracts;

    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }
        
        public ICollection<IAppender> CreateAppenders(int numberOfAppenders)
        {
            List<IAppender> appenders = new List<IAppender>();
            
            for (int i = 0; i < numberOfAppenders; i++)
            {
                var errorInput = Console.ReadLine().Split();

                var appenderType = errorInput[0];
                var layoutType = errorInput[1];
                ILayout layout;
                try
                {
                    layout = layoutFactory.GetLayout(layoutType);
                }
                catch (Exception) 
                { 
                
                    throw new ArgumentException("Invalid layout type");
                }

                if (errorInput.Length == 2)
                {
                    if (appenderType == nameof(ConsoleAppender))
                    {
                        appenders.Add(new ConsoleAppender(layout));
                    }
                    else if(appenderType == nameof(FileAppender))
                    {
                        appenders.Add(new FileAppender(layout, new LogFile()));
                    }
                }
                else
                {
                    var reportLevel = errorInput[2];

                    if (appenderType == nameof(ConsoleAppender))
                    {
                        appenders.Add(new ConsoleAppender(layout, (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel, true)));
                    }
                    else if (appenderType == nameof(FileAppender))
                    {
                        appenders
                            .Add(new FileAppender(layout,
                            new LogFile(),
                            (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel)));
                    }
                }
            }

            return appenders;
        }
    }
}
