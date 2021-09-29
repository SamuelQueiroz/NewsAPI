using Dominio.Interfaces;
using Entidades.Entidades;
using Infra.Configuracoes;
using Infra.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioUsuario : RepositorioGenerico<ApplicationUser>, IUsuario
    {
        private readonly DbContextOptions<Contexto> _options;
        public RepositorioUsuario()
        {
            _options = new DbContextOptions<Contexto>();
        }

        public async Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular)
        {
            try
            {
                using (var data = new Contexto(_options))
                {
                    await data.ApplicationUsers.AddAsync(
                        new ApplicationUser
                        {
                            Email = email,
                            PasswordHash = senha,
                            Idade = idade,
                            Celular = celular
                        });

                    await data.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
            
        }
    }
}
