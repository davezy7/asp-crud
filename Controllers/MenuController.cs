using GAS_LATIHAN_ASP.Models.DTO;
using GAS_LATIHAN_ASP.Services.MenuService;
using Microsoft.AspNetCore.Mvc;

namespace GAS_LATIHAN_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;
        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenus()
        {
            var result = await _service.GetAllMenus();
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenu(Guid id)
        {
            var result = await _service.GetMenu(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(RequestCreateUpdateMenu menu)
        {
            var result = await _service.CreateMenu(menu);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(Guid id, RequestCreateUpdateMenu menu)
        {
            var result = await _service.UpdateMenu(id, menu);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMenu(Guid id)
        {
            var result = await _service.DeleteMenu(id);
            return result ? Ok(result) : NotFound();
        }
    }
}
