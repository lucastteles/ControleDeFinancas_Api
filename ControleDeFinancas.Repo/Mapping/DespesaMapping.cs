using ControleDeFinancas.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ControleDeFinancas.Repo.Mapping
{
    public class DespesaMapping : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.ToTable("Despesa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
              .HasColumnName("Nome")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(x => x.Valor)
              .HasColumnName("Valor")
              .IsRequired();

            builder.Property(x => x.StatusPagamento)
             .HasColumnName("StatusPagamento");
             
            builder.Property(x => x.DataCadastro)
             .HasColumnName("DataCadastro");
        }
    }
}
