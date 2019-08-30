using Empresas.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresas.Data.Service
{
    public class UsuarioService
    {
        public static bool Login(string email, string senha)
        {
            try
            {
                using (DbContext entidades = new DbContext() )
                {
                    return entidades.Usuarios.Any(user => user.Password == senha && user.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
