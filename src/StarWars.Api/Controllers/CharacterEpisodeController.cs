using MediatR;
using Microsoft.AspNetCore.Mvc;
using StarWars.Application.Commands.CharacterEpisodes.Create;
using StarWars.Application.Dtos.CharacterEpisodes;
using System.Threading.Tasks;

namespace StarWars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterEpisodeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CharacterEpisodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCharacterEpisodeDto item)
        {
            await _mediator.Send(new CreateCharacterEpisodeCommand()
            {
                CreateCharacterEpisode = item
            });
            return Ok();
        }
    }
}