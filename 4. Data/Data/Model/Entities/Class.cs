using DnDBeyondAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model.Entities
{
    public class Class : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int HitDice { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public Guid CharacterId { get; set; }
    }
}
