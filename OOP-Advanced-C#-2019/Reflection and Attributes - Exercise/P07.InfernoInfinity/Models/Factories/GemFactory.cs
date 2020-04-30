namespace P07.InfernoInfinity.Models.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Enumerations;

    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(Clarity clarity, string type)
        {
            var gem = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(IGem).IsAssignableFrom(x))
                .FirstOrDefault(x => x.Name == type);

            return (IGem)Activator.CreateInstance(gem, new object[] { clarity, type });
        }
    }
}
