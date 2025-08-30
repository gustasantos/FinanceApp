using FinanceApp.Financeiro.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApp.Financeiro.Infrastructure.Configurations;

public class DespesaConfiguration : IEntityTypeConfiguration<Despesa>
{
    public void Configure(EntityTypeBuilder<Despesa> builder)
    {
        builder.ToTable("Despesas");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedNever();

        builder.Property(d => d.Categoria)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Valor)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(d => d.Data)
            .IsRequired();

        builder.Property(d => d.Descricao)
            .HasMaxLength(500);

        builder.Property(d => d.UsuarioId)
            .IsRequired();
        
        builder.HasIndex(d => d.UsuarioId);
    }
}
