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
    public class FornecedoresController : ApiController
    {
        // GET api/Fornecedores
        public IHttpActionResult Get()
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    List<Fornecedor> list = db.Fornecedores.Include(x => x.Marca).ToList();
                    if (list != null && list.Count() > 0)
                    {
                        return Ok(list);
                    }
                    return BadRequest("não existem Fornecedores para listar");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/Fornecedores/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                if(id == 0)
                {
                    return Ok(new Fornecedor());
                }
                using (DataBase db = DataBase.Create())
                {
                    Fornecedor objct = db.Fornecedores.Where(x => x.Id == id).Include(x => x.Marca).FirstOrDefault();
                    if (objct != null)
                    {
                        return Ok(objct);
                    }
                    return BadRequest("o Fornecedor solicitado não existe");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/Fornecedores
        public IHttpActionResult Post(Fornecedor objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {

                    objct.Marca = db.Marcas.Where(x=> x.Id == objct.Marca.Id).FirstOrDefault();
                    db.Fornecedores.Add(objct);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Fornecedores/5
        public IHttpActionResult Put(Fornecedor objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    objct.Marca = db.Marcas.Where(x => x.Id == objct.Marca.Id).FirstOrDefault();
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

        // DELETE api/Fornecedores/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    Fornecedor objct = db.Fornecedores.Where(x => x.Id == id).FirstOrDefault();
                    db.Fornecedores.Remove(objct);
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
