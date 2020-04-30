using System;
using System.Linq;
using System.Reflection;
using P07.InfernoInfinity.Attributes;
using P07.InfernoInfinity.Contracts;

namespace P07.InfernoInfinity.Core
{
    public class Engine
    {
        public void Run(
            IInputManager inputManager,
            IOutputManager outputManager,
            IWeaponRepository weaponDataBase,
            IWeaponFactory weaponFactory,
            IGemFactory gemFactory)
        {
            while (true)
            {
                var arguments = inputManager.ReadLine()
                    .Split(";");

                var commandTypeAsString = arguments[0];

                var assembly = Assembly.GetExecutingAssembly();

                var commands = assembly
                    .GetTypes()
                    .Where(x => typeof(IExecutable).IsAssignableFrom(x));

                   var commandType = commands.FirstOrDefault(x => x.Name.Contains(commandTypeAsString));

                   var command = (IExecutable)Activator.CreateInstance(commandType, new object[] { arguments.Skip(1).ToList(), weaponDataBase });

                var fieldsToInject = commandType
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(field => field.GetCustomAttributes(typeof(InjectAttribute)) != null);

                foreach (var field in fieldsToInject)
                {
                    if (field.FieldType == typeof(IWeaponFactory))
                    {
                        field.SetValue(command, weaponFactory);
                    }
                    else if (field.FieldType == typeof(IGemFactory))
                    {
                        field.SetValue(command, gemFactory);
                    }
                    else if (field.FieldType == typeof(IOutputManager))
                    {
                        field.SetValue(command, outputManager);
                    }
                }

                try
                {
                    command.Execute();
                }
                catch (Exception e)
                { 
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
