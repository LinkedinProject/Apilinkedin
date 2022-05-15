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
    public class Website_Repository : IWebsiteRepository
    {
        private readonly IDbContext _dbContext;

        public Website_Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateWebsite(Website website)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("W_Website_tittle", website.Website_Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("W_LogoH", website.Logoheader, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("W_LogoF", website.Logofooter, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("W_HeroImage", website.Heroimg, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("W_HeroImage1", website.Heroimg1, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync(" Website_Package.CreateWeb", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteWebsite(int id)
        {
            DynamicParameters T = new DynamicParameters();
            T.Add("W_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Website_Package.DeleteWeb", T, commandType: CommandType.StoredProcedure);



            return true;
        }

        public List<Website> GetAllWebsite()
        {
            IEnumerable<Website> result = _dbContext.Connection.Query<Website>("Website_Package.GetAllWeb", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateWebsite(Website website)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("W_Id", website.Websiteid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("W_Website_tittle", website.Website_Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("W_LogoH", website.Logoheader, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("W_LogoF", website.Logofooter, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("W_HeroImage", website.Heroimg, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("W_HeroImage1", website.Heroimg1, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync(" Website_Package.UpdateWeb", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
