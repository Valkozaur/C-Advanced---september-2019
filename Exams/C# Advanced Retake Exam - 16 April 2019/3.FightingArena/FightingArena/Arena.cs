using System.Collections.Generic;
using System.Linq;

namespace FightingArena
{
    public class Arena
    {
        private HashSet<Gladiator> gladiators;

        public string Name { get; set; }

        public int Count => gladiators.Count;

        public void AddGladiator(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var gladiatorToRemove = gladiators.FirstOrDefault(x => x.Name == name);
            gladiators.Remove(gladiatorToRemove);
        }

        public Gladiator GetGladiatorWithHighestStatPower() =>
            gladiators.FirstOrDefault(x => x.GetStatPower() == gladiators.Max(m => m.GetStatPower()));

        public Gladiator GetGladiatorWithHighestWeaponPower() =>
            gladiators.FirstOrDefault(x => x.GetWeaponPower() == gladiators.Max(m => m.GetWeaponPower()));

        public Gladiator GetGladiatorWithHighestTotalPower() =>
            gladiators.FirstOrDefault(x => x.GetTotalPower() == gladiators.Max(m => m.GetTotalPower()));

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}