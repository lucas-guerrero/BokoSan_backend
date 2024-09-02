using AutoMapper;
using BokoSan_backend.Data;
using BokoSan_backend.Models;
using BokoSan_backend.Models.DTOS.incoming;
using BokoSan_backend.Models.DTOS.outcoming;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BokoSan_backend.Controllers;

[Route("bokosan/[controller]")]
[ApiController]
public class HighScoreController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public HighScoreController(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddOrUpdateHighScore(HighScoreForCreationDto highScoreDto)
    {
        var highScore = await _dbContext.HighScores
            .Where(hs => hs.PlayerId == highScoreDto.PlayerId && hs.LevelId == highScoreDto.LevelId)
            .FirstOrDefaultAsync();

        if (highScore == null)
        {
            highScore = _mapper.Map<HighScore>(highScoreDto); 
            _dbContext.HighScores.Add(highScore);
        }
        else
        {
            highScore.NumberOfSteps = highScore.NumberOfSteps;
            highScore.Score = highScore.Score;
            highScore.Time = highScore.Time;
        }

        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllHighScore()
    {
        var highScores = await _dbContext.HighScores.ToListAsync();

        var highScoresDto = _mapper.Map<List<HighScoreDto>>(highScores);
        return Ok(highScoresDto);
    }

    [HttpGet("player/{idPlayer}")]
    public async Task<IActionResult> GetAllHighScoreForPlayer(long idPlayer)
    {
        var player = await _dbContext.Players.Where(p => p.Id == idPlayer).FirstOrDefaultAsync();
        if(player == null)
        {
            return NotFound();
        }

        var hightScoresDto = _mapper.Map<List<HighScoreDto>>(player.HighScores);
        return Ok(hightScoresDto);
    }

    [HttpGet("level/{idLevel}")]
    public async Task<IActionResult> GetAllHighScoreForLevel(long idLevel)
    {
        var level = await _dbContext.Levels.Where(l => l.Id == idLevel).FirstOrDefaultAsync();
        if (level == null)
        {
            return NotFound();
        }

        var hightScoresDto = _mapper.Map<List<HighScoreDto>>(level.HighScores);
        return Ok(hightScoresDto);
    }
}
