namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Trainer
    {
        private int badges;

        public Trainer(string name, int badges, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.Badges = badges;
            this.Pokemons = pokemons;
        }

        public string Name { get; set; }

        public int Badges
        {
            get { return this.badges; }
            set { this.badges = value; }
        }

        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}"; 
        }
    }
}
