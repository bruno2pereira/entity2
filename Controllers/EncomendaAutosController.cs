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
    public class EncomendaAutosController : ApiController
    {
        // GET api/EncomendaAutos
        public IHttpActionResult Get()
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    List<EncomendaAuto> list = db.EncomendaAutos.Include(x => x.Automovel).Include(x => x.Encomenda).ToList();
                    if (list != null && list.Count() > 0)
                    {
                        return Ok(list);
                    }
                    return BadRequest("não existem EncomendaAutos para listar");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/EncomendaAutos/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    EncomendaAuto objct = db.EncomendaAutos.Where(x => x.Id == id).Include(x => x.Automovel).Include(x => x.Encomenda).FirstOrDefault();
                    if (objct != null)
                    {
                        return Ok(objct);
                    }
                    return BadRequest("o EncomendaAuto solicitado não existe");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/EncomendaAutos
        public IHttpActionResult Post(EncomendaAuto objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    objct.Automovel = db.Automoveis.Where(x => x.Id == objct.Id).FirstOrDefault();
                    objct.Encomenda = db.Encomendas.Where(x => x.Id == objct.Id).FirstOrDefault();
                    db.EncomendaAutos.Add(objct);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/EncomendaAutos/5
        public IHttpActionResult Put(EncomendaAuto objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {


                    objct.Automovel = db.Automoveis.Where(x => x.Id == objct.Id).FirstOrDefault();
                    objct.Encomenda = db.Encomendas.Where(x => x.Id == objct.Id).FirstOrDefault();

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

        // DELETE api/EncomendaAutos/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    EncomendaAuto objct = db.EncomendaAutos.Where(x => x.Id == id).FirstOrDefault();
                    db.EncomendaAutos.Remove(objct);
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
