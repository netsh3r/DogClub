using System.ComponentModel.DataAnnotations.Schema;

namespace DogClub.Entities;

[Table("Parents")]
public class Parents : BaseEntity
{
    [Column("dog_id")]
    public int DogId { get; set; }
    public Dogs Dog { get; set; }
    [Column("father_id")]
    public int FatherId { get; set; }
    public Dogs Father { get; set; }
    [Column("mother_id")]
    public int MotherId { get; set; }
    public Dogs Mother { get; set; }
}