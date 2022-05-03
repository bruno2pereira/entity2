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
    public class AlugueresController : ApiController
    {
        // GET api/Alugueres
        public IHttpActionResult Get()
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    DateTime dayStart = DateTime.Now.Date.Add(new TimeSpan(00, 00, 0)); 
                    DateTime dayEnd = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59));

                    List<Aluguer> list = new List<Aluguer>();
                   
                   
                    list.AddRange(db.Alugueres.Include(x => x.Automovel).Include(x => x.Cliente).Include(x => x.Funcionario).Where(c => c.Devolucao > dayStart && c.Devolucao < dayEnd).OrderByDescending(c => c.Devolucao).ThenBy(x => x.Cliente).ToList());
                    list.AddRange(db.Alugueres.Include(x => x.Automovel).Include(x => x.Cliente).Include(x => x.Funcionario).Where(c => c.Devolucao < dayStart || c.Devolucao > dayEnd).OrderByDescending(c => c.Devolucao).ThenBy(x => x.Cliente).ToList());
                   //List<Aluguer> list = db.Alugueres.Include(x => x.Automovel).Include(x => x.Cliente).Include(x => x.Funcionario).OrderByDescending(c =>  c.Devolucao == null ? 2 :  c.Devolucao < DateTime.Today ? 0 : c.Devolucao > DateTime.Today ? 3 : 1).ThenByDescending(c => c.Devolucao).ThenBy(x => x.Cliente).ToList();
                    if (list != null && list.Count() > 0)
                    {
                        return Ok(list);
                    }
                    return BadRequest("não existem Alugueres para listar");
                }
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        // GET api/Alugueres/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return Ok(new Aluguer());
                }
                using (DataBase db = DataBase.Create())
                {

                  
                    Aluguer objct = db.Alugueres.Where(x => x.Id == id).Include(x => x.Automovel).Include(x => x.Cliente).Include(x => x.Funcionario).FirstOrDefault();
                    if (objct != null)
                    {
                        return Ok(objct);
                    }
                    return BadRequest("o Aluguer solicitado não existe");
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/Alugueres
        public IHttpActionResult Post(Aluguer objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    objct.Automovel = db.Automoveis.Where(x => x.Id == objct.Automovel.Id).FirstOrDefault();
                    objct.Cliente = db.Clientes.Where(x => x.Id == objct.Cliente.Id).FirstOrDefault();
                    objct.Funcionario = db.Funcionarios.Where(x => x.Id == objct.Funcionario.Id).FirstOrDefault();
                    db.Alugueres.Add(objct);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Alugueres/5
        public IHttpActionResult Put(Aluguer objct)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {

                    Aluguer aluExist = db.Alugueres.Where(x => x.Id == objct.Id).FirstOrDefault();
                    aluExist.Automovel = db.Automoveis.Where(x => x.Id == objct.Automovel.Id).FirstOrDefault();
                    aluExist.Cliente = db.Clientes.Where(x => x.Id == objct.Cliente.Id).FirstOrDefault();
                    aluExist.Funcionario = db.Funcionarios.Where(x => x.Id == objct.Funcionario.Id).FirstOrDefault();
                    aluExist.Devolucao = objct.Devolucao;
                    aluExist.Recolha = objct.Recolha;
                    db.Entry(aluExist).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/Alugueres/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (DataBase db = DataBase.Create())
                {
                    Aluguer objct = db.Alugueres.Where(x => x.Id == id).FirstOrDefault();
                    db.Alugueres.Remove(objct);
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
