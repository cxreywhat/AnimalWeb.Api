using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalWeb.Api.Controllers
{
    [Authorize]
    [Controller]
    [Route("animals/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _repository;

        public AnimalController(IAnimalRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<RepositoryResponse<List<Animal>>>> GetAllAnimal()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<RepositoryResponse<Animal>>> GetByIdAnimal(int id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<RepositoryResponse<Animal>>> CreateAnimal(CreateAnimalDto newAnimal)
        {
            return Ok(await _repository.CreateAsync(newAnimal));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<RepositoryResponse<Animal>>> UpdateAnimal(UpdateAnimalDto updateAnimal)
        {
            return Ok(await _repository.UpdateAsync(updateAnimal.Id, updateAnimal));
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<RepositoryResponse<List<Animal>>>> DeleteAnimal(int id)
        {
            var entity = await _repository.DeleteAsync(id);
            if(entity == null)
                return NotFound($"Not found animal with id {id}");

            return Ok(entity);
        }


    }
}