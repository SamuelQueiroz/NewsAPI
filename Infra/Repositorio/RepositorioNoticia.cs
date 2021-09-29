using Dominio.Interfaces;
using Entidades.Entidades;
using Infra.Configuracoes;
using Infra.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioNoticia : RepositorioGenerico<Noticia>, INoticia
    {
        private readonly DbContextOptions<Contexto> _options;
        public RepositorioNoticia()
        {
            _options = new DbContextOptions<Contexto>();               
        }

        public async Task<List<Noticia>> ListarNoticias(Expression<Func<Noticia, bool>> exNoticia)
        {
            using (var banco = new Contexto(_options))
            {
                return await banco.Noticias.Where(exNoticia).AsNoTracking().ToListAsync();

            }
        }
    }
}
