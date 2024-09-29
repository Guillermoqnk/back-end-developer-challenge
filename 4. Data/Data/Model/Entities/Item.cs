using DnDBeyondAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace Data.Model.Entities;

public class Item : BaseEntity
{
    [MaxLength(30)]
    public string Name { get; set; }

    public Modifier Modifier { get; set; }
    
    public ICollection<Character> Characters { get; set; } = new List<Character>();
}
