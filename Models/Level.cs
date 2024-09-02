using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokoSan_backend.Models;

[Table("LEVEL")]
public class Level
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Required]
    [Column("CREATOR_ID")]
    public long CreatorId { get; set; }


    [Required]
    [Column("NAME")]
    public string Name { get; set; }

    [Required]
    [Column("CONTENT")]
    public string Content { get; set; }

    [Required]
    [Column("CREATOR_TIME")]
    public long CreatorTime { get; set; }

    public virtual Player Creator { get; set; }
    public virtual List<HighScore> HighScores { get; set; }
}
