namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            IUnit currentUnit;

            var assembly = Assembly.GetExecutingAssembly();

            var type = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == unitType);

            currentUnit = (IUnit)Activator.CreateInstance(type);

            currentUnit = (IUnit)Activator.CreateInstance(type);

            return currentUnit;
        }
    }
}
