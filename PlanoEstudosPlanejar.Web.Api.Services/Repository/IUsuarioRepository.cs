using Microsoft.EntityFrameworkCore;
using PlanoEstudosPlanejar.Web.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoEstudosPlanejar.Web.Api.Services.Repository
{
    public interface IUsuarioRepository : IDisposable
    {
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuarioById(int usuarioId);
        void InsertUsuario(Usuario usuario);
        void DeleteUsuario(int usuarioId);
        void UpdateUsuario(Usuario usuario);
        void Save();
    }

    public class UsuarioRepository : IUsuarioRepository, IDisposable
    {
        private readonly DatabaseContext _context;
        public UsuarioRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetUsuarioById(int usuarioId)
        {
            var usuario = _context.Usuarios.Find(usuarioId);
            

            if ( usuario == null)
            {
                return null!;
            }

            return usuario;
        }

        public void InsertUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            Save();
        }

        public void DeleteUsuario(int usuarioId)
        {
            Usuario usuario = _context.Usuarios.Find(usuarioId);
            _context.Usuarios.Remove(usuario);
            Save();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
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
