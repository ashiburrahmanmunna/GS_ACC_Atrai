using Atrai.Model.Core.Entity.Base;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Context.AppDataContext;
using DocumentFormat.OpenXml.Office2010.Excel;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Atrai.Data.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly InvoiceDbContext _context;
        //protected readonly InvoiceDbContext _context;

        private DbSet<T> entities;
        string errorMessage = string.Empty;
        private readonly IHttpContextAccessor httpcontext;
        public BaseRepository(InvoiceDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
            httpcontext = new HttpContextAccessor();
        }
        //public BaseRepository()
        //{

        //}

        //public IQueryable<T> All(bool isComId = true)//int Comid
        //{
        //    //var comid = httpcontext.HttpContext.Session.GetString("comid");
        //    //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
        //    var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");
        //    if (ComId == null)
        //    {
        //        ComId = httpcontext.HttpContext.Session.GetInt32("CurrentComId");

        //    }

        //    if (isComId == false)
        //        return entities.Where(x => !x.IsDelete);//


        //    return entities.Where(x => !x.IsDelete && x.ComId == ComId);//
        //}

        public IQueryable<T> All(bool isComId = true, bool isNoTracking = false)
        {
            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");
            if (ComId == null)
            {
                ComId = httpcontext.HttpContext.Session.GetInt32("CurrentComId");
            }

            IQueryable<T> query = entities;

            if (isNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (!isComId)
            {
                return query.Where(x => !x.IsDelete);
            }

            return query.Where(x => !x.IsDelete && x.ComId == ComId);
        }
        public IQueryable<T> AllData(bool isComId = true)
        {
            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

            if (ComId == null)
            {
                ComId = httpcontext.HttpContext.Session.GetInt32("CurrentComId");
            }

            if (isComId == false)
            {
                return entities;
            }

            return entities.Where(x => x.ComId == ComId);
        }



        //public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> coll, int N, bool isComId = true)
        //{
        //    return coll.Reverse().Take(N).Reverse();
        //}


        public IQueryable<T> AllByBaseCompany(bool isComId = true)//int Comid
        {
            //var comid = httpcontext.HttpContext.Session.GetString("comid");
            //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            //var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");
            var BaseComId = httpcontext.HttpContext.Session.GetInt32("BaseComId");
            if (isComId == false)
                return entities.Where(x => !x.IsDelete);//


            return entities.Where(x => !x.IsDelete && x.ComId == BaseComId);//
        }

        public IQueryable<T> AllSubData()//int Comid
        {
            //var comid = httpcontext.HttpContext.Session.GetString("comid");
            //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");


            return entities.Where(x => !x.IsDelete);//
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

        public IQueryable<T> All(params Expression<Func<T, object>>[] includeProperties)
        {
            //throw new NotImplementedException();

            return includeProperties == null
                ? All()
              : includeProperties.Aggregate(All(), (current, includeProperty) => current.Include(includeProperty));
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteState(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");
            entities.Remove(entity);
        }
        public void Isdeletetrue(T model)
        {

            model.IsDelete = true;
            _context.Update(model);
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
                item.LuserId = UserId.GetValueOrDefault();
                item.ComId = ComId.GetValueOrDefault();
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
                item.LuserId = UserId.GetValueOrDefault();
                item.ComId = ComId.GetValueOrDefault();
                item.CreateDate = DateTime.Now;
                item.UpdateDate = DateTime.Now;
            }

            entities.AddRange(entity);
            _context.SaveChanges();
        }

        public T Find(long id)
        {
            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

            //return entities.SingleOrDefault(s => s.Id == id && s.ComId == ComId);
            return entities.AsNoTracking().SingleOrDefault(s => s.Id == id && s.ComId == ComId); //test
        }

        public T Find(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            return All(includeProperties).FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity.IsDelete == false)
            {
                var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
                var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                entity.ComId = int.Parse(ComId.ToString());
                entity.LuserId = int.Parse(UserId.ToString());

                entities.Add(entity);
                _context.SaveChanges();
            }

        }

        public void Insert(List<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

            entities.AddRange(entity);
            _context.SaveChanges();


        }

        public void InsertApi(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity.IsDelete == false)
            {
                var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
                var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                entity.ComId = int.Parse(ComId.ToString());
                entity.LuserId = int.Parse(UserId.ToString());



                entities.Add(entity);
                _context.SaveChanges();
            }

        }

        public int InsertEcommerce(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity.IsDelete == false)
            {
                //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
                //var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                //entity.ComId = int.Parse(ComId.ToString());
                //entity.LuserId = int.Parse(UserId.ToString());



                entities.Add(entity);
                _context.SaveChanges();

                return entity.Id;
            }
            return 0;

        }


        //public void IdentityOn()
        //{

        //    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AccountHead] ON");
        //    _context.SaveChanges();

        //}
        //public void IdentityOff()
        //{

        //    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AccountHead] OFF");
        //    _context.SaveChanges();

        //}


        //public void AddRangeWithoutAccountHeadIdentity(List<T> entity)
        //{
        //    try
        //    {
        //        if (entity == null)
        //        {
        //            throw new ArgumentNullException("entity");
        //        }

        //        //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AccountHead] ON");
        //        //_context.SaveChanges();

        //        entities.AddRange(entity);
        //        _context.SaveChanges();


        //        //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[AccountHead] OFF");
        //        //_context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}



        //public void AddRangeWithoutAccountHeadIdentity(List<T> entity)
        //{
        //    try
        //    {
        //        using (var dataContext = new InvoiceDbContext())
        //        using (var transaction = dataContext.Database.BeginTransaction())
        //        {


        //            dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[AccountHead] ON");

        //            if (entity == null)
        //            {
        //                throw new ArgumentNullException("entity");
        //            }
        //            entities.AddRange(entity);
        //            _context.SaveChanges();


        //            dataContext.User.Add(user);
        //            dataContext.SaveChanges();

        //            dataContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[AccountHead] OFF");

        //            transaction.Commit();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        public int InsertInt(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity.IsDelete == false)
            {
                var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
                var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                entity.ComId = int.Parse(ComId.ToString());
                entity.LuserId = int.Parse(UserId.ToString());
                entities.Add(entity);
                _context.SaveChanges();

                return entity.Id;
            }
            return 0;
        }

        public void Update(T entity, int id)
        {
            try
            {


                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }



                //entity.CreateDate = entity.CreateDate;
                ///entity.CreateDate = DateTime.Now;

                //entity.UpdateDate = DateTime.Now;
                //entity.CreateDate = entity.CreateDate;
                var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
                var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");


                if (id > 0)
                {


                    entity.UpdateDate = DateTime.Now;
                    //entity.CreateDate = entity.CreateDate;

                    if (ComId > 0)
                    {
                        entity.ComId = int.Parse(ComId.ToString());
                    }
                    if (UserId > 0)
                    {
                        entity.LuserIdUpdate = int.Parse(UserId.ToString());
                        if (entity.LuserId == null || entity.LuserId == 0)
                        {
                            entity.LuserId = int.Parse(UserId.ToString());
                        }
                    }
                    //entity.LuserId = int.Parse(UserId.ToString());
                }
                else
                {

                    entity.ComId = int.Parse(ComId.ToString());
                    entity.LuserIdUpdate = int.Parse(UserId.ToString());
                    entity.UpdateDate = DateTime.Now;

                    //entity.CreateDate = entity.CreateDate;
                }



                T exist = _context.Set<T>().Find(id);
                if (exist != null)
                {
                    _context.Entry(exist).CurrentValues.SetValues(entity);
                    _context.SaveChanges();


                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateApi(T entity, int id)
        {
            try
            {


                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
                var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

                //entity.CreateDate = entity.CreateDate;
                ///entity.CreateDate = DateTime.Now;

                //entity.CreateDate = entity.CreateDate;
                entity.UpdateDate = DateTime.Now;
                entity.ComId = int.Parse(ComId.ToString());
                entity.LuserId = int.Parse(UserId.ToString());


                T exist = _context.Set<T>().Find(id);
                if (exist != null)
                {
                    _context.Entry(exist).CurrentValues.SetValues(entity);
                    _context.SaveChanges();


                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }





    }





    //public class RecursiveRepository<T> : IRecursiveRepository<T> where T : RecursiveModel<T>
    //{
    //    protected readonly InvoiceDbContext _context;
    //    private DbSet<T> entities;
    //    string errorMessage = string.Empty;
    //    private readonly IHttpContextAccessor httpcontext;
    //    public RecursiveRepository(InvoiceDbContext context)
    //    {
    //        _context = context;
    //        entities = _context.Set<T>();
    //        httpcontext = new HttpContextAccessor();
    //    }
    //    //public BaseRepository()
    //    //{

    //    //}

    //    public IQueryable<T> All(bool isComId = true)//int Comid
    //    {
    //        //var comid = httpcontext.HttpContext.Session.GetString("comid");
    //        //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //        var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");
    //        if (ComId == null)
    //        {
    //            ComId = httpcontext.HttpContext.Session.GetInt32("CurrentComId");

    //        }

    //        if (isComId == false)
    //            return entities.Where(x => !x.IsDelete);//


    //        return entities.Where(x => !x.IsDelete && x.ComId == ComId);//
    //    }

    //    public IQueryable<T> AllByBaseCompany(bool isComId = true)//int Comid
    //    {
    //        //var comid = httpcontext.HttpContext.Session.GetString("comid");
    //        //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //        //var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");
    //        var BaseComId = httpcontext.HttpContext.Session.GetInt32("BaseComId");
    //        if (isComId == false)
    //            return entities.Where(x => !x.IsDelete);//


    //        return entities.Where(x => !x.IsDelete && x.ComId == BaseComId);//
    //    }

    //    public IQueryable<T> AllSubData()//int Comid
    //    {
    //        //var comid = httpcontext.HttpContext.Session.GetString("comid");
    //        //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //        var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");


    //        return entities.Where(x => !x.IsDelete);//
    //    }


    //    public IQueryable<T> GetUserData()//int Comid
    //    {
    //        ////var comid = httpcontext.HttpContext.Session.GetString("comid");
    //        //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //        //var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");


    //        return entities.Where(x => !x.IsDelete);//
    //    }

    //    public IQueryable<T> GetCompanyData()//int Comid
    //    {
    //        ////var comid = httpcontext.HttpContext.Session.GetString("comid");
    //        //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //        //var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");


    //        return entities.Where(x => !x.IsDelete);//
    //    }

    //    public IQueryable<T> All(params Expression<Func<T, object>>[] includeProperties)
    //    {
    //        //throw new NotImplementedException();

    //        return includeProperties == null
    //            ? All()
    //          : includeProperties.Aggregate(All(), (current, includeProperty) => current.Include(includeProperty));
    //    }

    //    public void Delete(T entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException("entity");
    //        }
    //        var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //        var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

    //        entities.Remove(entity);
    //        _context.SaveChanges();
    //    }

    //    public void RemoveRange(List<T> entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException("entity");
    //        }
    //        entities.RemoveRange(entity);
    //        _context.SaveChanges();
    //    }

    //    public void AddRange(List<T> entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException("entity");
    //        }
    //        var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //        var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

    //        foreach (var item in entity)
    //        {
    //            item.LuserId = UserId.GetValueOrDefault();
    //            item.ComId = ComId.GetValueOrDefault();
    //            item.CreateDate = DateTime.Now;
    //            item.UpdateDate = DateTime.Now;
    //        }

    //        entities.AddRange(entity);
    //        _context.SaveChanges();
    //    }

    //    public void AddRange(ICollection<T> entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException("entity");
    //        }

    //        var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //        var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

    //        foreach (var item in entity)
    //        {
    //            item.LuserId = UserId.GetValueOrDefault();
    //            item.ComId = ComId.GetValueOrDefault();
    //            item.CreateDate = DateTime.Now;
    //            item.UpdateDate = DateTime.Now;
    //        }

    //        entities.AddRange(entity);
    //        _context.SaveChanges();
    //    }

    //    public T Find(long id)
    //    {
    //        var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //        var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

    //        return entities.SingleOrDefault(s => s.Id == id && s.ComId == ComId);
    //    }

    //    public T Find(long id, params Expression<Func<T, object>>[] includeProperties)
    //    {
    //        return All(includeProperties).FirstOrDefault(x => x.Id == id);
    //    }

    //    public void Insert(T entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException("entity");
    //        }
    //        if (entity.IsDelete == false)
    //        {
    //            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

    //            entity.CreateDate = DateTime.Now;
    //            entity.UpdateDate = DateTime.Now;
    //            entity.ComId = int.Parse(ComId.ToString());
    //            entity.LuserId = int.Parse(UserId.ToString());

    //            entities.Add(entity);
    //            _context.SaveChanges();
    //        }

    //    }



    //    public void InsertApi(T entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException("entity");
    //        }
    //        if (entity.IsDelete == false)
    //        {
    //            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

    //            entity.CreateDate = DateTime.Now;
    //            entity.UpdateDate = DateTime.Now;
    //            entity.ComId = int.Parse(ComId.ToString());
    //            entity.LuserId = int.Parse(UserId.ToString());



    //            entities.Add(entity);
    //            _context.SaveChanges();
    //        }

    //    }

    //    public int InsertEcommerce(T entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException("entity");
    //        }
    //        if (entity.IsDelete == false)
    //        {
    //            //var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //            //var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

    //            entity.CreateDate = DateTime.Now;
    //            entity.UpdateDate = DateTime.Now;
    //            //entity.ComId = int.Parse(ComId.ToString());
    //            //entity.LuserId = int.Parse(UserId.ToString());



    //            entities.Add(entity);
    //            _context.SaveChanges();

    //            return entity.Id;
    //        }
    //        return 0;

    //    }



    //    public int InsertInt(T entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException("entity");
    //        }
    //        if (entity.IsDelete == false)
    //        {
    //            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

    //            entity.CreateDate = DateTime.Now;
    //            entity.UpdateDate = DateTime.Now;
    //            entity.ComId = int.Parse(ComId.ToString());
    //            entity.LuserId = int.Parse(UserId.ToString());
    //            entities.Add(entity);
    //            _context.SaveChanges();

    //            return entity.Id;
    //        }
    //        return 0;
    //    }

    //    public void Update(T entity, int id)
    //    {
    //        try
    //        {


    //            if (entity == null)
    //            {
    //                throw new ArgumentNullException("entity");
    //            }



    //            //entity.CreateDate = entity.CreateDate;
    //            ///entity.CreateDate = DateTime.Now;

    //            //entity.UpdateDate = DateTime.Now;
    //            //entity.CreateDate = entity.CreateDate;
    //            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");


    //            if (id > 0)
    //            {


    //                entity.UpdateDate = DateTime.Now;
    //                //entity.CreateDate = entity.CreateDate;

    //                if (ComId > 0)
    //                {
    //                    entity.ComId = int.Parse(ComId.ToString());
    //                }
    //                if (UserId > 0)
    //                {
    //                    entity.LuserIdUpdate = int.Parse(UserId.ToString());
    //                }
    //                //entity.LuserId = int.Parse(UserId.ToString());
    //            }
    //            else
    //            {

    //                entity.ComId = int.Parse(ComId.ToString());
    //                entity.LuserIdUpdate = int.Parse(UserId.ToString());
    //                entity.UpdateDate = DateTime.Now;
    //                //entity.CreateDate = entity.CreateDate;
    //            }



    //            T exist = _context.Set<T>().Find(id);
    //            if (exist != null)
    //            {
    //                _context.Entry(exist).CurrentValues.SetValues(entity);
    //                _context.SaveChanges();


    //            }

    //            _context.SaveChanges();
    //        }
    //        catch (Exception ex)
    //        {

    //            throw ex;
    //        }
    //    }

    //    public void UpdateApi(T entity, int id)
    //    {
    //        try
    //        {


    //            if (entity == null)
    //            {
    //                throw new ArgumentNullException("entity");
    //            }

    //            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
    //            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

    //            //entity.CreateDate = entity.CreateDate;
    //            ///entity.CreateDate = DateTime.Now;

    //            //entity.CreateDate = entity.CreateDate;
    //            entity.UpdateDate = DateTime.Now;
    //            entity.ComId = int.Parse(ComId.ToString());
    //            entity.LuserId = int.Parse(UserId.ToString());


    //            T exist = _context.Set<T>().Find(id);
    //            if (exist != null)
    //            {
    //                _context.Entry(exist).CurrentValues.SetValues(entity);
    //                _context.SaveChanges();


    //            }

    //            _context.SaveChanges();
    //        }
    //        catch (Exception ex)
    //        {

    //            throw ex;
    //        }
    //    }


    //    public IEnumerable<T> GetRecursive(Expression<Func<T, bool>> expression)
    //    {
    //        IQueryable<T> parents = _context.Set<T>()
    //            .Include(x => x.Children)
    //            .Where(w => w.Parent == null)
    //            .Where(expression);

    //        foreach (T entity in parents)
    //        {
    //            if (entity.Children != null && entity.Children.Any())
    //                entity.Children = _getChildren(entity, expression).ToList();

    //            yield return entity;
    //        }
    //    }

    //    private IEnumerable<T> _getChildren(T parentEntity, Expression<Func<T, bool>> expression)
    //    {
    //        IQueryable<T> children = _context.Set<T>()
    //            .Include(x => x.Parent)
    //            .Where(w => w.Parent != null && w.Parent.Id == parentEntity.Id)
    //            .Where(expression);

    //        foreach (T entity in children)
    //        {
    //            entity.Children = _getChildren(entity, expression).ToList();
    //            yield return entity;
    //        }
    //    }


    //}





    //public abstract class RecursiveRepository<T, TDataContext>
    //where T : RecursiveModel<T> where TDataContext : DbContext
    //{
    //    private readonly InvoiceDbContext DataContext;
    //    protected IEnumerable<T> GetRecursive(Expression<Func<T, bool>> expression)
    //    {
    //        IQueryable<T> parents = DataContext.Set<T>()
    //            .Include(x => x.Children)
    //            .Where(w => w.Parent == null)
    //            .Where(expression);

    //        foreach (T entity in parents)
    //        {
    //            if (entity.Children != null && entity.Children.Any())
    //                entity.Children = _getChildren(entity, expression).ToList();

    //            yield return entity;
    //        }
    //    }

    //    private IEnumerable<T> _getChildren(T parentEntity, Expression<Func<T, bool>> expression)
    //    {
    //        IQueryable<T> children = DataContext.Set<T>()
    //            .Include(x => x.Parent)
    //            .Where(w => w.Parent != null && w.Parent.Id == parentEntity.Id)
    //            .Where(expression);

    //        foreach (T entity in children)
    //        {
    //            entity.Children = _getChildren(entity, expression).ToList();
    //            yield return entity;
    //        }
    //    }


    //}




}
