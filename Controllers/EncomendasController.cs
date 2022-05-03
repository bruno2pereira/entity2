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
    public class EncomendasController : ApiController
    {
        // GET api/Encomendas
        public IHttpActionResult Get()
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    List<Encomenda> list = db.Encomendas.Include(x => x.Automoveis).Include(x=> x.Fornecedor).ToList();
                    for(int i = 0; i < list.Count; i++)
                    {
                        int id = list[i].Fornecedor.Id;
                        list[i].Fornecedor = db.Fornecedores.Where(x => x.Id == id).Include(x=> x.Marca).FirstOrDefault();
                    }
                  
                    if (list != null && list.Count() > 0)
                    {
                        return Ok(list);
                    }
                    return BadRequest("não existem Encomendas para listar");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/Encomendas/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                if(id == 0)
                {
                    return Ok(new Encomenda());
                }
                using (DataBase db = DataBase.Create())
                {
                    Encomenda objct = db.Encomendas.Where(x => x.Id == id).Include(x=> x.Automoveis).Include(x=>x.Fornecedor).FirstOrDefault();
                    if (objct != null)
                    {
                        return Ok(objct);
                    }
                    return BadRequest("a Encomenda solicitado não existe");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/Encomendas
        public IHttpActionResult Post(Encomenda objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {

                    if(objct.Automoveis.Count > 0)
                    {
                       
                        for(int i = 0; i < objct.Automoveis.Count; i++)
                        {
                            Automovel obj = objct.Automoveis[i];
                            objct.Automoveis[i] = db.Automoveis.Where(x => x.Id == obj.Id).Include(x => x.TipoCaixa).Include(x => x.Marca).Include(x => x.Segmento).FirstOrDefault();
                        }
                        objct.Fornecedor = db.Fornecedores.Where(x => x.Id == objct.Fornecedor.Id).Include(x=> x.Marca).FirstOrDefault();
                    }

                    db.Encomendas.Add(objct);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Encomendas/5
        public IHttpActionResult Put(Encomenda objct)
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

        // DELETE api/Encomendas/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    Encomenda objct = db.Encomendas.Where(x => x.Id == id).FirstOrDefault();
                    db.Encomendas.Remove(objct);
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
