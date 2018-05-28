﻿using System;
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
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id=" + id.ToString() + " Not Found");
                }
            }
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Mall mall)
        {
            using (ARMAEntities armaentities = new ARMAEntities())
            {
                var entity = armaentities.Malls.FirstOrDefault(e => e.id == id);
                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id=" + id.ToString() + " Not Found");
                }
                else
                {
                    entity.Name = mall.Name;
                    entity.Description = mall.Description;
                    entity.Mobile = mall.Mobile;
                    entity.Phone = mall.Phone;
                    entity.Email = mall.Email;
                    armaentities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
        }

        //DELETE api/values/{id}
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (ARMAEntities armaentities = new ARMAEntities())
                {
                    var entity = armaentities.Malls.Remove(armaentities.Malls.FirstOrDefault(e => e.id == id));
                    armaentities.SaveChanges();
                    if (entity != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id=" + id.ToString() + " Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id=" + id.ToString() + " Not Found");
            }
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Mall mall)//[FromBody] means that all data from the body field must take the value to add
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
