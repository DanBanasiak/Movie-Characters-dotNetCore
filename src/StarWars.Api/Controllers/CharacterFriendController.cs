using MediatR;
using Microsoft.AspNetCore.Mvc;
using StarWars.Application.Commands.Characters;
using StarWars.Application.Dtos.CharacterFriends;
using System.Threading.Tasks;

namespace StarWars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterFriendController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CharacterFriendController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCharacterFriendDto item)
        {
            await _mediator.Send(new CreateCharacterFriendCommand
            {
                CreateCharacterFriend = item
            });
            return Ok();
        }
    }
}