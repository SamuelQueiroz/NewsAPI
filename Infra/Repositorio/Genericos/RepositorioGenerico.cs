using Dominio.Interfaces.Genericos;
using Infra.Configuracoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio.Genericos
{
    public class RepositorioGenerico<T> : IGenericos<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<Contexto> _options;
        public RepositorioGenerico()
        {
            _options = new DbContextOptions<Contexto>();
        }
        public async Task Adicionar(T Obj)
        {
            using (var data = new Contexto(_options))
            {
                await data.Set<T>().AddAsync(Obj);
                await data.SaveChangesAsync();

            }
        }

        public async Task Atualizar(T Obj)
        {
            using (var data = new Contexto(_options))
            {
                data.Set<T>().Update(Obj);
                await data.SaveChangesAsync();

            }
        }

        public async Task<T> BuscarPorId(int Id)
        {
            using (var data = new Contexto(_options))
            {
                return await data.Set<T>().FindAsync(Id);
            }
                
        }

        public async Task Excluir(T Obj)
        {
            using (var data = new Contexto(_options))
            {
                data.Set<T>().Remove(Obj);
                await data.SaveChangesAsync();

            }
        }

        public async Task<List<T>> Listar()
        {
            using (var data = new Contexto(_options))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();

            }
        }

        #region Dispose - metodo padrão
  
        private bool _disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed objects that implement IDisposable.
                // Assign null to managed objects that consume large amounts of memory or consume scarce resources.
            }

            // Free unmanaged resources (unmanaged objects).

            _disposed = true;
        }

        #endregion
    }
}
