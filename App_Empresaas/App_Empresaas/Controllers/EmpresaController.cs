using Empresas.Data.Models;
using Empresas.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App_Empresaas.Controllers
{
    [Authorize]
    public class EmpresaController : ApiController
    {

        [Route("api/1.0/enterprises")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new EmpresaService().Listar());
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }

        [Route("api/1.0/enterprises/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(new EmpresaService().Retornar(id));
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }

        [Route("api/1.0/enterprises")]
        public IHttpActionResult Get(string nome, int id)
        {
            try
            {
                return Ok(new EmpresaService().Listar(nome, id));
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }
    }
}
