using MyShop.core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public interface ISQLRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        Task Commit();
        void Delete(string Id);
        Task<T> find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}