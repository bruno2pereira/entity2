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
    public class LocalidadesController : ApiController
    {
        // GET api/Localidades
        public IHttpActionResult Get()
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    List<Localidade> list = db.Localidades.ToList();
                    if (list != null && list.Count() > 0)
                    {
                        return Ok(list);
                    }
                    return BadRequest("não existem Localidades para listar");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/Localidades/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    Localidade objct = db.Localidades.Where(x => x.Id == id).FirstOrDefault();
                    if (objct != null)
                    {
                        return Ok(objct);
                    }
                    return BadRequest("a Localidade solicitado não existe");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/Localidades
        public IHttpActionResult Post(Localidade objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    db.Localidades.Add(objct);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Localidades/5
        public IHttpActionResult Put(Localidade objct)
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

        // DELETE api/Localidades/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    Localidade objct = db.Localidades.Where(x => x.Id == id).FirstOrDefault();
                    db.Localidades.Remove(objct);
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
