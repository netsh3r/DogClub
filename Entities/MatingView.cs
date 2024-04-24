using System.ComponentModel.DataAnnotations.Schema;

namespace DogClub.Entities;


public interface IMatingView
{
    public int Id { get; set; }
    public int dogId { get; set; }
    public int fatherId { get; set; }
    public int motherId { get; set; }
}

public class MatingView : BaseEntity, IMatingView
{
    [Column("dog_id")]
    public int dogId { get; set; }
    [Column("father_id")]
    public int fatherId { get; set; }
    [Column("mother_id")]
    public int motherId { get; set; }
}

public class PremiumMatingView : BaseEntity, IMatingView
{
    [Column("dog_id")]
    public int dogId { get; set; }
    [Column("father_id")]
    public int fatherId { get; set; }
    [Column("mother_id")]
    public int motherId { get; set; }
}

public class SpecialMatingView : BaseEntity, IMatingView
{
    [Column("dog_id")]
    public int dogId { get; set; }
    [Column("father_id")]
    public int fatherId { get; set; }
    [Column("mother_id")]
    public int motherId { get; set; }
}