using Dominio.Interfaces;
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
        private readonly INoticia _INoticia;

        public ServicoNoticias(INoticia INoticia)
        {
            _INoticia = INoticia;
        }
        public async Task AdicionaNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidaPropriedade(noticia.Titulo, "Titulo");
            var validarInformacao = noticia.ValidaPropriedade(noticia.Informação, "Informacao");

            if(validarInformacao && validarTitulo)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                noticia.Ativo = true;
                await _INoticia.Adicionar(noticia);
            }
        }

        public async Task AtualizaNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidaPropriedade(noticia.Titulo, "Titulo");
            var validarInformacao = noticia.ValidaPropriedade(noticia.Informação, "Informacao");

            if (validarInformacao && validarTitulo)
            {
                noticia.DataAlteracao = DateTime.Now;
                noticia.Ativo = true;
                await _INoticia.Atualizar(noticia);
            }
        }

        public async Task<List<Noticia>> listarNoticiaAtiva()
        {
            return await _INoticia.ListarNoticias(n => n.Ativo);
        }
    }
}
