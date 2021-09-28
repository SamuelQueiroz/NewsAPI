using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Genericos
{
    public interface IGenericos<T> where T : class
    {

        Task Adicionar(T Obj);
        Task Atualizar(T Obj);
        Task Excluir(T Obj);
        Task<T> BuscarPorId(int Id);
        Task<List<T>> Listar();
    }
}
