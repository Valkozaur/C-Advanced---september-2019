namespace RobotService.Core
{
    using Contracts;
    using RobotService.Models.Garages;

    public class Controller : IController
    {
        private Garage garage;

        public Controller()
        {
            this.garage = new Garage();
        }

        public string Charge(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Chip(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string History(string procedureType)
        {
            throw new System.NotImplementedException();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {

        }

        public string Polish(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Rest(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Sell(string robotName, string ownerName)
        {
            throw new System.NotImplementedException();
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        public string Work(string robotName, int procedureTime)
        {
            throw new System.NotImplementedException();
        }

        private 
    }
}
