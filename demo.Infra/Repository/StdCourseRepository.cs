using Dapper;
using demo.Core.Common;
using demo.Core.Data;
using demo.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Infra.Repository
{
    public class StdCourseRepository : IStdCourseRepository
    {
        private readonly IDbContext _dbConext;

        public StdCourseRepository(IDbContext dbConext)
        {

            _dbConext = dbConext;

        }

        public List<Stdcourse> GeiAllStdcourse()
        {
            IEnumerable<Stdcourse> result = _dbConext.Connection.Query<Stdcourse>
              ("stdcourse_package.GetAllstdcourse", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public void CreateStdcourse(Stdcourse stdcourse)
        {
            var p = new DynamicParameters();
            p.Add("mark", stdcourse.Markofstd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("dateofreg", stdcourse.Dateofregister, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("student_id", stdcourse.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("course_id", stdcourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("stdcourse_package.makestdcourse", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteStdcourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("stdcourse_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("stdcourse_package.deletestddcourse", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateStdcourse(Stdcourse stdcourse)
        {
            var p = new DynamicParameters();
            p.Add("stdcourse_id", stdcourse.Stdcourseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("mark", stdcourse.Markofstd, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("dateofreg", stdcourse.Dateofregister, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("student_id", stdcourse.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("course_id", stdcourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("stdcourse_package.updatestdcourse", p, commandType: CommandType.StoredProcedure);
        }

        public Stdcourse GetStdcourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("stdcourse_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Stdcourse> result = _dbConext.Connection.Query<Stdcourse>
                ("stdcourse_package.getstdcousebyid", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
