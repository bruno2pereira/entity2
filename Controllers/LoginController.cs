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
    public class LoginController : ApiController
    {   
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        // GET api/login*
        public IHttpActionResult Post(Login user)
        {
            try
            {
                //var cookies = HttpContext.Current.Request.Cookies.Get(0);
                using (DataBase db = new DataBase())
                {
                    string encodedPassword = helper.EncodePassword(user.Password);

                  
                    Funcionario funcionario = db.Funcionarios.Where(x => x.Username == user.Username && x.Password == encodedPassword).FirstOrDefault();

                    if (funcionario != null)
                    {
                        Guid guidToken = Guid.NewGuid();
                        Token token = new Token(guidToken, DateTime.Now.AddDays(1));
                        db.Tokens.Add(token);
                        db.SaveChanges();
                        var cookie = new HttpCookie("token");
                        cookie.Value = guidToken.ToString();
                        cookie.Secure = true;
                        cookie.SameSite = SameSiteMode.None;
                        cookie.Expires = DateTime.Now.AddDays(1);
                        HttpContext.Current.Response.Cookies.Add(cookie);
                        return Ok(cookie.Value);
                    }
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }



    }
}