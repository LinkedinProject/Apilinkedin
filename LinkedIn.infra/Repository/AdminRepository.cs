using Dapper;
using LinkedIn.core;
using LinkedIn.core.Data;
using LinkedIn.core.DTO;
using LinkedIn.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LinkedIn.infra.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IDbContext _dbContext;

        public AdminRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool UpdateWebsite(Website website)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@w_id", website.Websiteid, dbType: DbType.Int32);
            p.Add("@w_website_tittle", website.Website_Title, dbType: DbType.String);
            p.Add("@w_logoh", website.Logoheader, dbType: DbType.String);
            p.Add("@w_logof", website.Logofooter, dbType: DbType.String);
            p.Add("@w_heroimage", website.Heroimg, dbType: DbType.String);
            p.Add("@w_heroimage1", website.Heroimg1, dbType: DbType.String);
            _dbContext.Connection.Query<Website>("Website_Package.updateweb", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateAbout(Aboutu aboutu)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@a_id", aboutu.About_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            B.Add("@a_desc1", aboutu.Des1, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@a_image1", aboutu.Img1, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@a_desc2", aboutu.Des2, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@a_image2", aboutu.Img2, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Query<Aboutu>("about_package.updateabout", B, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateContact(Contactu contactu)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@CT_Id", contactu.Contact_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            B.Add("@C_Email", contactu.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@C_Phone", contactu.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@C_websiteid", contactu.Websiteid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Contact_Package.UpdateContact", B, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<UserApplyJobDTO> GetAllJobAppliedByDate(DatesSearch dates)
        {
            var p = new DynamicParameters();
            p.Add("@date1", dates.date1, dbType: DbType.DateTime);
            p.Add("@date2", dates.date2, dbType: DbType.DateTime);
            IEnumerable<UserApplyJobDTO> Result = _dbContext.Connection.Query<UserApplyJobDTO>("Admin.GetAllJobAppliedByDate", p, commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }
        public List<UserApplyJobDTO> GetAllJobApplied ()
        {
           
            IEnumerable<UserApplyJobDTO> Result = _dbContext.Connection.Query<UserApplyJobDTO>("Admin.GetAllJobApplied",  commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }
        public List<Company> GetAllRgisteredCompany()
        {
            IEnumerable<Company> Result = _dbContext.Connection.Query<Company>("Admin.GetAllRgisteredCompany", commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }

        public List<Company> GetAllRgisteredCompanyByDate(DatesSearch dates)
        {
            var p = new DynamicParameters();
            p.Add("@date1", dates.date1, dbType: DbType.DateTime);
            p.Add("@date2", dates.date2, dbType: DbType.DateTime);
            IEnumerable<Company> Result = _dbContext.Connection.Query<Company>("Admin.GetAllRgisteredCompanyByDate", p , commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }

        public Total GetNumOfCompanyByDate(DatesSearch dates)
        {
            var p = new DynamicParameters();
            p.Add("@date1", dates.date1, dbType: DbType.DateTime);
            p.Add("@date2", dates.date2, dbType: DbType.DateTime);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("Admin.GetNumOfCompanyByDate", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public List<User> GetAllRgisteredUsers()
        {
            IEnumerable<User> Result = _dbContext.Connection.Query<User>("Admin.GetAllRgisteredUsers", commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }

        public bool UpdateJob(Postedjob job)
        {

            var p = new DynamicParameters();
            p.Add("@POSTID_", job.Postid, dbType: DbType.Int32);
            p.Add("@JOB_TITLE_", job.Job_Title, dbType: DbType.String);
            p.Add("@DESCRIPTION_", job.description, dbType: DbType.String);
            p.Add("@DESCRIPTION_", job.description, dbType: DbType.String);
            p.Add("@EDU_LEVEL_", job.edu_Level, dbType: DbType.String);
            p.Add("@POST_DATE_", job.post_Date, dbType: DbType.DateTime);
            p.Add("@END_DATE_", job.end_Date, dbType: DbType.DateTime);
            p.Add("@SALARY_", job.salary, dbType: DbType.Int32);
            p.Add("@LOCATION_", job.location, dbType: DbType.String);
            p.Add("@COMPID_", job.compid, dbType: DbType.Int32);
             _dbContext.Connection.Query<Postedjob>("Admin.updatePostedJob", p,commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateJob2(Postedjob job)
        {
            var p = new DynamicParameters();
            p.Add("@POSTID_", job.Postid, dbType: DbType.Int32);
            p.Add("@JOB_TITLE_", job.Job_Title, dbType: DbType.String);
            p.Add("@DESCRIPTION_", job.description, dbType: DbType.String);           
            p.Add("@SALARY_", job.salary, dbType: DbType.Int32);           
            _dbContext.Connection.Query<Postedjob>("Admin.updatePostedJob2", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public Total GetNumOfJobAppliedByDate(DatesSearch dates)
        {
            var p = new DynamicParameters();
            p.Add("@date1", dates.date1, dbType: DbType.DateTime);
            p.Add("@date2", dates.date2, dbType: DbType.DateTime);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("Admin.GetNumOfJobAppliedByDate", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public List<ComanyDto> GetNumJobPostByCompany( )
        {           
            IEnumerable<ComanyDto> Result = _dbContext.Connection.Query<ComanyDto>("Admin.GetNumJobPostByCompany",   commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }

        public List<ComanyDto> GetNumJobPostByCompanyDate(DatesSearch dates)
        {
            var p = new DynamicParameters();
            p.Add("@date1", dates.date1, dbType: DbType.DateTime);
            p.Add("@date2", dates.date2, dbType: DbType.DateTime);
            IEnumerable<ComanyDto> Result = _dbContext.Connection.Query<ComanyDto>("Admin.GetNumJobPostByCompanyDate", p, commandType: CommandType.StoredProcedure);
            return Result.ToList();
        }


        public Website getWebsite(int webId)
        {
            var p = new DynamicParameters();
            p.Add("@w_id", webId, dbType: DbType.Int32);
            var Result = _dbContext.Connection.Query<Website>("website_package.getbywebid", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public Aboutu getAboutus(int abautId)
        {
            var p = new DynamicParameters();
            p.Add("@a_id", abautId, dbType: DbType.Int32);
            var Result = _dbContext.Connection.Query<Aboutu>("about_package.getabout", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public Contactu getContact(int contactId)
        {
            var p = new DynamicParameters();
            p.Add("@CT_Id", contactId, dbType: DbType.Int32);
            var Result = _dbContext.Connection.Query<Contactu>("Contact_Package.GetContact", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }
    }
}
