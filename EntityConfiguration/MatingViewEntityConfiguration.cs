using DogClub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogClub.EntityConfiguration;

public class MatingViewEntityConfiguration : BaseEntityConfiguration<MatingView>
{
    public override void Configure(EntityTypeBuilder<MatingView> builder)
    {
        base.Configure(builder);
        builder.ToView("basedogmating");
        
        builder.Property(x => x.dogId);
        builder.Property(x => x.fatherId);
        builder.Property(x => x.motherId);
    }
}

public class SpecialViewEntityConfiguration : BaseEntityConfiguration<SpecialMatingView>
{
    public override void Configure(EntityTypeBuilder<SpecialMatingView> builder)
    {
        base.Configure(builder);
        builder.ToView("specialdogmating");
        
        builder.Property(x => x.dogId);
        builder.Property(x => x.fatherId);
        builder.Property(x => x.motherId);
    }
}

public class PremiumMatingViewEntityConfiguration : BaseEntityConfiguration<PremiumMatingView>
{
    public override void Configure(EntityTypeBuilder<PremiumMatingView> builder)
    {
        base.Configure(builder);
        builder.ToView("premiumdogsmating");
        
        builder.Property(x => x.dogId);
        builder.Property(x => x.fatherId);
        builder.Property(x => x.motherId);
    }
}