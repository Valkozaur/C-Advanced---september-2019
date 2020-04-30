namespace P07.InfernoInfinity
{
    using Core;
    using DataBase;
    using IOManager;
    using Contracts;
    using Models.Factories;

    
    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();
            IWeaponRepository weaponRepository = new WeaponRepository();

            var inputManager = new InputManager();
            var outputManger = new OutputManager();

            IWeaponFactory weaponFactory = new WeaponFactory();
            IGemFactory gemFactory = new GemFactory();

            engine.Run(inputManager,outputManger, weaponRepository, weaponFactory, gemFactory);
        }
    }
}
