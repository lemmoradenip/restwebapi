using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class MallController : ApiController
    {
        // GET api/mall
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/mall/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/mall
        public void Post([FromBody]string value)
        {
        }

        // PUT api/mall/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/mall/5
        public void Delete(int id)
        {
        }
    }
}
