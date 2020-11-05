using MediatR;
using Microsoft.AspNetCore.Mvc;
using StarWars.Application.Commands.Weapons.Create;
using StarWars.Application.Dtos.Weapons;
using StarWars.Application.Queries;
using System.Threading.Tasks;

namespace StarWars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var items = await Mediator.Send(new GetEpisodesQuery());
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateWeaponDto item)
        {
            await Mediator.Send(new CreateWeaponCommand()
            {
                CreateWeapon = item
            });
            return Ok();
        }
    }
}
