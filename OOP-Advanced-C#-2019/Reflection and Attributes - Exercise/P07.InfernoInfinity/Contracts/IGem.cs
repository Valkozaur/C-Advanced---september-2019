using P07.InfernoInfinity.Enumerations;

namespace P07.InfernoInfinity.Contracts
{
    public interface IGem
    {
        Clarity Clarity { get; }

        string Type { get; }

        int Strength { get; }

        int Agility { get; }
        
        int Vitality { get; }
    }
}
