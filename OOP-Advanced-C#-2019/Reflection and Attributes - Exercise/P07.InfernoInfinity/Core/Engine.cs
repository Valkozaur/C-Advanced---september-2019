using System;
using System.Linq;
using System.Reflection;
using P07.InfernoInfinity.Attributes;
using P07.InfernoInfinity.Contracts;

namespace P07.InfernoInfinity.Core
{
    public class Engine
    {
        private IInputManager inputManager;
        private IOutputManager outputManager;
        private IWeaponRepository weaponDataBase;
        private IWeaponFactory weaponFactory;
        private IGemFactory gemFactory;

        public Engine(
            IInputManager inputManager,
            IOutputManager outputManager,
            IWeaponRepository weaponDataBase,
            IWeaponFactory weaponFactory,
            IGemFactory gemFactory)
        {
            this.inputManager = inputManager;
            this.outputManager = outputManager;
            this.weaponDataBase = weaponDataBase;
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
        }

        public void Run(
            )
        {
            while (true)
            {
                var arguments = this.inputManager.ReadLine()
                    .Split(";");

                var commandTypeAsString = arguments[0];

                var assembly = Assembly.GetExecutingAssembly();

                var commands = assembly
                    .GetTypes()
                    .Where(x => typeof(IExecutable).IsAssignableFrom(x));

                var commandType = commands.FirstOrDefault(x => x.Name.Contains(commandTypeAsString));

                var command = (IExecutable)Activator.CreateInstance(commandType, new object[] { arguments.Skip(1).ToList(), this.weaponDataBase });

                InjectDependencies(commandType, command);

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

        private void InjectDependencies(Type commandType, IExecutable command)
        {
            var fieldsToInject = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(field => field.CustomAttributes.Any(a => a.AttributeType == typeof(InjectAttribute)));

            foreach (var field in fieldsToInject)
            {
                if (field.FieldType == typeof(IWeaponFactory))
                {
                    field.SetValue(command, this.weaponFactory);
                }
                else if (field.FieldType == typeof(IGemFactory))
                {
                    field.SetValue(command, this.gemFactory);
                }
                else if (field.FieldType == typeof(IOutputManager))
                {
                    field.SetValue(command, this.outputManager);
                }
            }
        }
    }
}
