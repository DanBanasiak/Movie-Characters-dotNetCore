using MediatR;
using Microsoft.AspNetCore.Mvc;
using StarWars.Api.Helpers;
using StarWars.Application.Commands.Characters.Create;
using StarWars.Application.Commands.Characters.Delete;
using StarWars.Application.Commands.Characters.Update;
using StarWars.Application.Dtos.Characters;
using StarWars.Application.Queries;
using StarWars.Domain.Specifications;
using System.Threading.Tasks;

namespace StarWars.Api.Controllers
{
	public class CharacterController : BaseController
	{
		[HttpGet]
		public async Task<ActionResult<Pagination<GetCharacterDto>>> GetAllAsync(
			[FromQuery]ProductSpecParams productParams)
		{
			var characters = await Mediator.Send(new GetCharactersQuery()
			{
				ProductSpecParams = productParams
			});

			var pagination = new Pagination<GetCharacterDto>(
				productParams.PageIndex, productParams.PageSize, characters.Count, characters);

			return Ok(pagination);
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] CreateCharacterDto item)
		{
			await Mediator.Send(new CreateCharacterCommand()
			{
				CreateCharacter = item
			});
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateCharacterDto item)
		{
			await Mediator.Send(new UpdateCharacterCommand()
			{
				CharacterId = id,
				UpdateCharacter = item
			});
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			await Mediator.Send(new DeleteCharacterCommand()
			{
				CharacterId = id
			});
			return Ok();
		}
	}
}