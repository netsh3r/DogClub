using System.ComponentModel.DataAnnotations.Schema;
using DogClub.Entities;

namespace DogClub.Entities;

public class Owner : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
    [Column("phone")]
    public string Phone { get; set; }
}