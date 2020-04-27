namespace MXGP.Repositories
{
    using System;
    using System.Linq;

    using Utilities.Messages;
    using Models.Motorcycles.Contracts;

    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public override IMotorcycle GetByName(string name)
        {
            var motorcycle = this.DataBase.FirstOrDefault(x => x.Model == name);
            return motorcycle;
        }
    }
}
