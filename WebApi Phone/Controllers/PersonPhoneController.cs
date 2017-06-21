using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApi_Phone.Models;
using Newtonsoft.Json;

namespace WebApi_Phone.Controllers
{
    public class PersonPhoneController : ApiController
    {

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [Route("api/PersonPhone/{personid}")]
        public JsonResult<List<Telefonos>> Get(int personid)
        {

            using (Entities db = new Entities())
            {
                //se realiza la consulta y se busca en la base de datos algun registro que coincida con el usuario y contraseña obtenidas
                var query = (from n in db.Telefonos where n.Id == personid
                             select n).ToList();


                //retorna el nombre del registro encontrado.
                return Json(query);
            }

        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}