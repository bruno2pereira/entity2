using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityV2.Models
{
    public class Aluguer
    {
        public int Id { get; set; }
        public Automovel Automovel { get; set; }
        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime Recolha { get; set; }
        public DateTime Devolucao { get; set; }
    }
}