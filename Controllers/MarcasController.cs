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
    public class MarcasController : ApiController
    {
        // GET api/Marcas
        public IHttpActionResult Get()
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    List<Marca> list = db.Marcas.ToList();
                    if (list != null && list.Count() > 0)
                    {
                        return Ok(list);
                    }
                    return BadRequest("não existem Marcas para listar");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/Marcas/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    Marca objct = db.Marcas.Where(x => x.Id == id).FirstOrDefault();
                    if (objct != null)
                    {
                        return Ok(objct);
                    }
                    return BadRequest("a Marca solicitado não existe");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/Marcas
        public IHttpActionResult Post(Marca objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    db.Marcas.Add(objct);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Marcas/5
        public IHttpActionResult Put(Marca objct)
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

        // DELETE api/Marcas/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    Marca objct = db.Marcas.Where(x => x.Id == id).FirstOrDefault();
                    db.Marcas.Remove(objct);
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
