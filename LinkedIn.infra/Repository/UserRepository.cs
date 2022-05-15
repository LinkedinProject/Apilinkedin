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
    public class UserRepository : IuserRepository
    {

        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool applayforjob(Jopapply jopapply)
        {
            DynamicParameters B = new DynamicParameters();

           B.Add("@UPLOADCV_", jopapply.Uploadcv, dbType: DbType.String);
            //B.Add("@applaydate", jopapply.Applay_Date, dbType: DbType.Date);
            B.Add("@jobid_", jopapply.Jobid, dbType: DbType.Int32);
            B.Add("@userid_", jopapply.Userid, dbType: DbType.Int32);
            B.Add("@applicant_Name",jopapply.applicantname, dbType: DbType.String);

            B.Add("@applicant_Email", jopapply.applicantemail, dbType: DbType.String);

            B.Add("@cover_Letter", jopapply.coverletter, dbType: DbType.String);

            _dbContext.Connection.Query<Jopapply>("user_Package.applayForJob", B, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool CreateUser(User user)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@f", user.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@l", user.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@e", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@p", user.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@g", user.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@b", user.Birthdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            B.Add("@im", user.Imageuser, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@ad", user.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@r", user.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            B.Add("@pa", user.pass, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@edu", user.edu_level, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Query<User>("user_Package.signupuser", B, commandType: CommandType.StoredProcedure);
            return true;
        }




        /// /////////////// update user ////////////////////////////      
        /// /////////////// update user ////////////////////////////      
        /// /////////////// update user ////////////////////////////      

        public bool UpdateUser(User user)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@C_Id", user.Userid, dbType: DbType.Int32);
            B.Add("@C_Fname", user.Fname, dbType: DbType.String);
            B.Add("@C_Lname", user.Lname, dbType: DbType.String);
            B.Add("@C_Phone", user.Phone, dbType: DbType.String);
            B.Add("@C_Address", user.Address, dbType: DbType.String);
            _dbContext.Connection.ExecuteAsync("user_Package.UpdateUser", B, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool updateimg(User user)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@idid", user.Userid, dbType: DbType.Int32);
            B.Add("@img", user.Imageuser, dbType: DbType.String);
           
            _dbContext.Connection.ExecuteAsync("user_Package.updateimageuser", B, commandType: CommandType.StoredProcedure);
            return true;
        }







        public bool upstatus(status status)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@p", status.pos_id, dbType: DbType.Int32);
            B.Add("@u", status.use_id, dbType: DbType.Int32);

            _dbContext.Connection.ExecuteAsync("user_Package.likestutus", B, commandType: CommandType.StoredProcedure);
            return true;
        }







        public bool upstatus2(status status)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@p", status.pos_id, dbType: DbType.Int32);
            B.Add("@u", status.use_id, dbType: DbType.Int32);

            _dbContext.Connection.ExecuteAsync("user_Package.unnnlikestutus", B, commandType: CommandType.StoredProcedure);
            return true;
        }












        public List<PostJobDTO> latestJobs()
        {
            IEnumerable<PostJobDTO> result = _dbContext.Connection.Query<PostJobDTO>("user_Package.latestJobs", commandType: CommandType.StoredProcedure);
             return result.ToList();
        }










        public List<status> getstutus(status status)


        {

            DynamicParameters B = new DynamicParameters();
            B.Add("@p", status.pos_id, dbType: DbType.Int32);
            B.Add("@u", status.use_id, dbType: DbType.Int32);


            IEnumerable<status> result = _dbContext.Connection.Query<status>("user_Package.getstutus",B, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }








        public List<UserApplyJobDTO> TodyAppledJobs(int userId)
        {
            var p = new DynamicParameters();
            p.Add("@C_Id", userId, dbType: DbType.Int32);
            IEnumerable<UserApplyJobDTO> result = _dbContext.Connection.Query<UserApplyJobDTO>("user_Package.TodyAppledJobs", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<UserApplyJobDTO> yesterdayAppledJobs(int userId)
        {
            var p = new DynamicParameters();
            p.Add("@C_Id", userId, dbType: DbType.Int32);
            IEnumerable<UserApplyJobDTO> result = _dbContext.Connection.Query<UserApplyJobDTO>("user_Package.yesterdayAppledJobs", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<UserApplyJobDTO> lastWeekAppledJobs(int userId)
        {
            var p = new DynamicParameters();
            p.Add("@C_Id", userId, dbType: DbType.Int32);
            IEnumerable<UserApplyJobDTO> result = _dbContext.Connection.Query<UserApplyJobDTO>("user_Package.lastWeekAppledJobs", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Total TOtaltJobs()

        {
            var result = _dbContext.Connection.Query<Total>("user_Package.TOtaltJobs", commandType: CommandType.StoredProcedure).FirstOrDefault();
          
            return  result;
        }

      //public List  <Jopappalydot> SearchTodyAppledJobs(int Id)
      //  {
      //      var B = new DynamicParameters();
      //      B.Add("applay_date", ApplyDte, dbType: DbType.DateTime, direction: ParameterDirection.Input);
      //      IEnumerable<Jopapply> result = _dbContext.Connection.Query<Jopapply>("user_Package.TodyAppledJobs", B, commandType: CommandType.StoredProcedure);
      //      return result.ToList();
      //  }

      // public List<Jopappalydot> SearchyesterdayAppledJobs(int Id)
      //  {
      //      var B = new DynamicParameters();
      //      B.Add("applay_date",, dbType: DbType.DateTime, direction: ParameterDirection.Input);
      //      IEnumerable<Jopapply> result = _dbContext.Connection.Query<Jopapply>("user_Package. yesterdayAppledJobs", B, commandType: CommandType.StoredProcedure);
      //      return result.ToList();
      //  }
      //public  List<Jopapply> SearchlastWeekAppledJobs(int Id)
      //  {
      //      var B = new DynamicParameters();
      //      B.Add("applay_date",, dbType: DbType.DateTime, direction: ParameterDirection.Input);
      //      IEnumerable<Jopapply> result = _dbContext.Connection.Query<Jopapply>("user_Package.lastWeekAppledJobs", B, commandType: CommandType.StoredProcedure);
      //      return result.ToList();
      //  }

       public bool FillEducation(Educational educational)

        {
            DynamicParameters B = new DynamicParameters();


            B.Add("@e_university", educational.Univercity, dbType: DbType.String);
            B.Add("@e_major", educational.Major, dbType: DbType.String);

            B.Add("@e_dategrad", educational.Dategrade, dbType: DbType.Date);

            B.Add("@e_degree", educational.Degree, dbType: DbType.String);

            B.Add("@e_user_id", educational.Userid, dbType: DbType.Int32);
            _dbContext.Connection.Query<Educational>("user_Package.filleducation", B, commandType: CommandType.StoredProcedure);
            return true;
        }

            public List<PostJobDTO> GetByaPostedjobTitle(Postedjob postedjob)
        {
            var p = new DynamicParameters();
               p.Add("@JobTitle", postedjob.Job_Title, dbType: DbType.String);
            IEnumerable<PostJobDTO> result = _dbContext.Connection.Query<PostJobDTO>("user_Package.GetByappliedjobTitle", p , commandType: CommandType.StoredProcedure);
            return result.ToList();
        }




        public List<PostJobDTO> GetPostJobByDescription(string desc)
        {
            var p = new DynamicParameters();
            p.Add("@JobDesc", desc, dbType: DbType.String);
            IEnumerable<PostJobDTO> result = _dbContext.Connection.Query<PostJobDTO>("user_Package.GetPostJobByDescription", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Company> getAllCompanies()
        {
            IEnumerable<Company> result = _dbContext.Connection.Query<Company>("user_Package.getAllCompanies",  commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CategoryDTO> getAllCategories()
        {
            IEnumerable<CategoryDTO> result = _dbContext.Connection.Query<CategoryDTO>("user_Package.getAllCategories", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Company> getcompanybyname(string name)
        {
            var p = new DynamicParameters();
            p.Add("@companiesbyname_", name, dbType: DbType.String);
            IEnumerable<Company> result = _dbContext.Connection.Query<Company>("user_Package.getcompanybyname", p , commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<JobCtegory> getcategorybyname(string name)
        {
            var p = new DynamicParameters();
            p.Add("@categorybyname_", name, dbType: DbType.String);
            IEnumerable<JobCtegory> result = _dbContext.Connection.Query<JobCtegory>("user_Package.getcategorybyname", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateCategory(JobCtegory jobCtegory)
        {
            var p = new DynamicParameters();
            p.Add("@Cat_Id", jobCtegory.CategoryId, dbType: DbType.Int32);
            p.Add("@Cat_name", jobCtegory.CategoryName, dbType: DbType.String);
           _dbContext.Connection.Query<JobCtegory>("user_Package.UpdateCtegory", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        //////// insert
        //public bool userjopapplay(userapplayedjob userapplayedjob)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@userid", userapplayedjob.userid, dbType: DbType.Int32);
        //    p.Add("@dateofapply", userapplayedjob.date_of_apply, dbType: DbType.DateTime);
        //    p.Add("@compname", userapplayedjob.company_name, dbType: DbType.String);

        //    _dbContext.Connection.Query<userapplayedjob>("user_Package.useraplayed", p, commandType: CommandType.StoredProcedure);
        //    return true;
        //}

        public bool UpdateCompany(Company company)
        {
            var B = new DynamicParameters();
            B.Add("CO_Id", company.Compid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            B.Add("CO_Name", company.Compname, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("CO_Location", company.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("CO_regdate", company.registereddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            B.Add("CO_special", company.specialties, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("CO_website", company.website_url, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("CO_phone", company.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("CO_logo", company.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("CO_describ", company.Descreption, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("CO_userid", company.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            B.Add("CO_roleid", company.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Query<JobCtegory>("user_Package.UpdateCompany", B, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<PostJobDTO> GetjobpostbyCatId(int id)
        {
            var B = new DynamicParameters();
            B.Add("U_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<PostJobDTO> res = _dbContext.Connection.Query<PostJobDTO>("user_package.getjoppostbyid", B, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public bool UpdateUser2(User user)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@C_Id", user.Userid, dbType: DbType.Int32);
            B.Add("@C_Fname", user.Fname, dbType: DbType.String);
            B.Add("@C_Lname", user.Lname, dbType: DbType.String);
            B.Add("@C_Email", user.Email, dbType: DbType.String);
            _dbContext.Connection.ExecuteAsync("user_Package.UpdateUser2", B, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateCompany2(Company company)
        {
            var B = new DynamicParameters();
            B.Add("CO_Id", company.Compid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            B.Add("CO_Name", company.Compname, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("CO_Location", company.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("CO_describ", company.Descreption, dbType: DbType.String, direction: ParameterDirection.Input);
          
            _dbContext.Connection.Query<JobCtegory>("user_Package.UpdateCompany2", B, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool createcompanypost(Postedjob postedjop)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@jobtitle", postedjop.Job_Title, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@descrip", postedjop.description, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@edlevl", postedjop.edu_Level, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@postdat", postedjop.post_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            B.Add("@enddate", postedjop.end_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            B.Add("@salary", postedjop.salary, dbType: DbType.Int32, direction: ParameterDirection.Input);
            B.Add("@loc", postedjop.location, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@compid", postedjop.compid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            B.Add("@carid", postedjop.catid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Query<Postedjob>("user_Package.createcompanypost", B, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool createcompanny(Company Company)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@cname", Company.Compname, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@loc", Company.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@sp", Company.specialties, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@da", Company.registereddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            B.Add("@we", Company.website_url, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@fo", Company.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@logo", Company.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@d", Company.Descreption, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@roleid", Company.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            B.Add("@email", Company.email, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@pass", Company.pass, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Query<Company>("employers.createcompany", B, commandType: CommandType.StoredProcedure);

            return true;

        }



        public bool CreateCaegory(JobCtegory jobCtegory)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@Cat_name", jobCtegory.CategoryName , dbType: DbType.String);
            _dbContext.Connection.ExecuteAsync("user_Package.CreateCategory", B, commandType: CommandType.StoredProcedure);
            return true;
        }


        public userlogin login(userlogin userlogin)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@email", userlogin.username, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@p", userlogin.pass, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<userlogin> res = _dbContext.Connection.Query<userlogin>("user_package.userlog", B, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault();

        }

        public List<PostJobDTO> jobsbyEduLevel(string edulevel_)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@edulevel_", edulevel_, dbType: DbType.String);
           IEnumerable<PostJobDTO> res = _dbContext.Connection.Query<PostJobDTO>("user_package.jobsbyEduLevel", B, commandType: CommandType.StoredProcedure);
            return res.ToList();
        }

        //public List<Jopapply> GetappliedjobsBetweenDate(int user_id, DateTime firstdate,DateTime seconddate)
        //{
        //    DynamicParameters B = new DynamicParameters();
        //    B.Add("@p_date1",firstdate, dbType: DbType.DateTime);
        //    B.Add("@p_date2", jopappalydot.date2, dbType: DbType.DateTime);
        //    B.Add("@USER_ID", jopappalydot.userId, dbType: DbType.Int32);
        //    IEnumerable<Jopapply> res = _dbContext.Connection.Query<Jopapply>("user_package.GetappliedjobsBetweenDate", B, commandType: CommandType.StoredProcedure);
        //    return res.ToList();
        //}



        //public List<userapplayedjob> GetappliedjobsBetweenDate(Jopappalydot jopapply)
        //{
        //    DynamicParameters B = new DynamicParameters();
        //    B.Add("@userId", jopapply.userId, dbType: DbType.Int32);
        //    B.Add("@date1", jopapply.date1, dbType: DbType.DateTime);
        //    B.Add("@date2", jopapply.date2, dbType: DbType.DateTime);
        //    IEnumerable<userapplayedjob> res = _dbContext.Connection.Query<userapplayedjob>("user_package.GetappliedjobsBetweenDate", B, commandType: CommandType.StoredProcedure);
        //    return res.ToList();
        //}


        public PostJobDTO getjopbyPostid(int post_id)
        {
            var B = new DynamicParameters();
            B.Add("@post_id", post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<PostJobDTO> res = _dbContext.Connection.Query<PostJobDTO>("user_package.getjopbypostid", B, commandType: CommandType.StoredProcedure);

            return res.FirstOrDefault();
        }



        //public List< userapplayedjob>getuserapplayjob(int user_id)
        //{
        //    var B = new DynamicParameters();
        //    B.Add("@user_id", user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    IEnumerable<userapplayedjob> res = _dbContext.Connection.Query<userapplayedjob>("user_package.GET_BY_ID_USERAPLAYED", B, commandType: CommandType.StoredProcedure);

        //    return res.ToList();
        //}

        public List<Postedjob> getapplyjobbycompanyid(int compid)
        {
            var B = new DynamicParameters();
            B.Add("@comp_id", compid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Postedjob> res = _dbContext.Connection.Query<Postedjob>("employers.getapplyjobbycompanyid", B, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public User  getuserid(User user)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@username", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@userpass", user.pass, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<User> res = _dbContext.Connection.Query<User>("user_package.get_userid", B, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault();

        }



        public Company company(Company Company)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@username", Company.email, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("@userpass", Company.pass, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Company> res = _dbContext.Connection.Query<Company>("employers.get_company", B, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault();

        }

        public List<UserApplyJobDTO> GetappliedjobsBetweenDate(Jopappalydot jopappalydot)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@p_date1", jopappalydot.date1, dbType: DbType.DateTime);
            B.Add("@p_date2", jopappalydot.date2, dbType: DbType.DateTime);
            B.Add("@USER_ID", jopappalydot.userId, dbType: DbType.Int32);
            IEnumerable<UserApplyJobDTO> res = _dbContext.Connection.Query<UserApplyJobDTO>("user_package.GetappliedjobsBetweenDate", B, commandType: CommandType.StoredProcedure);
            return res.ToList();
        }


   public bool UpdateCompany(User user)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@C_Id", user.Userid, dbType: DbType.Int32);
            B.Add("@C_Fname", user.Fname, dbType: DbType.String);
            B.Add("@C_Lname", user.Lname, dbType: DbType.String);
            B.Add("@C_Email", user.Email, dbType: DbType.String);
            B.Add("@C_Phone", user.Phone, dbType: DbType.String);
            B.Add("@C_Gender", user.Gender, dbType: DbType.String);
            B.Add("@C_BirthOfDate", user.Birthdate, dbType: DbType.Date);
            B.Add("@C_ImageName", user.Imageuser, dbType: DbType.String);
            B.Add("@C_Address", user.Address, dbType: DbType.String);
            B.Add("@C_ROLE_ID", user.Roleid, dbType: DbType.Int32);
            _dbContext.Connection.ExecuteAsync("user_Package.UpdateUser", B, commandType: CommandType.StoredProcedure);
            return true;
        }


        public User userbyid(int userid)
        {
            var p = new DynamicParameters();

            p.Add("@usid", userid, dbType: DbType.Int32);
            IEnumerable<User> result = _dbContext.Connection.Query<User>("user_Package.userbyid", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public List<PostJobDTO> filers(Postedjob Postedjob)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@ids", Postedjob.catid, dbType: DbType.Int32);
            B.Add("@loc", Postedjob.location, dbType: DbType.String);
           
            IEnumerable<PostJobDTO> res = _dbContext.Connection.Query<PostJobDTO>("user_package.filters", B, commandType: CommandType.StoredProcedure);
            return res.ToList();
        }

        public bool UpdateEducatinal(Educational edu)
        {
            var B = new DynamicParameters();
            B.Add("@E_id", edu.Userid, dbType: DbType.Int32);

            B.Add("@E_Major", edu.Major, dbType: DbType.String);
            B.Add("@E_University", edu.Univercity, dbType: DbType.String);
            B.Add("@E_DateGrad", edu.Dategrade, dbType: DbType.DateTime);
            B.Add("@E_Degree", edu.Degree, dbType: DbType.String);


            _dbContext.Connection.Query<Educational>("user_Package.UpdateEducatinal", B, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool deleteJobAplication(int j_id)
        {

            var B = new DynamicParameters();
            B.Add("@E_id", j_id, dbType: DbType.Int32);
            IEnumerable<Jopapply> res = _dbContext.Connection.Query<Jopapply>("user_Package.deleteJobAplication", B, commandType: CommandType.StoredProcedure);

            return true;
        }

        public Educational getaEducatinal(int e_id)
        {
            var B = new DynamicParameters();
            B.Add("@E_id", e_id, dbType: DbType.Int32);
            IEnumerable<Educational> res = _dbContext.Connection.Query<Educational>("user_Package.getaEducatinal", B, commandType: CommandType.StoredProcedure);

            return res.FirstOrDefault();
        }

        public List<UserApplyJobDTO> GetAllAppliedjobsOfUser(int user_id)
        {
            var B = new DynamicParameters();
            B.Add("@user_Id", user_id, dbType: DbType.Int32);
            IEnumerable<UserApplyJobDTO> res = _dbContext.Connection.Query<UserApplyJobDTO>("user_Package.GetAllAppliedjobsOfUser", B, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }



        ///  ------------------fillter full - onsite -------------------------------

      
        public List<PostJobDTO> getJobByType(int ty)
        {
            var B = new DynamicParameters();
            B.Add("@ty", ty , dbType: DbType.Int32);
            IEnumerable<PostJobDTO> res = _dbContext.Connection.Query<PostJobDTO>("user_Package.getJobByType", B, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public List<PostJobDTO> getJobOnsiteRemote(int ty)
        {
            var B = new DynamicParameters();
            B.Add("@ty", ty, dbType: DbType.Int32);
            IEnumerable<PostJobDTO> res = _dbContext.Connection.Query<PostJobDTO>("user_Package.getJobOnsiteRemote", B, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }


        ///  ------------------fillter full - onsite  by category -------------------------------



        public List<PostJobDTO> getJobByTypeCategory(int ty, int cid)
        {
            var B = new DynamicParameters();
            B.Add("@ty", ty, dbType: DbType.Int32);
            B.Add("@cid", cid, dbType: DbType.Int32);
            IEnumerable<PostJobDTO> res = _dbContext.Connection.Query<PostJobDTO>("user_Package.getJobByTypeCategory", B, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public List<PostJobDTO> getJobOnsiteRemoteCategory(int ty, int cid)
        {
            var B = new DynamicParameters();
            B.Add("@ty", ty, dbType: DbType.Int32);
            B.Add("@cid", cid, dbType: DbType.Int32);
            IEnumerable<PostJobDTO> res = _dbContext.Connection.Query<PostJobDTO>("user_Package.getJobOnsiteRemoteCategory", B, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public bool insertExp(Experience experience)
        {
             var B = new DynamicParameters();
            B.Add("@E_title", experience.Jobtitle, dbType: DbType.String);
            B.Add("@E_Company", experience.Companyname, dbType: DbType.String);
            B.Add("@E_From", experience.Datefrom, dbType: DbType.DateTime);
            B.Add("@E_To", experience.Dateto, dbType: DbType.DateTime);
            B.Add("@E_UId", experience.Userid, dbType: DbType.Int32);
            B.Add("@E_Des", experience.describtion , dbType: DbType.String);
              _dbContext.Connection.Query<Experience>("user_Package.insertExp", B, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Experience> GetExperiences(int uid)
        {
            var B = new DynamicParameters();
            B.Add("@uid", uid, dbType: DbType.Int32);
            IEnumerable<Experience> res = _dbContext.Connection.Query<Experience>("user_Package.getExp", B , commandType: CommandType.StoredProcedure);

            return res.ToList();
        }


        ///   ------------------------------------------------------------------------------
        ///   ------------------------------------------------------------------------------
        ///   -----------------------------  User Profile ---------------------------------
        ///   ------------------------------------------------------------------------------
        ///   ------------------------------------------------------------------------------



        public bool InsertRecommenndation(Recommendations recommendations)
        {
            // r_sender in number , r_resever in number , r_leter in varchar
            var B = new DynamicParameters();
            B.Add("@r_sender", recommendations.Senderid, dbType: DbType.Int32);
            B.Add("@r_resever", recommendations.Reseverid, dbType: DbType.Int32);
            B.Add("@r_leter", recommendations.RecommendLeter, dbType: DbType.String);
         
            _dbContext.Connection.Query<Recommendations>("USER_PROFILE.sendRecommendstion", B, commandType: CommandType.StoredProcedure);
            
            return true;
        }

        public List<RecommendDTO> GetRecommenndationSender(int sender)
        {
            var B = new DynamicParameters();
            B.Add("@r_sender", sender, dbType: DbType.Int32);


            IEnumerable<RecommendDTO> res  =  _dbContext.Connection.Query<RecommendDTO>("USER_PROFILE.getSentRec", B, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public List<RecommendDTO> GetRecommenndationResever(int resever)
        {
            var B = new DynamicParameters();
            B.Add("@r_resever", resever, dbType: DbType.Int32);


            IEnumerable<RecommendDTO> res = _dbContext.Connection.Query<RecommendDTO>("USER_PROFILE.getresevedRec", B, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }

        public List<UserProjects> GetUserProjects(int user)
        {
            var B = new DynamicParameters();
            B.Add("@user_id", user, dbType: DbType.Int32);


            IEnumerable<UserProjects> res = _dbContext.Connection.Query<UserProjects>("USER_PROFILE.getUserProjects", B, commandType: CommandType.StoredProcedure);

            return res.ToList();
        }


        //   PROCEDURE addPjoject(user_id in number , sDate in Date , eDate in Date , des in varchar , pLink in varchar);

       public bool addProject(UserProjects userProjects)
        {
            var B = new DynamicParameters(); 
            B.Add("@user_id", userProjects.UerId, dbType: DbType.Int32);
            B.Add("@sDate", userProjects.Startdate, dbType: DbType.DateTime);
            B.Add("@eDate", userProjects.Enddate, dbType: DbType.DateTime);
            B.Add("@des", userProjects.ProDescription, dbType: DbType.String);
            B.Add("@pLink", userProjects.PROLINK, dbType: DbType.String);
            B.Add("@title_", userProjects.ProTitle, dbType: DbType.String);

            _dbContext.Connection.Query<UserProjects>("USER_PROFILE.addPjoject", B, commandType: CommandType.StoredProcedure);



            return true;
        }

        //// -------------------------------------------------------
        ///--------------------------------------------------------------

        public bool insertpost(postuser postuser)
        {
            DynamicParameters B = new DynamicParameters();


            B.Add("@fn", postuser.fname, dbType: DbType.String);
            B.Add("@d", postuser.post, dbType: DbType.DateTime);
            B.Add("@im", postuser.img, dbType: DbType.String);

            B.Add("@des", postuser.describ, dbType: DbType.String);

            B.Add("@ud", postuser.userid, dbType: DbType.Int32);

            _dbContext.Connection.Query<postuser>("user_Package.insertpost", B, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool insertcontact(contactuser contactuser)
        {
            DynamicParameters B = new DynamicParameters();


            B.Add("@f", contactuser.fname, dbType: DbType.String);
            B.Add("@e", contactuser.email, dbType: DbType.String);
            B.Add("@s", contactuser.subject, dbType: DbType.String);

            B.Add("@m", contactuser.message, dbType: DbType.String);


            _dbContext.Connection.Query<postuser>("user_package.contactususer", B, commandType: CommandType.StoredProcedure);
            return true;
        }




        public bool insertts(testem testem)
        {
            DynamicParameters B = new DynamicParameters();


            B.Add("@f", testem.fname, dbType: DbType.String);
            B.Add("@e", testem.email, dbType: DbType.String);
            B.Add("@m", testem.message, dbType: DbType.String);
            B.Add("@s", testem.stutus, dbType: DbType.String);

            B.Add("@u", testem.userid, dbType: DbType.Int32);
            B.Add("@i", testem.img, dbType: DbType.String);
            B.Add("@r", testem.rete, dbType: DbType.Int32);
            B.Add("@st", testem.stu, dbType: DbType.Int32);


            _dbContext.Connection.Query<postuser>("user_package.inserttestm", B, commandType: CommandType.StoredProcedure);
            return true;
        }






        public bool insertcomment(comment comment)
        {
            DynamicParameters B = new DynamicParameters();


            B.Add("@usid", comment.userid, dbType: DbType.Int32);
            B.Add("@com", comment.comments, dbType: DbType.String);
            B.Add("@dt", comment.dates, dbType: DbType.DateTime);
            B.Add("@pid", comment.postid, dbType: DbType.Int32);

           


            _dbContext.Connection.Query<comment>("user_package.insertcomment", B, commandType: CommandType.StoredProcedure);
            return true;
        }








        public List<testem> testm()

        {
            IEnumerable<testem> result = _dbContext.Connection.Query<testem>("user_Package.gettest",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }





        public testem testemonialbyid(int id)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<testem> result = _dbContext.Connection.Query<testem>("user_Package.gettestbyuserid", B,
                commandType: CommandType.StoredProcedure);
             return result.FirstOrDefault(); 
        
        
        
        }

          
          
            
            
        

        public List<testem> tbys()
        {
            IEnumerable<testem> result = _dbContext.Connection.Query<testem>("user_Package.gettestbystate", 
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public List<contactuser> getc()
        {
            IEnumerable<contactuser> result = _dbContext.Connection.Query<contactuser>("user_Package.getcontact", 
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<postuser> getpost()
        {
            IEnumerable<postuser> result = _dbContext.Connection.Query<postuser>("user_package.getpost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<postuserdto> getpost2()
        {
            IEnumerable<postuserdto> result = _dbContext.Connection.Query<postuserdto>("user_package.getpost2", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public bool likes(int xx)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@x", xx, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.Query<postuser>("user_package.likes",B, commandType: CommandType.StoredProcedure);
            return true;
        }



        public bool dlikes(int xx)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@x", xx, dbType: DbType.Int32, direction: ParameterDirection.Input);


            _dbContext.Connection.Query<postuser>("user_package.dislike", B, commandType: CommandType.StoredProcedure);
            return true;
        }






        public bool updatecommets(comment comment)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@c_id", comment.com_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            B.Add("@co", comment.comments, dbType: DbType.String, direction: ParameterDirection.Input);

            _dbContext.Connection.Query<comment>("user_package.updatecomment", B, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool deletecomment(int com_id)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@c_id", com_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

          

            _dbContext.Connection.Query<comment>("user_package.deletecomment", B, commandType: CommandType.StoredProcedure);
            return true;
        }


        public List<commentdto> getcomments(int x)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@x",x, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<commentdto> result = _dbContext.Connection.Query<commentdto>("user_Package.getcomments", B,commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }



}
