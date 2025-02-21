using demo.Core.Data;
using demo.Core.Repository;
using demo.Core.Services;
using demo.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Infra.Services
{
    public class StdCourseService:IStdCourseService
    {
        private readonly IStdCourseRepository _StdCourseRepository;
        public StdCourseService(IStdCourseRepository stdCourseRepository)
        {
            _StdCourseRepository = stdCourseRepository;
        }
        public void CreateStdcourse(Stdcourse stdcourse)
        {
            _StdCourseRepository.CreateStdcourse(stdcourse);
        }

        public void DeleteStdcourse(int id)
        {
            _StdCourseRepository.DeleteStdcourse(id);
        }

        public List<Stdcourse> GeiAllStdcourse()
        {
            return _StdCourseRepository.GeiAllStdcourse();
        }

        public Stdcourse GetStdcourseById(int id)
        {
            return _StdCourseRepository.GetStdcourseById(id);

        }

        public void UpdateStdcourse(Stdcourse stdcourse)
        {
            _StdCourseRepository.UpdateStdcourse(stdcourse);
        }
    }
}
