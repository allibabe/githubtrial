using MyShop.core.Models;
using System.Linq;

namespace MyShop.core.Contracts

{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string t);
        T find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}