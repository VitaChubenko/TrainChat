using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TrainChat.Model;

namespace TrainChat.Repositories.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T :  Entity
    {
        protected readonly ChatContext db;// = new ChatContext();
         internal DbSet<T> dbSett;

        protected BaseRepository(ChatContext dbContext)
        {
            this.db = dbContext;
            this.dbSett = dbContext.Set<T>();
        }

       

        public  IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSett;
            return query.ToList();
        }

        public T Get(int id)
        {
            return dbSett.Find(id);
        }

        public void Create(T item)
        {
           dbSett.Add(item);
        //    db.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            dbSett.Attach(item);
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entityToDelete = dbSett.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSett.Attach(entityToDelete);
            }
            dbSett.Remove(entityToDelete);
        }
       
    }
}
