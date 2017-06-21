using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
        // POST api/<controller>
        [Route("api/PersonPhone/{personid}")]
        public List<Telefonos> Post(int personid)
        {
            using (Entities db = new Entities())
            {
                db.Configuration.ProxyCreationEnabled = false;

                var query = db.Telefonos.Where(c => c.PersonasId == personid).ToList();

                //var result = JsonConvert.SerializeObject(query);

                return query;
            }
        }
    }
}
 