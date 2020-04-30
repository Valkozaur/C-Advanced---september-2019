namespace P07.InfernoInfinity.Models
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using Contracts;
    using Attributes;
    using Enumerations;

    public abstract class Weapon : IWeapon
    {
        private const int BonusMinDamageFromStrength = 2;
        private const int BonusMaxDamageFromStrength = 3;
        private const int BonusMinDamageFromAgility = 1;
        private const int BonusMaxDamageFromAgility = 4;

        private IGem[] gems; 

        protected Weapon(Rarity rarity, string name, int initialMinDamage, int initialMaxDamage, int socketsNumber)
        {
            this.gems = new IGem[socketsNumber];

            this.Rarity = rarity;
            this.Name = name;
            this.MinDamage = initialMinDamage;
            this.MaxDamage = initialMaxDamage;
            this.SocketHoles = socketsNumber;
            this.GetInitialDamage();
        }

        public virtual IReadOnlyCollection<IGem> Sockets => gems;

        public Rarity Rarity { get; }

        public string Name { get; }
        
        [Moddifiable]
        public int MinDamage { get; set; }

        [Moddifiable]
        public int MaxDamage { get; set; }

        public int SocketHoles { get; }

        public int Strength => this.GetStrength();

        public int Agility => this.GetAgility();

        public int Vitality => this.GetVitality();

        public void AddGem(IGem gem, int socketHole)
        {
            if (socketHole < 0 || socketHole > this.gems.Length)
            {
                return;
            }

            if (this.gems[socketHole] != null)
            {
                this.MinDamage -= GetBonusMinDamage(this.gems[socketHole].Agility, this.gems[socketHole].Strength);
                this.MaxDamage -= GetBonusMaxDamage(this.gems[socketHole].Agility, this.gems[socketHole].Strength);
            }

            this.gems[socketHole] = gem;

            this.MinDamage += GetBonusMinDamage(gem.Agility, gem.Strength);
            this.MaxDamage += GetBonusMaxDamage(gem.Agility, gem.Strength);
        }

        public void RemoveGem(int socket)
        {
            if (this.gems[socket] == null || socket < 0 || socket >= this.gems.Length)
            {
                return;
            }

            this.MinDamage -= GetBonusMinDamage(this.gems[socket].Agility, this.gems[socket].Strength);
            this.MaxDamage -= GetBonusMaxDamage(this.gems[socket].Agility, this.gems[socket].Strength);

            this.gems[socket] = null;
        }

        private int GetBonusMinDamage(int gemAgility, int gemStrength)
            => BonusMinDamageFromStrength * gemStrength + BonusMinDamageFromAgility * gemAgility;

        private int GetBonusMaxDamage(int gemAgility, int gemStrength)
            => BonusMaxDamageFromStrength * gemStrength + BonusMaxDamageFromAgility * gemAgility;

        private void GetInitialDamage()
        {
            var fields = this.GetType()
                .GetProperties()
                .Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(ModdifiableAttribute)));

            foreach (var modifiable in fields)
            {
                modifiable.SetValue(this, 
                    (int)this.Rarity * (int)modifiable.GetValue(this));
            }
        }

        private int GetStrength() => this.gems.Where(gem => gem != null).Sum(x => x.Strength);

        private int GetAgility() => this.gems.Where(gem => gem != null).Sum(x => x.Agility);

        private int GetVitality() => this.gems.Where(gem => gem != null).Sum(x => x.Vitality);

        public override string ToString()
        {
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }
    }
}
