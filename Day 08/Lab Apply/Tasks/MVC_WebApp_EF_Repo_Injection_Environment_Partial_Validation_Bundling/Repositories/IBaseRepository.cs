using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Contexts;
using System.Linq.Expressions;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Repositories
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll(params Expression<Func<T, object>>[] includes);
        T GetById(int id, params Expression<Func<T, object>>[] includes);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
