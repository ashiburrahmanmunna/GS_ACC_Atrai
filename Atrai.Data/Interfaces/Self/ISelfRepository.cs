using Atrai.Model.Core.Entity.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Atrai.Data.Interfaces.Self
{
    public interface ISelfRepository<T> where T : SelfModel
    {
        IQueryable<T> All(bool isComId = true);//int Comid

        //IEnumerable<T> TakeLast(IEnumerable<T> coll, int N , bool isComId = true);

        IQueryable<T> AllByBaseCompany(bool isComId = true);//int Comid


        //IQueryable<T> All();
        IQueryable<T> All(params Expression<Func<T, Object>>[] includeProperties);
        T Find(long id);
        T Find(Int64 id, params Expression<Func<T, object>>[] includeProperties);
        //int Insert(T entity);
        int Insert(T model);
        void Update(T entity, int id);
        void Delete(T entity);


        void RemoveRange(List<T> entity);
        void AddRange(List<T> entity);
        void AddRange(ICollection<T> entity);
    }
}
