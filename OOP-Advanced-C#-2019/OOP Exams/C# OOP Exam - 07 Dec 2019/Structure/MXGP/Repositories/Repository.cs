namespace MXGP.Repositories
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using MXGP.Utilities.Messages;

    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> repository;
        
        protected Repository()
        {
            this.repository = new HashSet<T>();
        }

        protected ICollection<T> DataBase => this.repository;

        public void Add(T model)
        {
            this.repository.Add(model);
        }

        public IReadOnlyCollection<T> GetAll() => (IReadOnlyCollection<T>)this.repository;

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            if (!this.repository.Contains(model))
            {
                return false;
            }

            this.repository.Remove(model);
            return true;
        }
    }
}
