using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokoSan_backend.Models;

[Table("PLAYER")]
public class Player
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Required]
    [Column("USERNAME")]
    public string Username { get; set; }

    [Required]
    [Column("PASSWORD")]
    public string Password { get; set; }

    [Required]
    [Column("EMAIL")]
    public string Email { get; set; }

    public virtual List<Level> LevelsCreated { get; set; }
    public virtual List<HighScore> HighScores { get; set; }
}
