using DogClub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogClub.EntityConfiguration;

public class MedicalHistoryConfiguration : BaseEntityConfiguration<MedicalHistory>
{
    public override void Configure(EntityTypeBuilder<MedicalHistory> builder)
    {
        base.Configure(builder);
        builder.ToTable("medicalhistory");
        builder.HasOne(x => x.Dog)
            .WithMany()
            .HasForeignKey(x => x.DogId);
        builder.HasOne(x => x.Disease)
            .WithMany()
            .HasForeignKey(x => x.DiseaseId);
        builder.Property(x => x.DiseasesDate);
        builder.Property(x => x.RecoveryDate);
    }
}