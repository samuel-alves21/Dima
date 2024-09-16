using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80)
            .IsRequired(false);
    }
}