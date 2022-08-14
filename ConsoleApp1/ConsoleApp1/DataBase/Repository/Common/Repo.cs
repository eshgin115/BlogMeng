using ConsoleApp1.DataBase.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataBase.Repository.Common
{
    public class Repo<TEntity, TId>
         where TEntity : Entity<TId>
    {
        protected static List<TEntity> DbContext { get; set; } = new List<TEntity>();

        public TEntity Add(TEntity entry)
        {
            DbContext.Add(entry);
            return entry;
        }

        public List<TEntity> GetAll()
        {
            return DbContext;
        }
        public List<TEntity> GetAll(Predicate<TEntity> func)
        {
            List<TEntity> entities = new List<TEntity>();
            foreach (TEntity entity in DbContext)
            {
                if (func(entity))
                {
                    entities.Add(entity);
                }
            }
            return entities;
        }
        public TEntity Get(Predicate<TEntity> func)
        {
            foreach (TEntity entity in DbContext)
            {
                if (func(entity))
                {
                    return entity;
                }
            }
            return null;
        }

        public TEntity GetById(TId id)
        {
            foreach (TEntity entry in DbContext)
            {
                if (Equals(entry.Id, id))
                {
                    return entry;
                }
            }

            return default(TEntity);
        }

        public void Delete(TEntity entry)
        {
            DbContext.Remove(entry);
        }

    }
}
