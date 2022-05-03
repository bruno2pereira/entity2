using EntityV2.Context;
using EntityV2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EntityV2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {
        // GET api/Clientes
        public IHttpActionResult Get()
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    List<Cliente> list = db.Clientes.Include(x => x.Localidade).ToList();
                    if(list != null && list.Count() > 0)
                    {
                        return Ok(list);
                    }
                    return BadRequest("não existem Clientes para listar");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/Clientes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return Ok(new Cliente());
                }
                using (DataBase db = DataBase.Create())
                {
                    Cliente objct = db.Clientes.Where(x => x.Id == id).Include(x => x.Localidade).FirstOrDefault();
                    if (objct != null)
                    {
                        return Ok(objct);
                    }
                    return BadRequest("o Cliente solicitado não existe");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/Clientes
        public IHttpActionResult Post(Cliente objct)
        {
            try
            {

                using (DataBase db = DataBase.Create())
                {
                    Localidade localidade = db.Localidades.Where(x => x.Id == objct.Localidade.Id).FirstOrDefault();
                    objct.Localidade = localidade;
                    db.Clientes.Add(objct);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Clientes/5
        public IHttpActionResult Put(Cliente objct)
        {
            try
            {
    
                using (DataBase db = DataBase.Create())
                {
                    objct.Localidade = db.Localidades.Where(x => x.Id == objct.Localidade.Id).FirstOrDefault();
          

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

        // DELETE api/Clientes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
 
                using (DataBase db = DataBase.Create())
                {
                    Cliente objct = db.Clientes.Where(x => x.Id == id).FirstOrDefault();
                    db.Clientes.Remove(objct);
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
