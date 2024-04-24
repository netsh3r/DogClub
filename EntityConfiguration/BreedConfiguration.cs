using DogClub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogClub.EntityConfiguration;

public class BreedConfiguration : BaseEntityConfiguration<Breeds>
{
    public override void Configure(EntityTypeBuilder<Breeds> builder)
    {
        base.Configure(builder);
        builder.ToTable("breeds");
        builder.Property(e => e.Name)
            .IsRequired();
        builder.Property(e => e.Character);
        builder.Property(e => e.Color);
        builder.Property(e => e.HeightMax);
        builder.Property(e => e.HeightMin);
    }
}