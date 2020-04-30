using Microsoft.Extensions.DependencyInjection;
using P03_BarraksWars.Core.Commands;
using SimpleInjector;

namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using P03_BarraksWars.Core;

    public class AppEntryPoint
    {
        public static void Main()
        {
            var container = new Container();
            container.Register<IUnitFactory, UnitFactory>();
            container.Register<IRepository, UnitRepository>();
            container.Register<ICommandInterpreter, CommandInterpreter>();

            container.Verify();

            var commandInterpreter = container.GetInstance<ICommandInterpreter>();

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
