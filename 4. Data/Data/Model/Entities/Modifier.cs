using System.ComponentModel.DataAnnotations;

namespace Data.Model.Entities;

public class Modifier : BaseEntity
{
    public string AffectedObject { get; set; }
    public string AffectedValue { get; set; }
    [MaxLength(2)]
    public sbyte Value { get; set; }
}
