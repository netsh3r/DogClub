using DogClub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogClub.EntityConfiguration;

public class DiseasesConfiguration: BaseEntityConfiguration<Diseases>
{
    public override void Configure(EntityTypeBuilder<Diseases> builder)
    {
        base.Configure(builder);
        builder.ToTable("diseases");
        builder.Property(x => x.Name);
        builder.Property(x => x.Method);
    }
}