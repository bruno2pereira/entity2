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
    public class TipoCaixasController : ApiController
    {
        // GET api/TipoCaixas
        public IHttpActionResult Get()
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    List<TipoCaixa> list = db.TipoCaixas.ToList();
                    if (list != null && list.Count() > 0)
                    {
                        return Ok(list);
                    }
                    return BadRequest("não existem TipoCaixas para listar");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/TipoCaixas/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    TipoCaixa objct = db.TipoCaixas.Where(x => x.Id == id).FirstOrDefault();
                    if (objct != null)
                    {
                        return Ok(objct);
                    }
                    return BadRequest("a TipoCaixa solicitado não existe");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/TipoCaixas
        public IHttpActionResult Post(TipoCaixa objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    db.TipoCaixas.Add(objct);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/TipoCaixas/5
        public IHttpActionResult Put(TipoCaixa objct)
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

        // DELETE api/TipoCaixas/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    TipoCaixa objct = db.TipoCaixas.Where(x => x.Id == id).FirstOrDefault();
                    db.TipoCaixas.Remove(objct);
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
