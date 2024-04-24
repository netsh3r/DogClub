using System.ComponentModel.DataAnnotations.Schema;
using DogClub.Entities;

namespace DogClub.Entities;

public class Diseases : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
    [Column("method")]
    public string Method { get; set; }
}