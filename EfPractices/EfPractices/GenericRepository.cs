﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfPractices
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void InsertOrUpdate(TEntity entity,
            Expression<Func<TEntity, bool>> identity)
        {
            IQueryable<TEntity> query = dbSet;

            if (identity != null)
            {
                query = query.Where(identity);
            }

            if (query.Count() > 0)
            {
                Update(entity);
            }
            else
            {
                Insert(entity);
            }
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }
    }


    public class GenericUpdater<TEntity, TResult> where TEntity : class
    {
        internal DbContext sourceContext;
        internal DbContext destinationContext;
        internal DbSet<TEntity> dbSourceSet;
        internal DbSet<TEntity> dbDestinationSet;

        public GenericUpdater(DbContext sourceContext, DbContext destinationContext)
        {
            destinationContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            sourceContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            this.destinationContext = destinationContext;
            this.sourceContext = sourceContext;
            this.dbSourceSet = sourceContext.Set<TEntity>();
            this.dbDestinationSet = destinationContext.Set<TEntity>();
        }

        public TResult GetMax(Expression<Func<TEntity, TResult>> selector)
        {
            var max = dbDestinationSet.Max(selector);
            return max;
        }

        public int GetToUpdateData(Expression<Func<TEntity, TResult>> selector,
             Expression<Func<TEntity, bool>> filter = null,
             bool isInsert = true)
        {


            IQueryable<TEntity> query = dbSourceSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            var surveys = query.ToList();

            foreach (var item in surveys)
            {
                if (isInsert)
                {
                    dbDestinationSet.Add(item);
                }
                else
                {
                    dbDestinationSet.Attach(item);
                    destinationContext.Entry(item).State = EntityState.Modified;
                }
            }
            var i = destinationContext.SaveChanges();
            return i;
        }
    }

    public class s
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

    public class OfflineUpdater<TEntity> where TEntity : s
    {
        public int UpdateToOffline()
        {
            int c = 0;
            using (var dbOffcontext = new AdbContext(DatabaseType.Sqlite))
            using (var dbcontext = new AdbContext())
            {
                var gr = new GenericUpdater<TEntity, DateTime?>(sourceContext: dbcontext, destinationContext: dbOffcontext);
                var max = gr.GetMax(a => a.CreatedOn);
                c = gr.GetToUpdateData(a => a.CreatedOn, b => b.CreatedOn != null && b.CreatedOn > max, true);
            }

            using (var dbOffcontext = new AdbContext(DatabaseType.Sqlite))
            using (var dbcontext = new AdbContext())
            {
                var gr = new GenericUpdater<TEntity, DateTime?>(sourceContext: dbcontext, destinationContext: dbOffcontext);
                var max = gr.GetMax(a => a.ModifiedOn);
                c = gr.GetToUpdateData(a => a.ModifiedOn, b => b.ModifiedOn != null && b.ModifiedOn > max, false);
            }

            return c;
        }
    }
}
