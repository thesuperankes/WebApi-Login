using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WebApi_Login.Models;

namespace WebApi_Login.Controllers
{
    public class RegisterController : ApiController
    {
        public string CalculateMD5Hash(string input)
        {
            // step 1, calcular MD5 hash desde input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convertir byte array a hex string

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            //retornar el resultado.
            return sb.ToString();
        }
        
        // POST api/Register
        //Ruta de los parametros.
        [Route("api/Register/{name}/{user}/{password}")]
        public string Post(string name,string user, string password)
        {
            //usando las entidades
            using (Entities db = new Entities())
            {
                //se crea una variable donde se almacena el nuevo objeto.
                var data = new WebApiLogin {Name = name, User = user, Password = CalculateMD5Hash(password)};

                //se agrega usando entity frameworks.
                db.WebApiLogin.Add(data);

                //se guardan los cambios.
                db.SaveChanges();

                //se envia un mensaje confirmando la creacion del nuevo usuario.
                return "El usuario se agrego";
            }

        }
    }
}