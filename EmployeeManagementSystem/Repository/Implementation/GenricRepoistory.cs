using EmployeeManagementSystem.Interface.Repositories;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagementSystem.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EmployeemanagementContext _context;
        private readonly DbSet<T> dbSet;
        public GenericRepository(EmployeemanagementContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        //public async Task AddAsync(T entity)
        //{
        //    await dbSet.AddAsync(entity);
        //   await SaveAsync();
        //}

        public async Task AddAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                await SaveAsync();
            }
            catch (DbUpdateException ex) when (ex.InnerException is MySqlConnector.MySqlException sqlEx &&
                                               sqlEx.Message.Contains("a foreign key constraint fails"))
            {
                // You can log it or throw a user-friendly custom exception
                throw new ApplicationException("Invalid foreign key reference. Please check DepartmentId or RoleId.");
            }
            catch (Exception)
            {
                // Re-throw or log other unhandled exceptions
                throw;
            }
        }


        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
            await Task.CompletedTask;
        }

        public async Task<T?> FindByIdAsync(int id)
        {
            var result = await dbSet.FindAsync(id);
            return result;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await SaveAsync();
            return entity;
        }

        public T Update(T entity, int id)
        {
            T existingEntry = dbSet.Find(id);

            if (existingEntry != null)
            {
                _context.Entry(existingEntry).CurrentValues.SetValues(entity);
                return existingEntry;
            }

            return null;
        }
    }
}
