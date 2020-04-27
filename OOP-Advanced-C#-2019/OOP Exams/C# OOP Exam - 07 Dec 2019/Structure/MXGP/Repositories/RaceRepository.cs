namespace MXGP.Repositories
{
    using System;
    using System.Linq;

    using Utilities.Messages;
    using Models.Races.Contracts;

    class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            var race = this.DataBase.FirstOrDefault(x => x.Name == name);
            return race;
        }
    }
}
