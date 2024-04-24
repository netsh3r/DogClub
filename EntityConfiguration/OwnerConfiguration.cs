using DogClub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogClub.EntityConfiguration;

public class OwnerConfiguration : BaseEntityConfiguration<Owner>
{
    public override void Configure(EntityTypeBuilder<Owner> builder)
    {
        base.Configure(builder);
        builder.ToTable("owner");
        builder.Property(x => x.Name)
            .IsRequired();
        builder.Property(x => x.Phone)
            .IsRequired();
    }
}