using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1
{
    // Define the Generic Repository Interface
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        List<T> GetAll();
        T GetById(Guid id);
    }

    // Implement the Generic Repository
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        // Constructor
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Add a new entity to the database
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        // Update an existing entity
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        // Delete an entity from the database
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        // Save changes to the database
        public void Save()
        {
            _context.SaveChanges();
        }

        // Get all entities
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        // Get a single entity by its ID
        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }
    }
}
