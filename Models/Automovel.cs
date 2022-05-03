using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityV2.Models
{
    public class Automovel
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int PrecoDia { get; set; }
        public int Lugares { get; set; }
        public double Valor { get; set; }
        public TipoCaixa TipoCaixa { get; set; }
        public Marca Marca { get; set; }
        public Segmento Segmento { get; set; }
    }
}