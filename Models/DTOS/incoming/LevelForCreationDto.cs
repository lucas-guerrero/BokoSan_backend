namespace BokoSan_backend.Models.DTOS.incoming;

public class LevelForCreationDto
{
    public long Id { get; set; }
    public long CreatorId { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public long CreatorTime { get; set; }
}
