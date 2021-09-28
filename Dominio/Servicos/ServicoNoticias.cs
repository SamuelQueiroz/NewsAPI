using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    class ServicoNoticias : IServicoNoticia
    {
        public Task AdicionaNoticia(Noticia noticia)
        {
            throw new NotImplementedException();
        }

        public Task AtualizaNoticia(Noticia noticia)
        {
            throw new NotImplementedException();
        }

        public Task<List<Noticia>> listarNoticiaAtiva()
        {
            throw new NotImplementedException();
        }
    }
}
