using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {


        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {

            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {

            return Ok(await _service.GetAllAsync(page, take));

        }
        [HttpGet]

        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest();

            var categoryDto = await _service.GetByIdAsync(id);

            if (categoryDto == null) return NotFound();

            return StatusCode(StatusCodes.Status200OK, categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDto categoryDto)
        {
            await _service.CreateAsync(categoryDto);
            return StatusCode(StatusCodes.Status201Created);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _service.DeleteAsync(id);


            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateCategoryDto categoryDto)
        {
            if (id < 1) return BadRequest();
            await _service.UpdateAsync(id, categoryDto);

            return NoContent();
        }

    }
}
