using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Services.Repository
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task<int> Delete(int id);
        Task<T> GetOne(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> SaveAsync();
    }

    public class Repository<T>(DatabaseContext _context) : IRepository<T> where T : class
    {

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetOne(int id) =>
            await _context.Set<T>().FindAsync(id) ?? throw new Exception("Id não encontrado");

        public virtual async Task Create(T entity)
        {
             _context.Set<T>().Add(entity);
             await SaveAsync(); 
        }

        public virtual async Task Update(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }
 
        public virtual async Task<int> Delete(int id)
        {
            var procurarPorId = await GetOne(id);
            _context.Set<T>().Remove(procurarPorId);
            await SaveAsync();
            return id;
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
