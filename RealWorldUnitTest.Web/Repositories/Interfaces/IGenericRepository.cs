using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealWorldUnitTest.Web.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
