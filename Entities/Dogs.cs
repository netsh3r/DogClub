using System.ComponentModel.DataAnnotations.Schema;
using DogClub.Entities;

namespace DogClub.Entities;

[Table("Dogs")]
public class Dogs : BaseEntity
{
    public Owner Owner { get; set; }
    [Column("owner_id")]
    public int OwnerId { get; set; }
    public Breeds Breed { get; set; }
    [Column("breed_id")]
    public int BreedId { get; set; }
    [Column("address")]
    public string Address { get; set; }
    [Column("isalive")]
    public bool IsAlive { get; set; }
    [Column("mentaltest")]
    public int MetalTest {get; set; }
}