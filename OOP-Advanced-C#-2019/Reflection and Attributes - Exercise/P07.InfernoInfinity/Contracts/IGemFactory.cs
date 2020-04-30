namespace P07.InfernoInfinity.Contracts
{
    using Enumerations;

    public interface IGemFactory
    {
        IGem CreateGem(Clarity clarity, string type);
    }
}
