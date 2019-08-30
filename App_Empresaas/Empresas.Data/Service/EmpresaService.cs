using Empresas.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresas.Data.Service
{
    public class EmpresaService
    {
        DbContext db = new DbContext();
        public List<Empresa> Listar()
        {
            try
            {
                return db.Empresas.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<Empresa> Listar(string nome, int tipo)
        {
            try
            {

                var query = db.Empresas.AsQueryable<Empresa>();
                if(!string.IsNullOrEmpty(nome))
                {
                    query = query.Where(emp => emp.Name.Contains(nome));
                }
                if(tipo > 0)
                {
                    query = query.Where(emp => emp.Type == tipo);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Empresa Retornar(int id)
        {
            try
            {
                return db.Empresas.Where(empresa => empresa.Id == id).First();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        
    }
}
