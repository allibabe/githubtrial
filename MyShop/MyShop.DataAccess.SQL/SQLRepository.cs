using MyShop.core.Contracts;
using MyShop.core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity

    {

        internal DataContext context;
        internal DbSet<T> dbSet;




        public SQLRepository(DataContext context)

        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }



        public IQueryable<T> Collection()
        {

            return dbSet;
        }


        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string Id)
        {
            var t = find(Id);

            if (context.Entry(t).State == EntityState.Detached) {
                dbSet.Attach(t);
            }

            dbSet.Remove(t);
            Commit();

        }

        public T find(string Id)
        {
            return dbSet.Find(Id);

        }

        public void  Insert(T t)
        {
            dbSet.Add(t);
            Commit();

        }

        public void Update(T item)
        {

            var t = find(item.Id);


            if (context.Entry(t).State == EntityState.Detached)
            {
                dbSet.Attach(t);
            }

            dbSet.Remove(t);

            dbSet.Add(item);

            Commit();

        }
    }
}
