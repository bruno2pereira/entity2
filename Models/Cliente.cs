using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityV2.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public Localidade Localidade { get; set; }
        public string Codigo_Postal { get; set; }
        public int NIF { get; set; }
        public string Email { get; set; }
        public int Contacto { get; set; }
        public string Carta_Conducao { get; set; }
        public int Data_Nascimento { get; set; }

    }
}
