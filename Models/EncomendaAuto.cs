using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityV2.Models
{
    public class EncomendaAuto
    {
        public int Id { get; set; }
        public Automovel Automovel { get; set; }
        public Encomenda Encomenda { get; set; }
        public int Quantidade { get; set; }
    }
}