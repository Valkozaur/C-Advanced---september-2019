using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class Repository
    {
        public Repository()
        {
            this.entities = new Dictionary<int, Person>();
        }

        private Dictionary<int, Person> entities;
        private int id = 0;

        public Dictionary<int, Person> Entities
        {
            get { return this.entities; }
            set { this.entities = value; }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int Count => this.entities.Count;

        public void Add(Person person)
        {
            Entities.Add(id++, person);
        }

        public Person Get(int id)
        {
            return this.Entities[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (this.Entities.ContainsKey(id))
            {
                this.Entities[id] = newPerson;
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (this.Entities.ContainsKey(id))
            {
                this.Entities.Remove(id);
                return true;
            }

            return false;
        }
    }
}
