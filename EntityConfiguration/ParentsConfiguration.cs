using DogClub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogClub.EntityConfiguration;

public class ParentsConfiguration : BaseEntityConfiguration<Parents>
{
    public override void Configure(EntityTypeBuilder<Parents> builder)
    {
        base.Configure(builder);
        builder.ToTable("parents");
        
        builder.HasOne(x => x.Dog)
            .WithMany()
            .HasForeignKey(x => x.DogId);
        
        builder.HasOne(x => x.Father)
            .WithMany()
            .HasForeignKey(x => x.FatherId);
        
        builder.HasOne(x => x.Mother)
            .WithMany()
            .HasForeignKey(x => x.MotherId);
    }
}