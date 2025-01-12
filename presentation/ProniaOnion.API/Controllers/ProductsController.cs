using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page=1, int take=8)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest();
            return Ok(await _service.GetByIdAsync(id));

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]CreateProductDto productDto)
        {
           await _service.CreateAsync(productDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id,UpdateProductDto productDto)
        {
            if(id < 1) return BadRequest();
            await _service.UpdateAsync(id, productDto);
            return NoContent();
        }
    }
}
