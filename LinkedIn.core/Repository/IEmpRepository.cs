using LinkedIn.core.Data;
using LinkedIn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedIn.core.Repository
{
    public interface IEmpRepository
    {
        public List<PostJobDTO> getAllCompPost(int comp_id);
        Company get_companybyId(int comp_id);
        bool createcompanypost(Postedjob postedjob);
        bool updatecompanypost(Postedjob postedjop);
        bool delcompanypost(int postid);

        List<CompanyApplyDTO> getApplyedOfjobPost(int job_id);
        bool acceptApplicant(int job_id);
        bool rejectApplicant(int job_id);

       List<CompanyApplyDTO> getApplyedOfjobPostbetweenDate(ApplyDatesCompany datesSearch);



        ///////////////////////////////////////////////
        //////////////////////////////////////////////
        //////////////////////////////////////////////
        /////////////// All  ////////////////
        /////////////////////////////////////////////
        ////////////////////////////////////////////


        Total AllOfJobApplicants (int comp_id);
        Total numberOfJobAcceptedApplicants(int comp_id);
        Total numberOfJobRejectedApplicants(int comp_id);

        ///////////////////////////////////////////////
        //////////////////////////////////////////////
        //////////////////////////////////////////////
        /////////////// month report ////////////////
        /////////////////////////////////////////////
        ////////////////////////////////////////////
        Total numberOfJobApplicantsm1(int comp_id);
        Total numberOfJobApplicantsm2(int comp_id);
        Total numberOfJobApplicantsm3(int comp_id);
        Total numberOfJobApplicantsm4(int comp_id);
        Total numberOfJobApplicantsm5(int comp_id);
        Total numberOfJobApplicantsm6(int comp_id);
        Total numberOfJobApplicantsm7(int comp_id);
        Total numberOfJobApplicantsm8(int comp_id);
        Total numberOfJobApplicantsm9(int comp_id);
        Total numberOfJobApplicantsm10(int comp_id);
        Total numberOfJobApplicantsm11(int comp_id);
        Total numberOfJobApplicantsm12(int comp_id);












        /// //////////////////////
        /// //////////////////////
        /// Reports        /// 
        /// //////////////////////
        /// //////////////////////
        /// 
        Total AnnualnumberOfJobApplicants22(int comp_id);
        Total AnnualnumberOfJobAcceptedApplicants22(int comp_id);
        Total AnnualnumberOfJobRejectedApplicants22(int comp_id);

        Total AnnualnumberOfJobApplicants21(int comp_id);
        Total AnnualnumberOfJobAcceptedApplicants21(int comp_id);
        Total AnnualnumberOfJobRejectedApplicants21(int comp_id);

        Total AnnualnumberOfJobApplicants20(int comp_id);
        Total AnnualnumberOfJobAcceptedApplicants20(int comp_id);
        Total AnnualnumberOfJobRejectedApplicants20(int comp_id);
    }
}
