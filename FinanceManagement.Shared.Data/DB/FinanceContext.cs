using Finance_console;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.Shared.Data.DB
{
    public class FinanceContext : DbContext
    {
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FinanceDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
