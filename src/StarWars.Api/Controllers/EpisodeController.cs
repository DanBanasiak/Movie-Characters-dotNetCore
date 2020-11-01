using MediatR;
using Microsoft.AspNetCore.Mvc;
using StarWars.Application.Commands.Episodes.Create;
using StarWars.Application.Dtos.Episodes;
using StarWars.Application.Queries;
using System.Threading.Tasks;

namespace StarWars.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EpisodeController : ControllerBase
	{
		private readonly IMediator _mediator;
		public EpisodeController(IMediator mediator)
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
		public async Task<IActionResult> PostAsync([FromBody] CreateEpisodeDto item)
		{
			await _mediator.Send(new CreateEpisodeCommand()
			{
				CreateEpisode = item
			});
			return Ok();
		}
	}
}