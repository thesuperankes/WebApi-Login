using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using WebApi_Login.Models;
using WebApi_Login.Controllers;
using Newtonsoft.Json;

namespace WebApi_Login.Controllers
{
    public class LoginController : ApiController
    {

        RegisterController register = new RegisterController();

        //Ruta para la identificacion de parametros.
        [Route("api/Login/{user}/{password}")]
        public JsonResult<WebApiLogin> Post(string user, string password)
        {
            //guarda el hash md5 en la variable pass.
            var pass = register.CalculateMD5Hash(password);

            //usando las entidades
            using (Entities db = new Entities())
            {
                //se realiza la consulta y se busca en la base de datos algun registro que coincida con el usuario y contraseña obtenidas
                var query = (from n in db.WebApiLogin
                    where n.User == user && n.Password == pass
                    select n).FirstOrDefault();


                //retorna el nombre del registro encontrado.
                return Json(query);
            }

        }
    }
}