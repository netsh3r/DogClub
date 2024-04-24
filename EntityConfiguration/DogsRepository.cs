using DogClub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogClub.EntityConfiguration;

public class DogsRepository : BaseEntityConfiguration<Dogs>
{
    public override void Configure(EntityTypeBuilder<Dogs> builder)
    {
        base.Configure(builder);
        builder.ToTable("dogs");
        builder.Property(x => x.Address);
        builder.Property(x => x.IsAlive);
        builder.Property(x => x.MetalTest);
        builder.HasOne(x => x.Breed)
            .WithOne()
            .HasForeignKey<Dogs>(x => x.BreedId);
        builder.HasOne(x => x.Owner)
            .WithOne()
            .HasForeignKey<Dogs>(x => x.OwnerId);
    }
}