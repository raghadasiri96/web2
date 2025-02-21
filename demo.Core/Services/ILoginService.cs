﻿using demo.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Core.Services
{
    public interface ILoginService
    {
        List<Login> GeiAllLogin();
        void CreateLogin(Login login);
        void UpdateLogin(Login login);
        void DeleteLogin(int id);
        Login GetLoginById(int id);
    }
}
