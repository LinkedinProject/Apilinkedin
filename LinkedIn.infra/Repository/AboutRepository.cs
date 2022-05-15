using Dapper;
using LinkedIn.core;
using LinkedIn.core.Data;
using LinkedIn.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LinkedIn.infra.Repository
{
     public class AboutRepository: IAboutRepository
    {
        private readonly IDbContext _dbContext;

        public AboutRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateAbout(Aboutu aboutu)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("A_Desc1", aboutu.Des1, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("A_Image1", aboutu.Img1, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("A_Desc2", aboutu.Des2, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("A_Image2", aboutu.Img2, dbType: DbType.String, direction: ParameterDirection.Input);
         
            _dbContext.Connection.ExecuteAsync(" aboutu_Package.Createaboutu", B, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateAbout(Aboutu aboutu)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("A_Id", aboutu.About_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            B.Add("A_Desc1", aboutu.Des1, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("A_Image1", aboutu.Img1, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("A_Desc2", aboutu.Des2, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("A_Image2", aboutu.Img2, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync(" aboutu_Package.Updateaboutu", B, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteAbout(int AboutId)
        {
            DynamicParameters T = new DynamicParameters();
            T.Add("A_Id", AboutId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("About_Package.DeleteAbout", T, commandType: CommandType.StoredProcedure);



            return true;
        }

       public List<Aboutu> GetAllAbout()
        {
            IEnumerable<Aboutu> Result = _dbContext.Connection.Query<Aboutu>("About_Package. GetAllAbout", commandType: CommandType.StoredProcedure);
            return Result.ToList();

        }

    }
}
