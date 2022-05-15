using LinkedIn.core.Data;
using LinkedIn.core.DTO;
using LinkedIn.core.Repository;
using LinkedIn.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.infra.Service
{
    public class EmpService : IEmpService
    {
        private readonly IEmpRepository _empRepository;

        public EmpService(IEmpRepository empRepository)
        {
            _empRepository = empRepository;
        }
        public bool createcompanypost(Postedjob postedjob)
        {
            return _empRepository.createcompanypost(postedjob);
        }
        public Company get_companybyId(int comp_id)
        {
            return _empRepository.get_companybyId(comp_id);
        }
        public List<PostJobDTO> getAllCompPost(int comp_id)
        {

            return _empRepository.getAllCompPost(comp_id);
        }


        public bool delcompanypost(int postid)
        {
            return _empRepository.delcompanypost(postid);

        }

        public bool updatecompanypost(Postedjob postedjop)
        {
            return _empRepository.updatecompanypost(postedjop);

        }

      public  List<CompanyApplyDTO> getApplyedOfjobPost(int job_id)
        {
            return _empRepository.getApplyedOfjobPost(job_id);
        }

        public bool acceptApplicant(int job_id)
        {
            return _empRepository.acceptApplicant(job_id);
        }

        public bool rejectApplicant(int job_id)
        {
            return _empRepository.rejectApplicant(job_id);
        }

        public List<CompanyApplyDTO> getApplyedOfjobPostbetweenDate(ApplyDatesCompany datesSearch)
        {
            return _empRepository.getApplyedOfjobPostbetweenDate(datesSearch);
        }





        /// //////////////////////
        /// //////////////////////
        /// All        /// 
        /// //////////////////////
        /// //////////////////////
        public Total numberOfJobAcceptedApplicants(int comp_id)
        {
            return _empRepository.numberOfJobAcceptedApplicants(comp_id);
        }

        public Total numberOfJobRejectedApplicants(int comp_id)
        {
            return _empRepository.numberOfJobRejectedApplicants(comp_id);
        }




        public Total AllOfJobApplicants(int comp_id)
        {
            return _empRepository.AllOfJobApplicants(comp_id);

        }











        /// //////////////////////
        /// //////////////////////
        /// Reports        /// 
        /// //////////////////////
        /// //////////////////////



        /// //////////////////////
        /// //////////////////////
        /// 2022       /// 
        /// //////////////////////
        /// //////////////////////

        public Total AnnualnumberOfJobApplicants22(int comp_id)
        {
            return _empRepository.AnnualnumberOfJobApplicants22(comp_id);
        }

        public Total AnnualnumberOfJobAcceptedApplicants22(int comp_id)
        {
            return _empRepository.AnnualnumberOfJobAcceptedApplicants22(comp_id);
        }

        public Total AnnualnumberOfJobRejectedApplicants22(int comp_id)
        {
            return _empRepository.AnnualnumberOfJobRejectedApplicants22(comp_id);
        }

        /// //////////////////////
        /// //////////////////////
        /// 2021       /// 
        /// //////////////////////
        /// //////////////////////


        public Total AnnualnumberOfJobApplicants21(int comp_id)
        {
            return _empRepository.AnnualnumberOfJobApplicants21(comp_id);
        }

        public Total AnnualnumberOfJobAcceptedApplicants21(int comp_id)
        {
            return _empRepository.AnnualnumberOfJobAcceptedApplicants21(comp_id);
        }

        public Total AnnualnumberOfJobRejectedApplicants21(int comp_id)
        {
            return _empRepository.AnnualnumberOfJobRejectedApplicants21(comp_id);
        }


        /// //////////////////////
        /// //////////////////////
        /// 2020        /// 
        /// //////////////////////
        /// //////////////////////



        public Total AnnualnumberOfJobApplicants20(int comp_id)
        {
            return _empRepository.AnnualnumberOfJobApplicants20(comp_id);
        }

        public Total AnnualnumberOfJobAcceptedApplicants20(int comp_id)
        {
            return _empRepository.AnnualnumberOfJobAcceptedApplicants20(comp_id);
        }

        public Total AnnualnumberOfJobRejectedApplicants20(int comp_id)
        {
            return _empRepository.AnnualnumberOfJobRejectedApplicants20(comp_id);

        }









        /// //////////////////////
        /// //////////////////////
        /// monthly report    /// 
        /// //////////////////////
        /// //////////////////////

        public Total numberOfJobApplicantsm1(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm1(comp_id);
        }



        public Total numberOfJobApplicantsm2(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm2(comp_id);
        }


        public Total numberOfJobApplicantsm3(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm3(comp_id);
        }


        public Total numberOfJobApplicantsm4(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm4(comp_id);
        }


        public Total numberOfJobApplicantsm5(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm5(comp_id);
        }


        public Total numberOfJobApplicantsm6(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm6(comp_id);
        }


        public Total numberOfJobApplicantsm7(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm7(comp_id);
        }


        public Total numberOfJobApplicantsm8(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm8(comp_id);
        }


        public Total numberOfJobApplicantsm9(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm9(comp_id);
        }


        public Total numberOfJobApplicantsm10(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm10(comp_id);
        }


        public Total numberOfJobApplicantsm11(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm11(comp_id);
        }


        public Total numberOfJobApplicantsm12(int comp_id)
        {
            return _empRepository.numberOfJobApplicantsm12(comp_id);
        }
    }
}
