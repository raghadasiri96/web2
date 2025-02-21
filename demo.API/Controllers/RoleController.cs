using demo.Core.Data;
using demo.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService= roleService;
        }

        [HttpGet]
        public List<Role> GetAllRole()
        {
            return roleService.GeiAllRole();
        }
        [HttpGet]
        [Route("getbyId/{id}")]
        public Role GetRoleById(int id)
        {

            return roleService.GetRoleById(id);
        }

        [HttpPost]
        public void CreateRole(Role role)
        {
            roleService.CreateRole(role);
        }
        [HttpPut]
        public void UpdateRole(Role role)
        {
            roleService.CreateRole(role);
        }

        [HttpDelete]
        [Route("DeleteRole/{id}")]
        public void Deleterole(int id)
        {
            roleService.DeleteRole(id) ;
        }
    }
}
