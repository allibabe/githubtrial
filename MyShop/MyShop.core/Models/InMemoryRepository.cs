using MyShop.core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.core.Models
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {

        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string ClassName;

        public InMemoryRepository()
        {
            this.ClassName = typeof(T).Name;
            items = cache[ClassName] as List<T>;

            if (items == null)
            {
                items = new List<T>();
            }

        }



        public void Commit()
        {
            cache[ClassName] = items;

        }

        public void Insert(T t)
        {

            items.Add(t);
            Commit();
        }

        public void Update(T t)
        {
            T itemToUpdate = items.Find(x => x.Id == t.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate = t;

                items.RemoveAll(x => x.Id == itemToUpdate.Id);
                items.Add(t);

                Commit();
            }
            else
            {
                throw new Exception(ClassName + "Not Found");

            }


        }

        public T find(string Id)
        {
            T item = items.Find(x => x.Id == Id);

            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("Not Found");

            }


        }

        public void Delete(String t)
        {
            T item = items.Find(x => x.Id == t);

            if (item != null)
            {
                items.Remove(item);
            }
            else
            {
                throw new Exception("Not Found");

            }


        }

        public IQueryable<T> Collection()
        {

            return items.AsQueryable();
        }

    }
}
