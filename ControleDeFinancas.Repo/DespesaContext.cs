using ControleDeFinancas.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeFinancas.Repo
{
    public class DespesaContext : DbContext
    {
        public DespesaContext(DbContextOptions<DespesaContext> options) : base(options)
        {

        }

        public DespesaContext()
        {

        }

        public DbSet<Despesa> Despesa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DespesaContext).Assembly);
        }

    }
}
