using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model.Entities;

public class Stats : BaseEntity
{
    [Required]
    [MaxLength(2)]
    public byte Strenght { get; set; }
    [Required]
    [MaxLength(2)]
    public byte Dexterity { get; set; }
    [Required]
    [MaxLength(2)]
    public byte Constitution { get; set; }
    [Required]
    [MaxLength(2)]
    public byte Intelligence { get; set; }
    [Required]
    [MaxLength(2)]
    public byte Wisdom { get; set; }
    [Required]
    [MaxLength(2)]
    public byte Charisma { get; set; }
}
