namespace MXGP.Repositories
{
    using System;
    using System.Linq;

    using Utilities.Messages;
    using Models.Riders.Contracts;

    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            var rider = this.DataBase.FirstOrDefault(x => x.Name == name);
            return rider;
        }
    }
}

