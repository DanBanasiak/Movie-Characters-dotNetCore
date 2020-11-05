using MediatR;
using Microsoft.AspNetCore.Mvc;
using StarWars.Application.Commands.Characters;
using StarWars.Application.Dtos.CharacterFriends;
using System.Threading.Tasks;

namespace StarWars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterFriendController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCharacterFriendDto item)
        {
            await Mediator.Send(new CreateCharacterFriendCommand
            {
                CreateCharacterFriend = item
            });
            return Ok();
        }
    }
}