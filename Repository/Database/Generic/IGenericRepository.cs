using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Database.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T TModel);
        void Delete(T TModel);
        void Update(T TModel);
        void DeleteRange(IEnumerable<T> TModel);
    }
}
