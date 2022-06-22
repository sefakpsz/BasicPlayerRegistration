using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballerForm.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Remove(T entity);
        void Add(T entity);
        IEnumerable<T> GetAll();
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
    }
}
