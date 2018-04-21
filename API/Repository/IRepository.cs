using System;
using System.Linq;

namespace API.Repository {
    public interface IRepository<T> where T : class {
        T Get (Func<T, bool> predicate);
        IQueryable<T> GetAll ();
    }
}