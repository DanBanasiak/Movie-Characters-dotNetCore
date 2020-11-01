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
    public class WeaponController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WeaponController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var items = await _mediator.Send(new GetEpisodesQuery());
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateWeaponDto item)
        {
            await _mediator.Send(new CreateWeaponCommand()
            {
                CreateWeapon = item
            });
            return Ok();
        }
    }
}
