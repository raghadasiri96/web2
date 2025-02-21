using demo.Core.Data;
using demo.Core.Repository;
using demo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Infra.Services
{
    public class LoginService : ILoginService

    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public void CreateLogin(Login login)
        {
            _loginRepository.CreateLogin(login);
        }

        public void DeleteLogin(int id)
        {
            _loginRepository.DeleteLogin(id);
        }

        public List<Login> GeiAllLogin()
        {
            return _loginRepository.GeiAllLogin();
        }

        public Login GetLoginById(int id)
        {
            return _loginRepository.GetLoginById(id);
        }

        public void UpdateLogin(Login login)
        {
            _loginRepository.UpdateLogin(login);
        }
    }
}
