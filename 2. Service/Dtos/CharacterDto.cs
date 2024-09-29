namespace Dtos;

public class CharacterDto
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }
    public List<ClassDto> Classes { get; set; }
    public StatsDto Stats { get; set; }
    public List<ItemDto>? Items { get; set; }
    public List<DefenseDto>? Defenses { get; set; }
}