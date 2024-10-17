using Atrai.Model.Core.Entity.Self;
using Atrai.Data.Interfaces.Self;
using Atrai.Data.Context.AppDataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Atrai.Data.Repository.Self
{
    public class SelfRepository<T> : ISelfRepository<T> where T : SelfModel
    {
        private readonly InvoiceDbContext _context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        private readonly IHttpContextAccessor httpcontext;

        public SelfRepository(InvoiceDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
            httpcontext = new HttpContextAccessor();
        }



        //public IQueryable<T> All(bool isComId = true)//int Comid
        //{
        //        return entities.Where(x => !x.IsDelete);//
        //}


        //public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> coll, int N, bool isComId = true)
        //{
        //    return coll.Reverse().Take(N).Reverse();
        //}


        public IQueryable<T> AllByBaseCompany(bool isComId = true)//int Comid
        {

            return entities.Where(x => !x.IsDelete);
        }




        public IQueryable<T> All(bool isComId = true)
        {
            //var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

            //if (isComId == true)
            //{
            //    return entities.Where(x => !x.IsDelete);
            //}

            return entities.Where(x => !x.IsDelete);



        }

        //public IQueryable<T> AllByBaseCompany()
        //{
        //    return entities.Where(x => !x.IsDelete);
        //}

        public IQueryable<T> All(params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(List<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.RemoveRange(entity);
            _context.SaveChanges();
        }

        public T Find(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public T Find(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public int Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            //entity.CreateDate = DateTime.Now;

            if (entity.IsDelete == false)
            {
                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                entities.Add(entity);
                _context.SaveChanges();
                return entity.Id;
            }
            return 0;
        }

        public void Update(T entity, int id)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            //entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            T exist = _context.Set<T>().Find(id);
            if (exist != null)
            {

                _context.Entry(exist).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            _context.SaveChanges();
        }




        public void AddRange(List<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

            foreach (var item in entity)
            {
                item.CreateDate = DateTime.Now;
                item.UpdateDate = DateTime.Now;
            }

            entities.AddRange(entity);
            _context.SaveChanges();
        }

        public void AddRange(ICollection<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

            foreach (var item in entity)
            {
                item.CreateDate = DateTime.Now;
                item.UpdateDate = DateTime.Now;
            }

            entities.AddRange(entity);
            _context.SaveChanges();
        }


        public IQueryable<T> GetUserData()//int Comid
        {
            ////var comid = httpcontext.HttpContext.Session.GetString("comid");
            //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            //var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");


            return entities.Where(x => !x.IsDelete);//
        }

        public IQueryable<T> GetCompanyData()//int Comid
        {
            ////var comid = httpcontext.HttpContext.Session.GetString("comid");
            //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            //var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");


            return entities.Where(x => !x.IsDelete);//
        }
    }
}
