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
public class LevelController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public LevelController(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddOrUpdateLevel(LevelForCreationDto levelDto)
    {
        Level level = _mapper.Map<Level>(levelDto);

        var levelBdd = await _dbContext.Levels
            .Where(l => l.Id == level.Id)
            .FirstOrDefaultAsync();

        if (levelBdd == null)
        {
            _dbContext.Levels.Add(level);
        }
        else
        {
            levelBdd.Name = levelDto.Name;
            levelBdd.Content = levelDto.Content;
            levelBdd.CreatorTime = levelDto.CreatorTime;
        }

        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var levels = await _dbContext.Levels.Include(x => x.Creator).ToListAsync();

        var levelsDto = _mapper.Map<List<LevelDto>>(levels);

        return Ok(levelsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var levels = await _dbContext.Levels.Where(level => level.Id == id).FirstOrDefaultAsync();
        if(levels == null)
        {
            return NotFound();
        }

        var levelDto = _mapper.Map<LevelDto>(levels);

        return Ok(levelDto);
    } 

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLevel(long id)
    {
        var levelDelete = await _dbContext.Levels.Where(level => level.Id == id).FirstOrDefaultAsync();
        if (levelDelete != null)
        {
            _dbContext.Levels.Remove(levelDelete);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        return NotFound();
    }
}
