using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DogClub.Entities;

public class BaseEntity
{
    [Column("id")]
    public int Id { get; set; }
}