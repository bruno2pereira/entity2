using EntityV2.Context;
using EntityV2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EntityV2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FuncionariosController : ApiController
    {
        // GET api/Funcionarios
        public IHttpActionResult Get()
        {
            try
            {
       
                    using (DataBase db = DataBase.Create())
                    {
                        List<Funcionario> list = db.Funcionarios.ToList();
                        if (list != null && list.Count() > 0)
                        {
                            int size = list.Count();
                            for (int i = 0; i < size; i++)
                            {
                                list[i].Password = "*****";
                            }
                            return Ok(list);
                        }
                        return BadRequest("não existem Funcionarios para listar");
                    }
         
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/Funcionarios/5
        public IHttpActionResult Get(int id)
        {
        
            try
            {
                if (id == 0)
                {
                    return Ok(new Funcionario());
                }

                    using (DataBase db = DataBase.Create())
                    {
                        Funcionario objct = db.Funcionarios.Where(x => x.Id == id).FirstOrDefault();
                        if (objct != null)
                        {
                            objct.Password = "*****";
                            return Ok(objct);
                        }
                        return BadRequest("a Funcionario solicitado não existe");
                    }
        
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/Funcionarios
        public IHttpActionResult Post(Funcionario objct)
        {
            try
            {
       
                    using (DataBase db = DataBase.Create())
                    {
                        objct.Password = helper.EncodePassword(objct.Password);
                        db.Funcionarios.Add(objct);
                        db.SaveChanges();
                        return Ok();
                    }
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Funcionarios/5
        public IHttpActionResult Put(Funcionario objct)
        {
            try
            {

                using (DataBase db = DataBase.Create())
                {
                    // Verificar token
                    int id = objct.Id;
                    //db.Entry(objct).State = EntityState.Modified;
                    Funcionario funcionario = db.Funcionarios.Where(x => x.Id == id).FirstOrDefault();
                    funcionario.NIF = objct.NIF;
                    funcionario.Username = objct.Username;
                    funcionario.Nome = objct.Nome;
                    if (objct.Password != "*****")
                    {
                        funcionario.Password = helper.EncodePassword(objct.Password);
                    }
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/Funcionarios/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
   
                    using (DataBase db = DataBase.Create())
                    {
                        Funcionario objct = db.Funcionarios.Where(x => x.Id == id).FirstOrDefault();
                        db.Funcionarios.Remove(objct);
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
