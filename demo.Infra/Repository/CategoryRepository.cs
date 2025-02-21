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
   public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbConext;

        public CategoryRepository(IDbContext dbConext)
        {

            _dbConext = dbConext;

        }
        public List<Category> GetAllCategory()
        {
            IEnumerable<Category> result = _dbConext.Connection.Query<Category>
               ("category_package.GetAllcategory", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public void CreateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("category_name", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("category_package.makecategory", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("category_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("category_package.deletecategory", p, commandType: CommandType.StoredProcedure);

        }

        public void UpdateCategory(Category category)
        {
            var p = new DynamicParameters();
            p.Add("category_id", category.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("category_name", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("category_package.updatecategory", p, commandType: CommandType.StoredProcedure);
        }

        public Category GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("category_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Category> result = _dbConext.Connection.Query<Category>
                ("category_package.getcategorybyid", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

    }
}
