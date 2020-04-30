using _03BarracksFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace P03_BarraksWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        IRepository repository;
        IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {

            var assembly = Assembly.GetExecutingAssembly();

            var commandType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower().StartsWith(commandName));

            var command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data });

            var fields = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.GetCustomAttribute(typeof(InjectAttribute)) != null)
                .ToList();


            foreach (var field in fields)
            {
                if (field.FieldType == typeof(IRepository))
                {
                    field.SetValue(command, this.repository);
                }
                else if (field.FieldType == typeof(IUnitFactory))
                {
                    field.SetValue(command, this.unitFactory);
                }
            }

            return command;
        }
    }
}
