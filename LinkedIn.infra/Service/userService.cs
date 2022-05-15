using LinkedIn.core.Data;
using LinkedIn.core.DTO;
using LinkedIn.core.Repository;
using LinkedIn.core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LinkedIn.infra.Service{   

   public class userService : IuserService
    {

        private readonly IuserRepository _userRepository;

        public userService(IuserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool updateimg(User user)
        {

             return _userRepository.updateimg(user);
        }

        public bool CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public List<PostJobDTO> filers(Postedjob Postedjob)
        {
            return _userRepository.filers(Postedjob);
        }
        public  bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
        public List<PostJobDTO> latestJobs()
        {
            return _userRepository.latestJobs();
        }
      public Total TOtaltJobs()
        {
            return _userRepository.TOtaltJobs();
        }
      public  List<PostJobDTO> GetByaPostedjobTitle(Postedjob postedjob)
        {
            return _userRepository.GetByaPostedjobTitle(postedjob);
        }

        //public  List<Jopappalydot> SearchTodyAppledJobs(int Id)
        //  {
        //      return _userRepository.SearchTodyAppledJobs(Id);
        //  }
        // public List<Jopappalydot> SearchyesterdayAppledJobs(int Id)
        //  {
        //      return _userRepository.SearchTodyAppledJobs(Id);
        //  }
        // public List<Jopappalydot> SearchlastWeekAppledJobs(int Id)
        //  {
        //      return _userRepository.SearchlastWeekAppledJobs(Id);
        //  }
        public bool FillEducation(Educational educational)
        {
            return _userRepository.FillEducation(educational);
        }

        public List<UserApplyJobDTO> TodyAppledJobs(int userId)
        {
            return _userRepository.TodyAppledJobs(userId);
        }

        public List<UserApplyJobDTO> yesterdayAppledJobs(int userId)
        {
            return _userRepository.yesterdayAppledJobs(userId);
        }

        public List<UserApplyJobDTO> lastWeekAppledJobs(int userId)
        {
            return _userRepository.lastWeekAppledJobs(userId);
        }

        public List<PostJobDTO> GetPostJobByDescription(string desc)
        {
            return _userRepository.GetPostJobByDescription(desc);
        }

        public List<Company> getAllCompanies()
        {
            return _userRepository.getAllCompanies();
        }

        public List<CategoryDTO> getAllCategories()
        {
            return _userRepository.getAllCategories();
        }

        public List<Company> getcompanybyname(string name)
        {
            return _userRepository.getcompanybyname(name);
        }

        public List<JobCtegory> getcategorybyname(string name)
        {
            return _userRepository.getcategorybyname(name);
        }
        public bool createcompanny(Company Company)
        {
            return _userRepository.createcompanny(Company);
        }
        public Company company(Company Company)
        {


            return _userRepository.company(Company);

        }
        public List<Postedjob> getapplyjobbycompanyid(int compid)
        {

            return _userRepository.getapplyjobbycompanyid(compid);
        }

        public bool UpdateCategory(JobCtegory jobCtegory)
        {

            return _userRepository.UpdateCategory(jobCtegory);
        }

        public bool UpdateCompany(Company company)
        {
            return _userRepository.UpdateCompany(company);
        }
        //public List<userapplayedjob> GetappliedjobsBetweenDate(Jopappalydot jopappalydot)
        //{

        //    return _userRepository.GetappliedjobsBetweenDate(jopappalydot);
        //}



        // public List<Postedjob> GetappliedjobsBetweenDate(DateTime P_date1, DateTime P_date2)
        //  {
        //      return _userRepository.GetappliedjobsBetweenDate( P_date1, P_date2);
        //  }
        //public  List<Postedjob> GetJobByName(Postedjob postedjob)
        //  {
        //      return _userRepository.GetJobByName(postedjob);
        //  }

        public List<PostJobDTO> GetjobpostbyCatId(int id)
        {
            return _userRepository.GetjobpostbyCatId(id);
        }

        public bool UpdateUser2(User user)
        {
            return _userRepository.UpdateUser2(user);
        }

        public bool UpdateCompany2(Company company)
        {
            return _userRepository.UpdateCompany2(company);
        }

        public bool CreateCaegory(JobCtegory jobCtegory)
        {
            return _userRepository.CreateCaegory(jobCtegory);
        }

       public bool createcompanypost(Postedjob postedjob)
        {

            return _userRepository.createcompanypost(postedjob);
        }

        public bool CreateUsers(User user)
        {

            return _userRepository.CreateUser(user);


        }
        public User getuserid(User user)
        {

            return _userRepository.getuserid(user);
        }


        //public bool userjopapplay(userapplayedjob userapplayedjob)
        //{

        //    return _userRepository.userjopapplay(userapplayedjob);

        //}


        public string login(userlogin userlogin)
        {
            var result= _userRepository.login(userlogin);

            if (result == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]");   
         
               
         
                
              var tokenDescriptor = new SecurityTokenDescriptor

              {
                  Subject = new ClaimsIdentity(new Claim[]
{
        new Claim(ClaimTypes.Name, result.username),
          new Claim(ClaimTypes.Role, result.roleid.ToString()),
}),
                  Expires = DateTime.UtcNow.AddHours(1),
                  SigningCredentials = new SigningCredentials(new
        SymmetricSecurityKey(tokenKey),
        SecurityAlgorithms.HmacSha256Signature)
              };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }

        public List<PostJobDTO> jobsbyEduLevel(string edulevel_)
        {
            return _userRepository.jobsbyEduLevel(edulevel_);
        }

        public List<UserApplyJobDTO> GetappliedjobsBetweenDate(Jopappalydot jopappalydot)
        {
            return _userRepository.GetappliedjobsBetweenDate(jopappalydot);
        }

        public PostJobDTO getjopbyPostid(int post_id)
        {
            return _userRepository.getjopbyPostid(post_id);
         }

        public bool applayforjob(Jopapply jopapply)
        {
            return _userRepository.applayforjob(jopapply);
        }

        public User userbyid(int userid)
        {
            return _userRepository.userbyid(userid);
        }

        public Educational getaEducatinal(int e_id)
        {
            return _userRepository.getaEducatinal(e_id);
        }

        public List<UserApplyJobDTO> GetAllAppliedjobsOfUser(int user_id)
        {
            return _userRepository.GetAllAppliedjobsOfUser(user_id);
        }

        public bool UpdateEducatinal(Educational edu)
        {
            return _userRepository.UpdateEducatinal(edu);
        }

        public bool deleteJobAplication(int j_id)
        {
            return _userRepository.deleteJobAplication(j_id);
        }

        public List<PostJobDTO> getJobByType(int ty)
        {
            return _userRepository.getJobByType(ty);
        }

        public List<PostJobDTO> getJobOnsiteRemote(int ty)
        {
            return _userRepository.getJobOnsiteRemote(ty);
        }



        public List<PostJobDTO> getJobByTypeCategory(int ty, int cid)
        {
            return _userRepository.getJobByTypeCategory( ty,  cid);
        }

        public List<PostJobDTO> getJobOnsiteRemoteCategory(int ty, int cid)
        {
            return _userRepository.getJobOnsiteRemoteCategory( ty,  cid);
        }

        public bool insertExp(Experience experience)
        {
            return _userRepository.insertExp(experience);
        }

        public List<Experience> GetExperiences(int uid)
        {
            return _userRepository.GetExperiences(uid);
        }

        /// ----------------------------------------------------------------------------------
        /// --------------------------------------------------------------------------------
        /// ------------------------------------------------------------------------------

        public List<testem> testm()
        {
            return _userRepository.testm();

        }
        public List<testem> tbys()
        {
            return _userRepository.tbys();

        }

        public bool insertts(testem testem)
        {

            return _userRepository.insertts(testem);

        }
        public List<contactuser> getc()
        {

            return _userRepository.getc();
        }



        public List<postuser> getpost()
        {

            return _userRepository.getpost();


        }
        public bool insertpost(postuser postuser)
        {
            return _userRepository.insertpost(postuser);


        }
        public bool insertcontact(contactuser contactuser)
        {
            return _userRepository.insertcontact(contactuser);


        }

        ///   ------------------------------------------------------------------------------
        ///   ------------------------------------------------------------------------------
        ///   -----------------------------  User Profile ---------------------------------
        ///   ------------------------------------------------------------------------------
        ///   ------------------------------------------------------------------------------

        public bool InsertRecommenndation(Recommendations recommendations)
        {
            return _userRepository.InsertRecommenndation(recommendations);
        }

        public List<RecommendDTO> GetRecommenndationSender(int sender)
        {
            return _userRepository.GetRecommenndationSender(sender);
        }

        public List<RecommendDTO> GetRecommenndationResever(int resever)
        {
            return _userRepository.GetRecommenndationResever(resever);
        }
        public List<UserProjects> GetUserProjects(int user)
        {
            return _userRepository.GetUserProjects(user);
        }

        public bool addProject(UserProjects userProjects)
        {
            return _userRepository.addProject(userProjects);

        }
        public List<postuserdto> getpost2()
        {


            return _userRepository.getpost2();

        }
        public bool likes(int xx)
        {


            return _userRepository.likes(xx);
        }
        public bool dlikes(int xx)
        {

            return _userRepository.dlikes(xx);

        }
        public bool insertcomment(comment comment)
        {

            return _userRepository.insertcomment(comment);
        }
        public List<commentdto> getcomments(int x)
        {

            return _userRepository.getcomments(x);


        }
        public testem testemonialbyid(int id)
        {
            return _userRepository.testemonialbyid(id);

        }




        public bool upstatus(status status)
        {
            return _userRepository.upstatus(status);

        }

        public List<status> getstutus(status status)
        {
            return _userRepository.getstutus( status);

        }

        public bool upstatus2(status status)
        {
            return _userRepository.upstatus2(status);


        }


        public bool updatecommets(comment comment)
        {
            return _userRepository.updatecommets(comment);

        }


        public bool deletecomment(int com_id)
        {

            return _userRepository.deletecomment(com_id);

        }


    }
}
