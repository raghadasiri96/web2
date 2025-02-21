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
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext _dbConext;

        public RoleRepository(IDbContext dbConext)
        {

            _dbConext = dbConext;

        }

        public List<Role> GeiAllRole()
        {
            IEnumerable<Role> result = _dbConext.Connection.Query<Role>
                ("role_package.GetAllrole", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public void CreateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("role_name", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("role_package.makerole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("role_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("role_package.deleterole", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("role_id", role.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("role_name", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("role_package.updaterole", p, commandType: CommandType.StoredProcedure);
        }

        public Role GetRoleById(int id)
        {
            var p = new DynamicParameters(); p.Add("role_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Role> result = _dbConext.Connection.Query<Role>
                ("role_package.getrolebyid", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

    }
}
