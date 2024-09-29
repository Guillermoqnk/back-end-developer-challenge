using Data.Enums;
using Data.Model.Entities;
using DnDBeyondAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class Defense : BaseEntity
{
    [Required] 
    public Guid CharacterId { get; set; } = new Guid();

    [Required] 
    public TypesOfDamage TypeOfDamage { get; set; } = new TypesOfDamage();

    [Required] 
    public Defenses Defenses { get; set; } = new Defenses();
}
