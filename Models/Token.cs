using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityV2.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public DateTime Expire { get; set; }

        public Token(Guid guid, DateTime exp)
        {
            this.Guid = guid.ToString();
            this.Expire = exp;
        }

        public Token()
        {

        }
    }



}
