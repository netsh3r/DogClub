using System.ComponentModel.DataAnnotations.Schema;
using DogClub.Entities;

namespace DogClub.Entities;

public class MedicalHistory : BaseEntity
{
    [Column("disease_id")]
    public int DiseaseId { get; set; }
    public Diseases Disease { get; set; }
    public Dogs Dog { get; set; }
    [Column("dog_id")]
    public int DogId { get; set; }
    [Column("diseases_date")]
    public DateOnly DiseasesDate { get; set; }
    [Column("recovery_date")]
    public DateOnly? RecoveryDate { get; set; }
}