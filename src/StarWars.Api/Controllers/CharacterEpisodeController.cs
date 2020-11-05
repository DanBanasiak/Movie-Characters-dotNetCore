using MediatR;
using Microsoft.AspNetCore.Mvc;
using StarWars.Application.Commands.CharacterEpisodes.Create;
using StarWars.Application.Dtos.CharacterEpisodes;
using System.Threading.Tasks;

namespace StarWars.Api.Controllers
{
    public class CharacterEpisodeController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCharacterEpisodeDto item)
        {
            await Mediator.Send(new CreateCharacterEpisodeCommand()
            {
                CreateCharacterEpisode = item
            });
            return Ok();
        }
    }
}