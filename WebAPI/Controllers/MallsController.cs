using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class MallsController : ApiController
    {
        // GET api/mall
        public IEnumerable<Mall> Get()
        {
            using (ARMAEntities armaentities = new ARMAEntities())
            {
                return armaentities.Malls.ToList();//this will return the list of item in db
            }
        }

        // GET api/mall/{id}        
        public HttpResponseMessage Get(int id)
        {
            using (ARMAEntities armaentities = new ARMAEntities())
            {
                var entity = armaentities.Malls.FirstOrDefault(e => e.id == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id=" + id.ToString() + "Not Found");
                }
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {

        }

        //DELETE api/values/{id}
        public void Delete(int id)
        {
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Mall mall)
        {
            try
            {
                using (ARMAEntities armaentities = new ARMAEntities())
                {
                    armaentities.Malls.Add(mall);
                    armaentities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, mall);
                    message.Headers.Location = new Uri(Request.RequestUri + mall.id.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message.ToString());
            }
        }


    }
}
