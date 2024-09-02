namespace BokoSan_backend.Models.DTOS.incoming;

public class HighScoreForCreationDto
{
    public long PlayerId { get; set; }

    public long LevelId { get; set; }

    public long Time { get; set; }

    public int NumberOfSteps { get; set; }

    public long Score { get; set; }
}
