using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresas.Data.Models
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("name=ioasysDbContext")
        {

        }

        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
