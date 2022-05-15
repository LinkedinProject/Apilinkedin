using LinkedIn.core.Data;
using LinkedIn.core.DTO;
using LinkedIn.core.Service;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;



namespace LinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmpService _empService;

        public EmpController(IEmpService empService)
        {
            _empService = empService;
        }

        ////////// create 


        [HttpPost]
        [Route("postAJob")]
        public bool createcompanypost(Postedjob postedjop)
        {
            return _empService.createcompanypost(postedjop);
        }





        ////////////// update 



        [HttpPut]
        [Route("updateAJob")]
        public bool updatecompanypost(Postedjob postedjop)
        {
            return _empService.updatecompanypost(postedjop);
        }


        [HttpGet]
        [Route("getAllCompPost/{comp_id}")]
        public List<PostJobDTO> getAllCompPost(int comp_id)
        {
            return _empService.getAllCompPost(comp_id);
        }


        [HttpGet]
        [Route("getcompanybyId/{comp_id}")]
        public Company get_companybyId(int comp_id)
        {
            return _empService.get_companybyId(comp_id);
        }



        ////////////// delete


        [HttpDelete]
        [Route("deletAJob/{postedid}")]
        public bool delcompanypost(int postedid)
        {
            return _empService.delcompanypost(postedid);
        }


        //////
        [HttpGet]
        [Route("getApplyedOfjobPost/{job_id}")]
        public List<CompanyApplyDTO> getApplyedOfjobPost(int job_id)
        {
            return _empService.getApplyedOfjobPost(job_id);
        }







        [HttpGet]
        [Route("acceptApplicant/{job_id}")]
        public bool acceptApplicant(int job_id)
        {
            return _empService.acceptApplicant(job_id);
        }
        [HttpGet]
        [Route("rejectApplicant/{job_id}")]
        public bool rejectApplicant(int job_id)
        {
            return _empService.rejectApplicant(job_id);
        }




        [HttpPost]
        [Route("getApplyedOfjobPostbetweenDate")]
        public List<CompanyApplyDTO> getApplyedOfjobPostbetweenDate(ApplyDatesCompany datesSearch)
        {
            return _empService.getApplyedOfjobPostbetweenDate(datesSearch);
        }





        /// //////////////////////
        /// //////////////////////
        /// All        /// 
        /// //////////////////////
        /// //////////////////////


        [HttpGet]
        [Route("AllOfJobApplicants/{comp_id}")]
        public Total AllOfJobApplicants(int comp_id)
        {
            return _empService.AllOfJobApplicants(comp_id);
        }




        [HttpGet]
        [Route("numberOfJobAcceptedApplicants/{comp_id}")]
        public Total numberOfJobAcceptedApplicants(int comp_id)
        {
            return _empService.numberOfJobAcceptedApplicants(comp_id);
        }


        [HttpGet]
        [Route("numberOfJobRejectedApplicants/{comp_id}")]
        public Total numberOfJobRejectedApplicants(int comp_id)
        {
            return _empService.numberOfJobRejectedApplicants(comp_id);
        }

















        /// //////////////////////
        /// //////////////////////
        /// Reports        /// 
        /// //////////////////////
        /// //////////////////////



        [HttpGet]
        [Route("AnnualAllJobApplicants22/{comp_id}")]
        public Total AnnualnumberOfJobApplicants22(int comp_id)
        {
            return _empService.AnnualnumberOfJobApplicants22(comp_id);
        }


        [HttpGet]
        [Route("AnnualAcceptedApplicants22/{comp_id}")]
        public Total AnnualnumberOfJobAcceptedApplicants22(int comp_id)
        {
            return _empService.AnnualnumberOfJobAcceptedApplicants22(comp_id);
        }


        [HttpGet]
        [Route("AnnualRejectedApplicants22/{comp_id}")]
        public Total AnnualnumberOfJobRejectedApplicants22(int comp_id)
        {
            return _empService.AnnualnumberOfJobRejectedApplicants22(comp_id);
        }











        [HttpGet]
        [Route("AnnualAllJobApplicants21/{comp_id}")]
        public Total AnnualnumberOfJobApplicants21(int comp_id)
        {
            return _empService.AnnualnumberOfJobApplicants21(comp_id);
        }



        [HttpGet]
        [Route("AnnualAcceptedApplicants21/{comp_id}")]
        public Total AnnualnumberOfJobAcceptedApplicants21(int comp_id)
        {
            return _empService.AnnualnumberOfJobAcceptedApplicants21(comp_id);
        }


        [HttpGet]
        [Route("AnnualRejectedApplicants21/{comp_id}")]
        public Total AnnualnumberOfJobRejectedApplicants21(int comp_id)
        {
            return _empService.AnnualnumberOfJobRejectedApplicants21(comp_id);
        }




        [HttpGet]
        [Route("AnnualAllJobApplicants20/{comp_id}")]
        public Total AnnualnumberOfJobApplicants20(int comp_id)
        {
            return _empService.AnnualnumberOfJobApplicants20(comp_id);
        }


        [HttpGet]
        [Route("AnnualAcceptedApplicants20/{comp_id}")]
        public Total AnnualnumberOfJobAcceptedApplicants20(int comp_id)
        {
            return _empService.AnnualnumberOfJobAcceptedApplicants20(comp_id);
        }


        [HttpGet]
        [Route("AnnualRejectedApplicants20/{comp_id}")]
        public Total AnnualnumberOfJobRejectedApplicants20(int comp_id)
        {
            return _empService.AnnualnumberOfJobRejectedApplicants20(comp_id);
        }




        /// //////////////////////
        /// //////////////////////
        /// monthly report    /// 
        /// //////////////////////
        /// //////////////////////

        [HttpGet]
        [Route("numberOfJobApplicantsm1/{comp_id}")]
        public Total numberOfJobApplicantsm1(int comp_id)
        {
            return _empService.numberOfJobApplicantsm1(comp_id);
        }

        [HttpGet]
        [Route("numberOfJobApplicantsm2/{comp_id}")]
        public Total numberOfJobApplicantsm2(int comp_id)
        {
            return _empService.numberOfJobApplicantsm2(comp_id);
        }

        [HttpGet]
        [Route("numberOfJobApplicantsm3/{comp_id}")]
        public Total numberOfJobApplicantsm3(int comp_id)
        {
            return _empService.numberOfJobApplicantsm3(comp_id);
        }

        [HttpGet]
        [Route("numberOfJobApplicantsm4/{comp_id}")]
        public Total numberOfJobApplicantsm4(int comp_id)
        {
            return _empService.numberOfJobApplicantsm4(comp_id);
        }

        [HttpGet]
        [Route("numberOfJobApplicantsm5/{comp_id}")]
        public Total numberOfJobApplicantsm5(int comp_id)
        {
            return _empService.numberOfJobApplicantsm5(comp_id);
        }

        [HttpGet]
        [Route("numberOfJobApplicantsm6/{comp_id}")]
        public Total numberOfJobApplicantsm6(int comp_id)
        {
            return _empService.numberOfJobApplicantsm6(comp_id);
        }

        [HttpGet]
        [Route("numberOfJobApplicantsm7/{comp_id}")]
        public Total numberOfJobApplicantsm7(int comp_id)
        {
            return _empService.numberOfJobApplicantsm7(comp_id);
        }

        [HttpGet]
        [Route("numberOfJobApplicantsm8/{comp_id}")]
        public Total numberOfJobApplicantsm8(int comp_id)
        {
            return _empService.numberOfJobApplicantsm8(comp_id);
        }

        [HttpGet]
        [Route("numberOfJobApplicantsm9/{comp_id}")]
        public Total numberOfJobApplicantsm9(int comp_id)
        {
            return _empService.numberOfJobApplicantsm9(comp_id);
        }

        [HttpGet]
        [Route("numberOfJobApplicantsm10/{comp_id}")]
        public Total numberOfJobApplicantsm10(int comp_id)
        {
            return _empService.numberOfJobApplicantsm10(comp_id);
        }

        [HttpGet]
        [Route("numberOfJobApplicantsm11/{comp_id}")]
        public Total numberOfJobApplicantsm11(int comp_id)
        {
            return _empService.numberOfJobApplicantsm11(comp_id);
        }

        [HttpGet]
        [Route("numberOfJobApplicantsm12/{comp_id}")]
        public Total numberOfJobApplicantsm12(int comp_id)
        {
            return _empService.numberOfJobApplicantsm12(comp_id);
        }



        /////////////////////// Email /////////////// 
        [HttpPost]
        [Route("SendEmail")]
        public bool SendEmail([FromBody] Email email)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new
            MailboxAddress(email.company,
            email.From);
            message.From.Add(from);


            MailboxAddress to = new
            MailboxAddress(email.user,
            "" + email.to + "");
            message.To.Add(to);
            message.Subject = email.subject;
            BodyBuilder bodyBuilder = new
            BodyBuilder();
            bodyBuilder.HtmlBody = email.message;
           
            message.Body =
            bodyBuilder.ToMessageBody();
            //            var file = Request.Form.Files[0];
            //            if (file != null)
            //            {
            //                var filename = Guid.NewGuid().ToString() + "." + file.FileName;
            //                var fullpath =
            //                Path.Combine(@"C:\Users\twist\Desktop\Tahaluf.LMS\Tahaluf.LMS\Tahaluf.LMS.API\Attatchm
            //ents\" +
            //                filename);
            //                using (var stream = new FileStream(fullpath,
            //                FileMode.Create))
            //                {
            //                    file.CopyTo(stream);
            //                    bodyBuilder.Attachments.Add(file.FileName, stream);
            //                }
            //                message.To.Add(to);
            //                message.Body = bodyBuilder.ToMessageBody();


            using (var clinte = new SmtpClient())
            {
                clinte.Connect("smtp.gmail.com", 587, false);
                clinte.Authenticate(email.From,
                email.password);
                clinte.Send(message);
                clinte.Disconnect(true);
            }
            return true;



            
            //return true;

        }
    }
}