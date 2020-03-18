using System.Collections.Generic;
using System.Linq;

namespace FightingArena
{
    public class Arena
    {
        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new HashSet<Gladiator>();
        }

        private HashSet<Gladiator> gladiators;

        public string Name { get; set; }

        public int Count => this.gladiators.Count;

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var gladiatorToRemove = gladiators.FirstOrDefault(x => x.Name == name);
            gladiators.Remove(gladiatorToRemove);
        }

        public Gladiator GetGladitorWithHighestStatPower() =>
            gladiators.FirstOrDefault(x => x.GetStatPower() == gladiators.Max(m => m.GetStatPower()));

        public Gladiator GetGladitorWithHighestWeaponPower() =>
            gladiators.FirstOrDefault(x => x.GetWeaponPower() == gladiators.Max(m => m.GetWeaponPower()));

        public Gladiator GetGladitorWithHighestTotalPower() =>
            gladiators.FirstOrDefault(x => x.GetTotalPower() == gladiators.Max(m => m.GetTotalPower()));

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}