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
    public class AutomoveisController : ApiController
    {



        // GET api/Automoveis
        public IHttpActionResult Get()
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    List<Automovel> list = db.Automoveis.Include(x => x.TipoCaixa).Include(x => x.Marca).Include(x => x.Segmento).ToList();
                    if (list != null && list.Count() > 0)
                    {
                        return Ok(list);
                    }
                    return BadRequest("não existem Automoveis para listar");
                }
            }
            catch
            {
                return BadRequest();
            }
        }



        [Route("api/Automoveis/disponiveis")]
        // GET api/Automoveis
        public IHttpActionResult GetDisponiveis(DateTime start, DateTime end)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {

              

                    List<Aluguer> aluguers = db.Alugueres
                        .Include(x => x.Automovel)
                        .Where(x =>
                        ((x.Recolha > start && x.Recolha < end) || (x.Devolucao > start && x.Devolucao < end)) ||
                        x.Recolha < start && x.Devolucao > end
                        ).ToList();
                    List<Automovel> list = db.Automoveis.Include(x => x.TipoCaixa).Include(x => x.Marca).Include(x => x.Segmento).ToList();


                    aluguers.ForEach(x =>
                    {
                        list.Remove(x.Automovel);
                    });

                    if (list != null && list.Count() > 0)
                    {
                        return Ok(list);
                    }
                    return BadRequest("não existem Automoveis para listar");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/Automoveis/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                if (id == 0)
                {
                    return Ok(new Automovel());
                }
                using (DataBase db = DataBase.Create())
                {
                    Automovel objct = db.Automoveis.Where(x => x.Id == id).Include(x => x.TipoCaixa).Include(x => x.Marca).Include(x => x.Segmento).FirstOrDefault();
                    if (objct != null)
                    {
                        return Ok(objct);
                    }
                    return BadRequest("o Automovel solicitado não existe");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/Automoveis
        public IHttpActionResult Post(Automovel objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    TipoCaixa tipoCaixa = db.TipoCaixas.Where(x => x.Id == objct.TipoCaixa.Id).FirstOrDefault();
                    Marca marca = db.Marcas.Where(x => x.Id == objct.Marca.Id).FirstOrDefault();
                    Segmento segmento = db.Segmentos.Where(x => x.Id == objct.Segmento.Id).FirstOrDefault();
                    objct.TipoCaixa = tipoCaixa;
                    objct.Marca = marca;
                    objct.Segmento = segmento;
                    db.Automoveis.Add(objct);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Automoveis/5
        public IHttpActionResult Put(Automovel objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    Automovel auExist = db.Automoveis.Where(x => x.Id == objct.Id).FirstOrDefault();
                    TipoCaixa tipoCaixa = db.TipoCaixas.Where(x => x.Id == objct.TipoCaixa.Id).FirstOrDefault();
                    Marca marca = db.Marcas.Where(x => x.Id == objct.Marca.Id).FirstOrDefault();
                    Segmento segmento = db.Segmentos.Where(x => x.Id == objct.Segmento.Id).FirstOrDefault();
                    auExist.TipoCaixa = tipoCaixa;
                    auExist.Marca = marca;
                    auExist.Segmento = segmento;
                    db.Entry(auExist).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/Automoveis/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    Automovel objct = db.Automoveis.Where(x => x.Id == id).FirstOrDefault();
                    db.Automoveis.Remove(objct);
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
