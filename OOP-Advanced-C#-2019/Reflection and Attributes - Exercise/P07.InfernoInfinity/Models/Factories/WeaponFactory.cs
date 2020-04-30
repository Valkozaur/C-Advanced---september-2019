namespace P07.InfernoInfinity.Models.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Enumerations;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(Rarity rarity, string type, string name) 
        {
            var weapon = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(IWeapon).IsAssignableFrom(x))
                .FirstOrDefault(x => x.Name == type);

            return (IWeapon)Activator.CreateInstance(weapon, new object[] { rarity, name });
        }
    }
}
