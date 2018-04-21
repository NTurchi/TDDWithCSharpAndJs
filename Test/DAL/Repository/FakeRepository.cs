using System;
using System.Collections.Generic;
using System.Linq;
using API.Repository;

namespace Test.DAL.Repository {
    public class FakeRepository<T> : IRepository<T> where T : class {
        public IList<T> DataSet { get; set; } = new List<T> ();
        public T Get (Func<T, bool> predicate) {
            return GetAll ().Where (predicate).FirstOrDefault ();
        }

        public IQueryable<T> GetAll () {
            return DataSet.AsQueryable ();
        }
    }
}