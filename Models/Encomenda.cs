using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityV2.Models
{
    public class Encomenda
    {
        public int Id { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public List<Automovel> Automoveis { get; set; }
    }
}