using System.Collections.Generic;
using P07.InfernoInfinity.Enumerations;

namespace P07.InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        Rarity Rarity { get; }

        IReadOnlyCollection<IGem> Sockets { get; }

        string Name { get; }

        int MinDamage { get; }

        int MaxDamage { get; }

        int SocketHoles { get; }

        int Strength { get; }

        int Agility { get; }

        int Vitality { get; }

        void AddGem(IGem gem, int socketHole);

        void RemoveGem(int socketIndex);
    }  
}       
                