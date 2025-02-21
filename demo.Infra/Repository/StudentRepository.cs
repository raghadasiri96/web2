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
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContext _dbConext;

        public StudentRepository(IDbContext dbConext)
        {

            _dbConext = dbConext;

        }
        public List<Student> GeiAllStudent()
        {
            IEnumerable<Student> result = _dbConext.Connection.Query<Student>
              ("student_package.GetAllstudent", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public void CreateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("first_name", student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("last_name", student.Lasttname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("datebirth", student.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("student_package.makestudent", p, commandType: CommandType.StoredProcedure);

        }

        public void DeleteStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("student_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("student_package.deletestudent", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateStudent(Student student)
        {
            var p = new DynamicParameters();
            p.Add("student_id", student.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("first_name", student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("last_name", student.Lasttname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("datebirth", student.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("student_package.updatestudent", p, commandType: CommandType.StoredProcedure);

        }

        public Student GetStdStudentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("student_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Student> result = _dbConext.Connection.Query<Student>
                ("student_package.getstudentbyid", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public List<Student> GetStudentByFirstName(string firstName)
        {
            var p = new DynamicParameters();
            p.Add("first_name", firstName, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Student> result = _dbConext.Connection.Query<Student>
                ("student_package.GetStudentByFirstName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Student> GetStudentByBirthDate(DateTime date)
        {
            var p = new DynamicParameters();
            p.Add("datebirth", date, dbType: DbType.Date, direction: ParameterDirection.Input);

            IEnumerable<Student> result = _dbConext.Connection.Query<Student>
                ("student_package.GetStudentByBirthDate", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Student> GetStudentFNameAndLName()
        {
            IEnumerable<Student> result = _dbConext.Connection.Query<Student>
                ("student_package.GetStudentFNameAndLName", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<Student> GetStudentBetweenInterval(DateTime datefrom, DateTime dateto)
        {
            var p = new DynamicParameters();
            p.Add("datebirth", datefrom, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("datebirth", dateto, dbType: DbType.Date, direction: ParameterDirection.Input);

            IEnumerable<Student> result = _dbConext.Connection.Query<Student>
                           ("student_package.GetStudentBetweenInterval", p, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
       
    }
}
