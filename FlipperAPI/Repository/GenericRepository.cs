using FlipperDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace FlipperAPI.Repository
{
    public class GenericRepository<T> where T : class
    {
        internal FlipperDbContext _context;
        internal DbSet<T> _dbSet;


        private GenericRepository()
        {
            _context = FlipperDbContext.Create();
            _dbSet = _context.Set<T>();
        }

        public GenericRepository(FlipperDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        /// <summary>
        /// Get a list of entities of type T
        /// </summary>
        /// <param name="filter">filters result by this param</param>
        /// <param name="orderBy">orders result by this param</param>
        /// <param name="includeProperties">properties to eager-load </param>
        /// <returns></returns>
        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

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

        /// <summary>
        /// Get a single entity of type T
        /// </summary>
        /// <typeparam name="T">
        /// Entity class
        /// </typeparam>
        /// <param name="ID">
        /// The id of the requested item
        /// </param>
        /// <returns>
        /// Either the requested item or null
        /// </returns>
        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Insert a new entity of type T
        /// </summary>
        /// <typeparam name="T">
        /// Entity class
        /// </typeparam>
        /// <param name="ItemToAdd">
        /// Entity to be inserted
        /// </param>
        public virtual void Insert(T ItemToAdd)
        {
            _dbSet.Add(ItemToAdd);
        }

        /// <summary>
        /// Remove an entity of type T
        /// </summary>
        /// <typeparam name="T">
        /// Entity class
        /// </typeparam>
        /// <param name="ItemToRemove">
        /// Entity to be removed
        /// </param>
        public virtual void Delete(T ItemToRemove)
        {
            if (_context.Entry(ItemToRemove).State == EntityState.Detached)
            {
                _dbSet.Attach(ItemToRemove);
            }
            _dbSet.Remove(ItemToRemove);
        }
        
        /// <summary>
        /// Remove an entity of type T with given id
        /// </summary>
        /// <typeparam name="T">
        /// Entity class
        /// </typeparam>
        /// <param name="id">
        /// The id of the required item
        /// </param>
        public virtual void DeleteById(object id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        /// <summary>
        /// Update an entity of type T
        /// </summary>
        /// <param name="ItemToUpdate">
        /// Entity class
        /// </param>
        public virtual void Update(T ItemToUpdate)
        {
            _dbSet.Attach(ItemToUpdate);
            _context.Entry(ItemToUpdate).State = EntityState.Modified;
        }

        [Obsolete("this Update method is deprecated, please use another Update method instead")]
        /// <summary>
        /// Deprecated
        /// </summary>
        /// <typeparam name="T">
        /// Deprecated
        /// </typeparam>
        /// <param name="ItemToUpdate">
        /// Deprecated
        /// </param>
        /// <param name="ID">
        /// Deprecated
        /// </param>
        virtual public void Update(T ItemToUpdate, object ID)
        {
            T OldItem = _context.Set<T>().Find(ID);
            _context.Entry(OldItem).CurrentValues.SetValues(ItemToUpdate);
        }

        /// <summary>
        /// Check if entity T exists
        /// </summary>
        /// <param name="id">
        /// The id of the required item
        /// </param>
        /// <returns></returns>
        public bool Exists(object id)
        {
            return _dbSet.Find(id)!= null ? true : false;
        }
    }
}