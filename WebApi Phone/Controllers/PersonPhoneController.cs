using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        // POST api/<controller>
        [Route("api/PersonPhone/{personid}")]
        public IEnumerable<Telefonos> Post(int personid)
        {
            using (Entities db = new Entities())
            {
                var query = (from t in db.Telefonos where t.PersonasId == personid select t).ToList();

                return query;
            }
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