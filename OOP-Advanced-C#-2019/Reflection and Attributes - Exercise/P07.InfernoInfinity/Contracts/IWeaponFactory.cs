namespace P07.InfernoInfinity.Contracts
{
    using Enumerations;

    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(Rarity rarity, string type, string name);
    }
}
