using demo.Core.Data;
using demo.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpGet]
        public List<Login> GetAllLogin()
        {
            return loginService.GeiAllLogin();
        }
        [HttpGet]
        [Route("getbyId/{id}")]
        public Login GetLoginById(int id)
        {

            return loginService.GetLoginById(id);
        }

        [HttpPost]
        public void CreateLogin(Login login)
        {
            loginService.CreateLogin(login);
        }
        [HttpPut]
        public void UpdateLogin(Login login)
        {
            loginService.UpdateLogin(login);
        }

        [HttpDelete]
        [Route("DeleteLogin/{id}")]
        public void DeleteLogin(int id)
        {
            loginService.DeleteLogin(id);
        }
    }

}
