using DogClub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogClub.EntityConfiguration;

public class ShowsConfiguration : BaseEntityConfiguration<Shows>
{
    public override void Configure(EntityTypeBuilder<Shows> builder)
    {
        base.Configure(builder);
        builder.ToTable("shows");
        
        builder.HasOne(x => x.Dog)
            .WithMany()
            .HasForeignKey(x => x.DogId);
        builder.Property(x => x.Assessment);
        builder.Property(x => x.Date);
        builder.Property(x => x.Medals);
    }
}