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
    public class RegisterController1 : ApiController
    {
        public string CalculateMD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody]string name,[FromBody] string password )
        {
            using (Entities db = new Entities())
            {
                db.WebApiLogin.Add(new WebApiLogin()
                {
                    Name = name,
                    Password = CalculateMD5Hash(password)

                });

                db.SaveChangesAsync();

                return "El usuario se agrego";
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