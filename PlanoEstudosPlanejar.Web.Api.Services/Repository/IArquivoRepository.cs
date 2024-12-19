using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Services.Repository
{
    public interface IArquivoRepository : IDisposable
    {
        IEnumerable<Arquivos> GetArquivo();
        Arquivos GetArquivoById(int arquivoId);
        void InsertArquivo(Arquivos arquivos);
        void UpdateArquivo(Arquivos arquivos);
        void DeleteArquivo(int arquivoId);
        void Save();
    }

    public class ArquivoRepository : IArquivoRepository, IDisposable
    {
        private readonly DatabaseContext _context;
        public ArquivoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Arquivos> GetArquivo()
        {
            return _context.Arquivos.ToList();
        }

        public Arquivos GetArquivoById(int arquivoId)
        {
            return _context.Arquivos.Find(arquivoId);
        }

        public void InsertArquivo(Arquivos arquivos)
        {
            _context.Arquivos.Add(arquivos);
            Save();
        }

        public void UpdateArquivo(Arquivos arquivos)
        {
            _context.Entry(arquivos).State = EntityState.Modified;
            Save();
        }

        public void DeleteArquivo(int arquivoId)
        {
            var procurarId = _context.Arquivos.Find(arquivoId);
            _context.Arquivos.Remove(procurarId);
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
