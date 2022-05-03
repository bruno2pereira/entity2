using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityV2.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int NIF { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}