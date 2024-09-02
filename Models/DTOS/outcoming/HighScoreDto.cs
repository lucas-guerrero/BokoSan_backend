namespace BokoSan_backend.Models.DTOS.outcoming;

public class HighScoreDto
{
    public string UsernamePlayer { get; set; }

    public string NameOfLevel { get; set; }

    public long Time { get; set; }

    public int NumberOfSteps { get; set; }

    public long Score { get; set; }
}
