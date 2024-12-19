using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Services.Repository
{
    public interface IPlanoEstudosRepository : IDisposable
    {
        IEnumerable<PlanoEstudo> GetPlanoEstudo();
        PlanoEstudo GetPlanoEstudoById(int planoEstudoId);
        void InsertPlanoEstudo(PlanoEstudo planoEstudo);
        void UpdatePlanoEstudo(PlanoEstudo planoEstudo);
        void DeletePlanoEstudo(int planoEstudoId);
        void Save();
    }

    public class PlanoEstudosRepository : IPlanoEstudosRepository, IDisposable
    {
        private readonly DatabaseContext _context;
        public PlanoEstudosRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<PlanoEstudo> GetPlanoEstudo()
        {
            return _context.PlanoEstudos.ToList();
        }

        public PlanoEstudo GetPlanoEstudoById(int planoEstudoId)
        {
            return _context.PlanoEstudos.Find(planoEstudoId);
        }

        public void InsertPlanoEstudo(PlanoEstudo planoEstudo)
        {
            _context.PlanoEstudos.Add(planoEstudo);
            Save();
        }

        public void UpdatePlanoEstudo(PlanoEstudo planoEstudo)
        {
            _context.Entry(planoEstudo).State = EntityState.Modified;
            Save();
        }

        public void DeletePlanoEstudo(int planoEstudoId)
        {
            var procurarId = _context.PlanoEstudos.Find(planoEstudoId);
            _context.PlanoEstudos.Remove(procurarId);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
