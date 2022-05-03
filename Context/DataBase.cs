using EntityV2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityV2.Context
{
    public class DataBase : DbContext
    {
        public DbSet<Aluguer> Alugueres { get; set; }
        public DbSet<Automovel> Automoveis { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Encomenda> Encomendas { get; set; }
        public DbSet<EncomendaAuto> EncomendaAutos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Localidade> Localidades { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
        public DbSet<TipoCaixa> TipoCaixas { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public DataBase() : base("name=DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public static DataBase Create()
        {
            return new DataBase();
        }
    }
}
