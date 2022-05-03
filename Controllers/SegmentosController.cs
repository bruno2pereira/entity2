using EntityV2.Context;
using EntityV2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EntityV2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SegmentosController : ApiController
    {
        // GET api/Segmentos
        public IHttpActionResult Get()
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    List<Segmento> list = db.Segmentos.ToList();
                    if (list != null && list.Count() > 0)
                    {
                        return Ok(list);
                    }
                    return BadRequest("não existem Segmentos para listar");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/Segmentos/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    Segmento objct = db.Segmentos.Where(x => x.Id == id).FirstOrDefault();
                    if (objct != null)
                    {
                        return Ok(objct);
                    }
                    return BadRequest("a Segmento solicitado não existe");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/Segmentos
        public IHttpActionResult Post(Segmento objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    db.Segmentos.Add(objct);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Segmentos/5
        public IHttpActionResult Put(Segmento objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    db.Entry(objct).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/Segmentos/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    Segmento objct = db.Segmentos.Where(x => x.Id == id).FirstOrDefault();
                    db.Segmentos.Remove(objct);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            };
        }
    }
}
