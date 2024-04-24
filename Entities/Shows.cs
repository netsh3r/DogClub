using System.ComponentModel.DataAnnotations.Schema;
using DogClub.Entities;

namespace DogClub.Entities;

[Table("Shows")]
public class Shows : BaseEntity
{
    [Column("dog_id")]
    public int DogId { get; set; }
    public Dogs Dog { get; set; }
    [Column("date")]
    public DateOnly Date { get; set; }
    [Column("assessment")]
    public int Assessment { get; set; }
    [Column("medal")]
    public int Medals { get; set; }
}