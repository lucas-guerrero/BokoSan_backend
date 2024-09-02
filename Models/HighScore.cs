using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokoSan_backend.Models;

[Table("HIGH_SCORE")]
[PrimaryKey(nameof(PlayerId), nameof(LevelId))]
public class HighScore
{
    [Required]
    [Column("PLAYER_ID")]
    public long PlayerId { get; set; }

    [Required]
    [Column("LEVEL_ID")]
    public long LevelId { get; set; }

    [Required]
    [Column("TIME")]
    public long Time {  get; set; }

    [Required]
    [Column("NUMBER_OF_STEPS")]
    public int NumberOfSteps { get; set; }

    [Required]
    [Column("SCORE")]
    public long Score { get; set; }

    public virtual Player Player { get; set; }

    public virtual Level Level { get; set; }
}
