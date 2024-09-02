using AutoMapper;
using BokoSan_backend.Data;
using BokoSan_backend.Models;
using BokoSan_backend.Models.DTOS.incoming;
using BokoSan_backend.Models.DTOS.outcoming;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BokoSan_backend.Controllers;

[Route("bokosan/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public PlayerController(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddPlayer(PlayerForCreationDto playerDto)
    {
        playerDto.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(playerDto.Password);
        var player = _mapper.Map<Player>(playerDto);

        _dbContext.Players.Add(player);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var players = await _dbContext.Players.ToListAsync();
        var playersDto = _mapper.Map<List<PlayerDto>>(players);
        return Ok(playersDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(long id)
    {
        var playerDelete = await _dbContext.Players.Where(player  => player.Id == id).FirstOrDefaultAsync();
        if (playerDelete != null)
        {
            _dbContext.Players.Remove(playerDelete);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        return NotFound();
    }

    [HttpPost("login")]
    public async Task<IActionResult> GetPlayer(PlayerForLoginDto login)
    {
        List<Player> playersLogin = await _dbContext.Players.Where(player => player.Username == login.Username).ToListAsync();
        if (playersLogin.Count() <= 0)
        {
            return NotFound();
        }

        foreach (var player in playersLogin)
        {
            bool IsValidate = BCrypt.Net.BCrypt.EnhancedVerify(login.Password, player.Password);
            if (IsValidate)
            {
                var playerDto = _mapper.Map<PlayerDto>(player);
                return Ok(playerDto);
            }
        }

        return NotFound();
    }
}
