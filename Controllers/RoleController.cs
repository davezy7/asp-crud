using AutoMapper;
using GAS_LATIHAN_ASP.Models.DTO;
using GAS_LATIHAN_ASP.Services.RoleService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAS_LATIHAN_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;
        private readonly IMapper _mapper;
        public RoleController(IRoleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _service.GetAllRoles();
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(Guid id)
        {
            var result = await _service.GetRole(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RequestCreateRole role)
        {
            var newRole = _mapper.Map<RoleDTO>(role);
            var result = await _service.CreateRole(newRole);

            return result == null ? BadRequest() : Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var result = await _service.DeleteRole(id);
            return result ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(Guid id, RequestUpdateRole role)
        {
            var updatedRole = _mapper.Map<RoleDTO>(role);
            var result = await _service.UpdateRole(id, updatedRole);
            return result == null ? BadRequest() : Ok(result);
        }
    }
}
