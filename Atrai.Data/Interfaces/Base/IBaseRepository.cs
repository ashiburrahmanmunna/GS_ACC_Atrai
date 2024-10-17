using Atrai.Model.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Atrai.Data.Interfaces.Base
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        IQueryable<T> All(bool isComId = true, bool isNoTracking = false);//int Comid
        IQueryable<T> AllData(bool isComId = true);//int Comid

        //IEnumerable<T> TakeLast(IEnumerable<T> coll, int N , bool isComId = true);

        IQueryable<T> AllByBaseCompany(bool isComId = true);//int Comid

        IQueryable<T> AllSubData();//int Comid

        IQueryable<T> All(params Expression<Func<T, Object>>[] includeProperties);
        T Find(long id);
        T Find(Int64 id, params Expression<Func<T, object>>[] includeProperties);
        void Insert(T entity);
        void Insert(List<T> entity);
        int InsertInt(T entity);
        void Update(T entity, int id);
        //void UpdateState(T entity, int id);
        void Delete(T entity);
        void DeleteState(T entity);
        void Isdeletetrue(T model);

        void RemoveRange(List<T> entity);

        void AddRange(List<T> entity);
        void AddRange(ICollection<T> entity);

        //void IdentityOn();

        //void IdentityOff();

        //void AddRangeWithoutAccountHeadIdentity(List<T> entity);


        void InsertApi(T entity);
        void UpdateApi(T entity, int id);


        int InsertEcommerce(T entity);


    }

    //public interface IRecursiveRepository<T> where T : RecursiveModel<T>
    //{
    //    IQueryable<T> All(bool isComId = true);//int Comid
    //    IQueryable<T> AllByBaseCompany(bool isComId = true);//int Comid

    //    IQueryable<T> AllSubData();//int Comid

    //    IQueryable<T> All(params Expression<Func<T, Object>>[] includeProperties);
    //    T Find(long id);
    //    T Find(Int64 id, params Expression<Func<T, object>>[] includeProperties);
    //    void Insert(T entity);
    //    int InsertInt(T entity);
    //    void Update(T entity, int id);
    //    void Delete(T entity);

    //    void RemoveRange(List<T> entity);

    //    void AddRange(List<T> entity);
    //    void AddRange(ICollection<T> entity);


    //    void InsertApi(T entity);
    //    void UpdateApi(T entity, int id);


    //    int InsertEcommerce(T entity);

    //    IEnumerable<T> GetRecursive(Expression<Func<T, bool>> expression);

    //}
}
