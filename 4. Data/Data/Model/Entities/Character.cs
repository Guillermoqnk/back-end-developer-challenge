using Data.Entities;
using Data.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnDBeyondAPI.Models;

public class Character : BaseEntity
{
    public ICollection<Class> Classes { get; set; } = new List<Class>();
    public ICollection<Item> Items { get; set; } = new List<Item>();
    public ICollection<Defense> Defenses { get; set; }  = new List<Defense>();
    [Required]
    public Stats Stats { get; set; }  = new Stats();
    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = "";
    [Required]
    public int Level { get; set; }
    [Required]
    public int MaxHitPoints { get; set; }
    public int ActualHitPoints { get; set; }
    public int TemporaryHitPoints { get; set; }
}
