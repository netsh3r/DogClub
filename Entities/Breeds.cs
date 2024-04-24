using System.ComponentModel.DataAnnotations.Schema;
using DogClub.Entities;

namespace DogClub.Entities;

public class Breeds : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
    [Column("character")]
    public string Character { get; set; }
    [Column("heightmin")]
    public int HeightMin { get; set; }
    [Column("heightmax")]
    public int HeightMax { get; set; }
    [Column("color")]
    public string Color { get; set; }
}