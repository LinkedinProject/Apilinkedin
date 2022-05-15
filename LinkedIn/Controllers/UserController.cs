using LinkedIn.core.Data;
using LinkedIn.core.DTO;
using LinkedIn.core.Repository;
using LinkedIn.core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;


namespace LinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserService _userService;

        public UserController(IuserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("applayforjob")]
        public bool applayforjob(Jopapply jopapply)
        {
            return _userService.applayforjob(jopapply);
        }
        [HttpPost]
        [Route("UploadCV")]
        public User UploadCV()
        {
            try
            {
                var cv = Request.Form.Files[0];
                string cvName = Guid.NewGuid().ToString() + "-" + cv.FileName;

                var fullPath = Path.Combine("C:\\Users\\MSI\\Downloads\\final-project-front-sunday-17-4-5am\\final-project-front-sunday-17-4-5am\\src\\assets\\userimg", cvName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    cv.CopyTo(stream);
                }
                User user = new User();
                user.Imageuser = cvName;
                return user;
            }
            catch
            {
                return null;
            }

        }
        [HttpPost]
        [Route("UploadCertificate")]
        public Jopapply UploadCertificate()
        {
            try
            {
                var Certificate = Request.Form.Files[0];
                string CertificateName = Guid.NewGuid().ToString() + "-" + Certificate.FileName;

                var fullPath = Path.Combine("C:\\Users\\MSI\\Downloads\\final-project-front-sunday-17-4-5am\\final-project-front-sunday-17-4-5am\\src\\assets\\img", CertificateName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Certificate.CopyTo(stream);
                }
                Jopapply jopapply = new Jopapply();
                jopapply.Uploadcv = CertificateName;
                return jopapply;
            }
            catch
            {
                return null;
            }

        }
        //[HttpPost]
        //[ProducesResponseType(typeof(List<userapplayedjob>), StatusCodes.Status200OK)]

        //[Route("userjopapply")]

        //public bool userjopapplay([FromBody]userapplayedjob userapplayedjob)
        //{

        //    return _userService.userjopapplay(userapplayedjob);

        //}

        [HttpPost]
        [Route("companyimg")]
        public Company companyimg()
        {
            try
            {
          
                                     var Certificate = Request.Form.Files[0];
                string CertificateName = Guid.NewGuid().ToString() + "-" + Certificate.FileName;

                var fullPath = Path.Combine("C:\\Users\\MSI\\Downloads\\final-project-front-sunday-17-4-5am\\final-project-front-sunday-17-4-5am\\src\\assets\\companyimg", CertificateName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Certificate.CopyTo(stream);
                }
                Company company = new Company();
                company.Logo = CertificateName;
                return company;
            }
            catch
            {
                return null;
            }

        }

        [HttpPost]
        [Route("Regester")]
         public bool CreateUser([FromBody] User user)
        {

            return _userService.CreateUser(user);
        }
        [HttpPut]   
        [Route("updateUser")]

        public bool UpdateUser([FromBody] User user)
        {
            return _userService.UpdateUser(user);
        }


        [HttpPost]
        [Route("FillEducation")]
        public bool FillEducation([FromBody] Educational educational)
        {

            return _userService.FillEducation(educational);
        }
      
        [HttpGet]
    
        [Route("getlatestJobs")]
        [ProducesResponseType(typeof(List<Postedjob>), StatusCodes.Status200OK)]
        public List<PostJobDTO> latestJobs()
        {
            return _userService.latestJobs();
        }

        [HttpPost]
        [Route("GetByaPostedjobTitle")]
        [ProducesResponseType(typeof(List<PostJobDTO>), StatusCodes.Status200OK)]
        public List<PostJobDTO> GetByaPostedjobTitle(Postedjob postedjob)
        {
            return _userService.GetByaPostedjobTitle(postedjob);
        }

        [HttpGet]
        [Route("getTOtaltJobs")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public Total TOtaltJobs()
        {
            return _userService.TOtaltJobs();
        }


        [HttpGet]
        [Route("TodyAppledJobs/{userId}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public List<UserApplyJobDTO> TodyAppledJobs(int userId)
        {
            return _userService.TodyAppledJobs(userId);
        }


        [HttpGet]
        [Route("yesterdayAppledJobs/{userId}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public List<UserApplyJobDTO> yesterdayAppledJobs(int userId)
        {
            return _userService.yesterdayAppledJobs(userId);
        }


        [HttpGet]
        [Route("lastWeekAppledJobs/{userId}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public List<UserApplyJobDTO> lastWeekAppledJobs(int userId)
        {
            return _userService.lastWeekAppledJobs(userId);
        }


        [HttpGet]
        [Route("GetPostJobByDescription/{desc}")]
        [ProducesResponseType(typeof(List<PostJobDTO>), StatusCodes.Status200OK)]
        public List<PostJobDTO> GetPostJobByDescription(string desc)
        {
            return _userService.GetPostJobByDescription(desc);
        }
        [HttpGet]
        [Route("getAllCompanies")]
        [ProducesResponseType(typeof(List<Company>), StatusCodes.Status200OK)]
    
        public List<Company> getAllCompanies()
        {
            return _userService.getAllCompanies();
        }
        [HttpGet]
        [Route("getAllCategories")]
        [ProducesResponseType(typeof(List<CategoryDTO>), StatusCodes.Status200OK)]
        public List<CategoryDTO> getAllCategories()
        {
            return _userService.getAllCategories();
        }


        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(List<userlogin>), StatusCodes.Status200OK)]
        public string login(userlogin userlogin)
        {
            return _userService.login(userlogin);
        }

        [HttpGet]
        [Route("getcompanybyname/{name}")]
        [ProducesResponseType(typeof(List<Company>), StatusCodes.Status200OK)]
        public List<Company> getcompanybyname(string name)
        {
            return _userService.getcompanybyname(name);
        }
        [HttpGet]
        [Route("getcategorybyname/{name}")]
        [ProducesResponseType(typeof(List<JobCtegory>), StatusCodes.Status200OK)]
        public List<JobCtegory> getcategorybyname(string name)
        {
            return _userService.getcategorybyname(name);
        }

        [HttpPut]
        [Route("updateCategory")]
        public bool UpdateCategory(JobCtegory jobCtegory)
        {
            return _userService.UpdateCategory(jobCtegory);
        }

        [HttpPut]
        [Route("UpdateCompany")]
        public bool UpdateCompany(Company company)
        {
            return _userService.UpdateCompany(company);
        }

        [HttpGet]
        [Route("getjobCaegory/{id}")]
        [ProducesResponseType(typeof(List<PostJobDTO>), StatusCodes.Status200OK)]
        public List<PostJobDTO> GetjobpostbyCatId(int id)
        {
            return _userService.GetjobpostbyCatId(id);
        }


        [HttpGet]
        [Route("getjopbypostid/{post_id}")]
        [ProducesResponseType(typeof(PostJobDTO), StatusCodes.Status200OK)]
        public PostJobDTO getjopbypostid(int post_id)
        {
            return _userService.getjopbyPostid(post_id);
        }


        [HttpPost]
        [Route("userid")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public User getuserid(User user)
        {
            return _userService.getuserid(user);
        }


        [HttpPut]
        [Route("UpdateCompany2")]
        public bool UpdateCompany2(Company company)
        {
            return _userService.UpdateCompany2(company);
        }

        [HttpPut]
        [Route("updateUser2")]

        public bool UpdateUser2([FromBody] User user)
        {
            return _userService.UpdateUser2(user);
        }


        [HttpPost]
        [Route("CreateCaegory")]
        public bool CreateCaegory(JobCtegory jobCtegory)
        {
            return _userService.CreateCaegory(jobCtegory);
        }
        [HttpPost]
        [Route("createcompanypost")]
        public bool createcompanypost(Postedjob postedjob)
        {
            return _userService.createcompanypost(postedjob);
        }



        [HttpGet]
        [Route("jobsbyEduLevel/{edulevel_}")]
        [ProducesResponseType(typeof(List<PostJobDTO>), StatusCodes.Status200OK)]
        public List<PostJobDTO> jobsbyEduLevel(string edulevel_)
        {
            return _userService.jobsbyEduLevel(edulevel_);
        }


        [HttpPost]
        [Route("GetappliedjobsBetweenDate")]
        [ProducesResponseType(typeof(List<Jopapply>), StatusCodes.Status200OK)]
        public List<UserApplyJobDTO> GetappliedjobsBetweenDate([FromBody] Jopappalydot jopappalydot)
        {
            return _userService.GetappliedjobsBetweenDate(jopappalydot);

        }




        //[HttpPost]
        //[Route("GetappliedjobsBetweenDate")]

        //public List<userapplayedjob> GetappliedjobsBetweenDate(Jopappalydot jopappalydot)
        //{
        //    return _userService.GetappliedjobsBetweenDate(jopappalydot);
        //}


        //[HttpGet]
        //[Route("getuserapplayjob/{user_id}")]

        //public List<userapplayedjob> getuserapplayjob(int user_id)
        //{


        //    return _userService.getuserapplayjob(user_id);
        //}
        [HttpPost]
        [Route("createcompany")]
        public bool createcompanny(Company Company)
        {
            return _userService.createcompanny(Company);
        }
        [HttpPost]
        [Route("usercompany")]
        public Company company(Company Company)
        {


            return _userService.company(Company);

        }

        [HttpGet]
        [Route("getjobpostbycompid/{compid}")]
        public List<Postedjob> get( int compid)
        {
            return _userService.getapplyjobbycompanyid(compid);
        }


        [HttpGet]
        [Route("userid/{userid}")]
        public User userbyid(int userid)
        {
            return _userService.userbyid(userid);
        }

        [HttpPost]
        [Route("filters")]
        public List<PostJobDTO> filers(Postedjob Postedjob)
        {
            return _userService.filers(Postedjob);
        }
        [HttpPost]
        [Route("updateimg")]
        public bool updateimg(User user)
    {

        return _userService.updateimg(user);
    }


        [HttpGet]
        [Route("getaEducatinal/{e_id}")]
        public Educational getaEducatinal(int e_id)
        {
            return _userService.getaEducatinal(e_id);
        }
        [HttpGet]
        [Route("GetAllAppliedjobsOfUser/{user_id}")]
        public List<UserApplyJobDTO> GetAllAppliedjobsOfUser(int user_id)
        {
            return _userService.GetAllAppliedjobsOfUser(user_id);
        }

        [HttpPut]
        [Route("UpdateEducatinal")]
        public bool UpdateEducatinal(Educational edu)
        {
            return _userService.UpdateEducatinal(edu);
        }


        [HttpDelete]
        [Route("deleteJobAplication/{j_id}")]
        public bool deleteJobAplication(int j_id)
        {
            return _userService.deleteJobAplication(j_id);
        }


        [HttpGet]
        [Route("getJobByType/{ty}")]
        public List<PostJobDTO> getJobByType(int ty)
        {
            return _userService.getJobByType(ty);
        }
        [HttpGet]
        [Route("getJobOnsiteRemote/{ty}")]
        public List<PostJobDTO> getJobOnsiteRemote(int ty)
        {
            return _userService.getJobOnsiteRemote(ty);
        }


        [HttpGet]
        [Route("getJobByTypeCategory/{ty}/{cid}")]
        public List<PostJobDTO> getJobByTypeCategory(int ty, int cid)
        {
            return _userService.getJobByTypeCategory(ty, cid);
        }


        [HttpGet]
        [Route("getJobOnsiteRemoteCategory/{ty}/{cid}")]
        public List<PostJobDTO> getJobOnsiteRemoteCategory(int ty, int cid)
        {
            return _userService.getJobOnsiteRemoteCategory(ty, cid);
        }



        [HttpPost]
        [Route("insertExp")]
        public bool insertExp(Experience experience)
        {
            return _userService.insertExp(experience);
        }


        [HttpGet]
        [Route("GetExperiences/{uid}")]
        public List<Experience> GetExperiences(int uid)
        {
            return _userService.GetExperiences(uid);
        }


        //// ------------------------------------------------------------------------------
        ///--------------------------------------------------------------------------------
        ///--------------------------------------------------------------------------------

        [HttpGet]
        [Route("getpost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<postuser> getpost()
        {
            return _userService.getpost();
        }



        [HttpGet]
        [Route("getcomment/{x}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<commentdto> getcomments(int x)
        {
            return _userService.getcomments(x);
        }

        [HttpPost]
        [Route("updatecmment")]
        public bool updatecommets(comment comment)
        {


            return _userService.updatecommets(comment);

        }


        [HttpGet]
        [Route("getpost2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<postuserdto> getpost2()
        {
            return _userService.getpost2();
        }


        [HttpPost]
        [Route("inserttestm")]
        public bool insertts(testem testem)
        {


            return _userService.insertts(testem);

        }
        [HttpGet]
        [Route("testm")]
        public List<testem> testm()
        {
            return _userService.testm();


        }
        [HttpGet]
        [Route("testembyid")]
        public List<testem> tbys()
        {
            return _userService.tbys();


        }


        [HttpGet]
        [Route("testemonialbyid/{id}")]
        public testem testemonialbyid(int id)
        {
            return _userService.testemonialbyid(id);


        }

        [HttpPost]
        [Route("insertcontact")]
        public bool insertcontact(contactuser contactuser)
        {
            return _userService.insertcontact(contactuser);
         }


        [HttpGet]
        [Route("getc")]
        public List<contactuser> getc()
        {
            return _userService.getc();
        }
        [HttpPost]
        [Route("insertpost")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public bool insert(postuser postuser)
        {
            return _userService.insertpost(postuser);
        }

        ///   ------------------------------------------------------------------------------
        ///   ------------------------------------------------------------------------------
        ///   -----------------------------  User Profile ---------------------------------
        ///   ------------------------------------------------------------------------------
        ///   ------------------------------------------------------------------------------


        [HttpPost]
        [Route("InsertRecommenndation")]
         public bool InsertRecommenndation(Recommendations recommendations)
        {
            return _userService.InsertRecommenndation(recommendations);
        }

        [HttpGet]
        [Route("getSentRec/{sender}")]
        public List<RecommendDTO> GetRecommenndationSender(int sender)
        {
            return _userService.GetRecommenndationSender(sender);
        }


        [HttpGet]
        [Route("getresevedRec/{resever}")]
        public List<RecommendDTO> GetRecommenndationResever(int resever)
        {
            return _userService.GetRecommenndationResever(resever);
        }
        [HttpPost]
        [Route("addProject")]
        public bool addProject(UserProjects userProjects)
        {
            return _userService.addProject(userProjects);

        }

        [HttpGet]
        [Route("GetUserProjects/{user}")]
        public List<UserProjects> GetUserProjects(int user)
        {
            return _userService.GetUserProjects(user);
        }

        [HttpGet]
        [Route("like/{xx}")]
        public bool likes(int xx)
        {
            return _userService.likes(xx);
        }


        [HttpGet]
        [Route("dislike/{xx}")]
        public bool dlikes(int xx)
        {
            return _userService.dlikes(xx);


        }
        [HttpPost]
        [Route("comment")]
        public bool insertcomment(comment comment)
        {



            return _userService.insertcomment(comment);
    }


        [HttpPost]
        [Route("upstatus")]
        public bool upstatus(status status)
        {
            return _userService.upstatus(status);

        }
        [HttpPost]
        [Route("getstutus")]
        public List<status> getstutus(status status)
        {
            return _userService.getstutus(status);

        }
        [HttpPost]
        [Route("upstatus2")]
        public bool upstatus2(status status)
        {
            return _userService.upstatus2(status);


        }
        [HttpGet]
        [Route("deletecomment/{com_id}")]
        public bool deletecomment(int com_id)
        {

            return _userService.deletecomment(com_id);

        }

















    }
  




}
