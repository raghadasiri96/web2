using demo.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Core.Services
{
    public interface IStdCourseService
    {
        List<Stdcourse> GeiAllStdcourse();
        void CreateStdcourse(Stdcourse stdcourse);
        void UpdateStdcourse(Stdcourse stdcourse);
        void DeleteStdcourse(int id);
        Stdcourse GetStdcourseById(int id);
    }
}
