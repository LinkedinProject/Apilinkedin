using LinkedIn.core.Data;
using LinkedIn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Service
{
    public interface IuserService
    {
        public List<PostJobDTO> filers(Postedjob Postedjob);

        bool applayforjob(Jopapply jopapply);
        public bool updateimg(User user);

        public List<Postedjob> getapplyjobbycompanyid(int compid);


        public Company company(Company Company);

        public bool createcompanny(Company Company);

        //public List<userapplayedjob> GetappliedjobsBetweenDate(Jopappalydot jopappalydot);
        //public List<userapplayedjob> getuserapplayjob(int user_id);

        //public bool userjopapplay(userapplayedjob userapplayedjob);

        public User getuserid(User user);

        bool createcompanypost(Postedjob postedjop);
        public string login(userlogin userlogin);

        bool CreateCaegory(JobCtegory jobCtegory);
        bool UpdateUser(User user);
        List<PostJobDTO> latestJobs();
        List<UserApplyJobDTO> TodyAppledJobs(int userId);
        List<UserApplyJobDTO> yesterdayAppledJobs(int userId);
        List<UserApplyJobDTO> lastWeekAppledJobs(int userId);
        Total TOtaltJobs();

        bool FillEducation(Educational educational);

        List<PostJobDTO> GetByaPostedjobTitle(Postedjob postedjob);


        List<PostJobDTO> GetPostJobByDescription(string desc);
        List<Company> getAllCompanies();
        List<CategoryDTO> getAllCategories();
        List<Company> getcompanybyname(string name);
        List<JobCtegory> getcategorybyname(string name);

        bool UpdateCategory(JobCtegory jobCtegory);
        bool UpdateCompany(Company company);
        List<PostJobDTO> GetjobpostbyCatId(int id);
        PostJobDTO getjopbyPostid(int post_id);
        public bool CreateUser(User user);

        bool UpdateUser2(User user);
        bool UpdateCompany2(Company company);
        public User userbyid(int userid);

        List<PostJobDTO> jobsbyEduLevel(string edulevel_);

        List<UserApplyJobDTO> GetappliedjobsBetweenDate(Jopappalydot jopappalydot);

        bool UpdateEducatinal(Educational edu);


        bool deleteJobAplication(int j_id);



        Educational getaEducatinal(int e_id);

        List<UserApplyJobDTO> GetAllAppliedjobsOfUser(int user_id);

        ///  ------------------fillter full - onsite -------------------------------


        List<PostJobDTO> getJobByType(int ty);
        List<PostJobDTO> getJobOnsiteRemote(int ty);


        List<PostJobDTO> getJobByTypeCategory(int ty, int cid);
        List<PostJobDTO> getJobOnsiteRemoteCategory(int ty, int cid);


        ///  --------------------------------------------------------------------------
        ///   ---------------------------- --------------------------------------------------  
        ///   ---------------------------- --------------------------------------------------


        public List<contactuser> getc();
        public List<testem> testm();
        public List<testem> tbys();
        public bool insertts(testem testem);
        public bool insertpost(postuser postuser);
        public List<postuser> getpost();
        public bool insertcontact(contactuser contactuser);

        ///  --------------------------------------------------------------------------
        ///   ---------------------------- --------------------------------------------------  
        ///   ---------------------------- --------------------------------------------------
        bool insertExp(Experience experience);
        List<Experience> GetExperiences(int uid);

        ///   ------------------------------------------------------------------------------
        ///   ------------------------------------------------------------------------------
        ///   -----------------------------  User Profile ---------------------------------
        ///   ------------------------------------------------------------------------------
        ///   ------------------------------------------------------------------------------

        bool InsertRecommenndation(Recommendations recommendations);
        List<RecommendDTO> GetRecommenndationSender(int sender);
        List<RecommendDTO> GetRecommenndationResever(int resever);
        List<UserProjects> GetUserProjects(int user);
        bool addProject(UserProjects userProjects);

        public List<postuserdto> getpost2( );
        public bool likes(int xx);

        public bool dlikes(int xx);
        public bool insertcomment(comment comment)
;
        public List<commentdto> getcomments(int x);
        public testem testemonialbyid(int id);

        public bool updatecommets(comment comment);

        public bool deletecomment(int com_id);
        public bool upstatus(status status)
;
        public List<status> getstutus(status status)
;
        public bool upstatus2(status status);

    }
}
