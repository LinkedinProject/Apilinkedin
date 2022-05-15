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
    public class EmpRepository : IEmpRepository
    {
        private readonly IDbContext _dbContext;

        public EmpRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool acceptApplicant(int job_id)
        {

            DynamicParameters B = new DynamicParameters();
            B.Add("@job_application_id", job_id, dbType: DbType.Int32);
           _dbContext.Connection.Query<Jopapply>("EMPLOYERS.acceptApplicant", B, commandType: CommandType.StoredProcedure);
            return true;
        }







        public bool createcompanypost(Postedjob postedjop)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@jobtitle", postedjop.Job_Title, dbType: DbType.String);
            B.Add("@descrip", postedjop.description, dbType: DbType.String);
            B.Add("@edlevl", postedjop.edu_Level, dbType: DbType.String);
            B.Add("@postdat", postedjop.post_Date, dbType: DbType.Date);
            B.Add("@enddate", postedjop.end_Date, dbType: DbType.Date);
            B.Add("@salary", postedjop.salary, dbType: DbType.Int32);
            B.Add("@loc", postedjop.location, dbType: DbType.String);
            B.Add("@jobtype", postedjop.job_ype, dbType: DbType.Int32);
            B.Add("@onsite", postedjop.onsite_remote, dbType: DbType.Int32);
            B.Add("@compid", postedjop.compid, dbType: DbType.Int32);
            B.Add("@carid", postedjop.catid, dbType: DbType.Int32); 
            _dbContext.Connection.Query<Postedjob>("EMPLOYERS.createcompanypost", B, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool delcompanypost(int postid)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@jobid", postid, dbType: DbType.Int32);
            _dbContext.Connection.Query<Postedjob>("EMPLOYERS.delcompanypost", B, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<CompanyApplyDTO> getApplyedOfjobPost(int job_id)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@job_id", job_id, dbType: DbType.Int32);
            IEnumerable <CompanyApplyDTO> res=  _dbContext.Connection.Query<CompanyApplyDTO>("EMPLOYERS.getApplyedOfjobPost", B, commandType: CommandType.StoredProcedure);
            return res.ToList();
        }

     


        public bool rejectApplicant(int job_id)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@job_application_id", job_id, dbType: DbType.Int32);
            _dbContext.Connection.Query<Jopapply>("EMPLOYERS.rejectApplicant", B, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool updatecompanypost(Postedjob postedjop)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@jobid", postedjop.Postid, dbType: DbType.Int32);
            B.Add("@edlevl", postedjop.edu_Level, dbType: DbType.String);
            B.Add("@enddate", postedjop.end_Date, dbType: DbType.Date);
            B.Add("@sal", postedjop.salary, dbType: DbType.Int32);
            B.Add("@loc", postedjop.location, dbType: DbType.String);
            B.Add("@jobtype", postedjop.job_ype, dbType: DbType.String);

            B.Add("@onsite", postedjop.onsite_remote, dbType: DbType.Int32);
          
            _dbContext.Connection.Query<Postedjob>("EMPLOYERS.updatecompanypost", B, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<CompanyApplyDTO> getApplyedOfjobPostbetweenDate(ApplyDatesCompany datesSearch)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@date1", datesSearch.date1, dbType: DbType.DateTime);
            B.Add("@date2", datesSearch.date2, dbType: DbType.DateTime);
            B.Add("@job_id", datesSearch.job_id, dbType: DbType.Int32);
            IEnumerable<CompanyApplyDTO> res = _dbContext.Connection.Query<CompanyApplyDTO>("EMPLOYERS.getApplyedOfjobPostbetweenDate", B, commandType: CommandType.StoredProcedure);
            return res.ToList();
        }
        public List<PostJobDTO> getAllCompPost(int comp_id)
        {

            DynamicParameters B = new DynamicParameters();
            B.Add("@comp_id", comp_id, dbType: DbType.Int32);

            IEnumerable<PostJobDTO> res = _dbContext.Connection.Query<PostJobDTO>("EMPLOYERS.getAllCompPost", B, commandType: CommandType.StoredProcedure);
            return res.ToList();
        }

        public Company get_companybyId(int comp_id)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("@companyid", comp_id, dbType: DbType.Int32);

            var res = _dbContext.Connection.Query<Company>("EMPLOYERS.get_companybyId", B, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault();
        }



        ////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        ////////////////////////// report ////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////
        ///

        public Total AnnualnumberOfJobAcceptedApplicants22(int comp_id)
        {
            var p = new DynamicParameters();
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            /* in date ,  in date*/
            p.Add("@comp_id", comp_id, dbType: DbType.Int32);
            p.Add("@date1", firstDay, dbType: DbType.DateTime);
            p.Add("@date2", lastDay, dbType: DbType.DateTime);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("TEST.AnnualnumberOfJobAcceptedApplicants1", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public Total AnnualnumberOfJobApplicants22(int comp_id)
        {
            var p = new DynamicParameters();
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            /* in date ,  in date*/
            p.Add("@comp_id", comp_id, dbType: DbType.Int32);
            p.Add("@date1", firstDay, dbType: DbType.DateTime);
            p.Add("@date2", lastDay, dbType: DbType.DateTime);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("TEST.AnnualnumberOfJobApplicants1", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public Total AnnualnumberOfJobRejectedApplicants22(int comp_id)
        {
            var p = new DynamicParameters();
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            /* in date ,  in date*/
            p.Add("@comp_id", comp_id, dbType: DbType.Int32);
            p.Add("@date1", firstDay, dbType: DbType.DateTime);
            p.Add("@date2", lastDay, dbType: DbType.DateTime);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("TEST.AnnualnumberOfJobRejectedApplicants1", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }




        public Total AnnualnumberOfJobAcceptedApplicants21(int comp_id)
        {
            var p = new DynamicParameters();
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year - 1, 1, 1);
            DateTime lastDay = new DateTime(year - 1, 12, 31);
            /* in date ,  in date*/
            p.Add("@comp_id", comp_id, dbType: DbType.Int32);
            p.Add("@date1", firstDay, dbType: DbType.DateTime);
            p.Add("@date2", lastDay, dbType: DbType.DateTime);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("TEST.AnnualnumberOfJobAcceptedApplicants1", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public Total AnnualnumberOfJobApplicants21(int comp_id)
        {
            var p = new DynamicParameters();
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year - 1, 1, 1);
            DateTime lastDay = new DateTime(year - 1, 12, 31);
            /* in date ,  in date*/
            p.Add("@comp_id", comp_id, dbType: DbType.Int32);
            p.Add("@date1", firstDay, dbType: DbType.DateTime);
            p.Add("@date2", lastDay, dbType: DbType.DateTime);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("TEST.AnnualnumberOfJobApplicants1", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public Total AnnualnumberOfJobRejectedApplicants21(int comp_id)
        {
            var p = new DynamicParameters();
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year - 1, 1, 1);
            DateTime lastDay = new DateTime(year - 1, 12, 31);
            /* in date ,  in date*/
            p.Add("@comp_id", comp_id, dbType: DbType.Int32);
            p.Add("@date1", firstDay, dbType: DbType.DateTime);
            p.Add("@date2", lastDay, dbType: DbType.DateTime);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("TEST.AnnualnumberOfJobRejectedApplicants1", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }


        public Total AnnualnumberOfJobAcceptedApplicants20(int comp_id)
        {
            var p = new DynamicParameters();
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year - 2, 1, 1);
            DateTime lastDay = new DateTime(year - 2, 12, 31);
            /* in date ,  in date*/
            p.Add("@comp_id", comp_id, dbType: DbType.Int32);
            p.Add("@date1", firstDay, dbType: DbType.DateTime);
            p.Add("@date2", lastDay, dbType: DbType.DateTime);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("TEST.AnnualnumberOfJobAcceptedApplicants1", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public Total AnnualnumberOfJobApplicants20(int comp_id)
        {
            var p = new DynamicParameters();
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year - 2, 1, 1);
            DateTime lastDay = new DateTime(year - 2, 12, 31);
            /* in date ,  in date*/
            p.Add("@comp_id", comp_id, dbType: DbType.Int32);
            p.Add("@date1", firstDay, dbType: DbType.DateTime);
            p.Add("@date2", lastDay, dbType: DbType.DateTime);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("TEST.AnnualnumberOfJobApplicants1", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public Total AnnualnumberOfJobRejectedApplicants20(int comp_id)
        {
            var p = new DynamicParameters();
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year - 2, 1, 1);
            DateTime lastDay = new DateTime(year - 2, 12, 31);
            /* in date ,  in date*/
            p.Add("@comp_id", comp_id, dbType: DbType.Int32);
            p.Add("@date1", firstDay, dbType: DbType.DateTime);
            p.Add("@date2", lastDay, dbType: DbType.DateTime);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("TEST.AnnualnumberOfJobRejectedApplicants1", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }










        ///////////////////////////////////////////////
        //////////////////////////////////////////////
        //////////////////////////////////////////////
        /////////////// All  ////////////////
        /////////////////////////////////////////////
        ////////////////////////////////////////////

        public Total AllOfJobApplicants(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            
            Total Result = _dbContext.Connection.Query<Total>("TEST.AllOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }


        public Total numberOfJobAcceptedApplicants(int comp_id)
        {
            var p = new DynamicParameters();

            /* in date ,  in date*/
            p.Add("@comp_id", comp_id, dbType: DbType.Int32);

            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("Test.numberOfJobAcceptedApplicants", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        public Total numberOfJobRejectedApplicants(int comp_id)
        {
            var p = new DynamicParameters();
            p.Add("@comp_id", comp_id, dbType: DbType.Int32);
            IEnumerable<Total> Result = _dbContext.Connection.Query<Total>("Test.numberOfJobRejectedApplicants", p, commandType: CommandType.StoredProcedure);
            return Result.FirstOrDefault();
        }

        ///////////////////////////////////////////////
        //////////////////////////////////////////////
        //////////////////////////////////////////////
        /////////////// month report ////////////////
        /////////////////////////////////////////////
        ////////////////////////////////////////////
        public Total numberOfJobApplicantsm1(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 1, 1);
            p1.Add("@mon", month, dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }



        public Total numberOfJobApplicantsm2(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 2, 1);
            p1.Add("@mon", month, dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }


        public Total numberOfJobApplicantsm3(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 3, 1);
            p1.Add("@mon", month, dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }


        public Total numberOfJobApplicantsm4(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 4, 1);
            p1.Add("@mon", month, dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }


        public Total numberOfJobApplicantsm5(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 5, 1);
            p1.Add("@mon", month, dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }


        public Total numberOfJobApplicantsm6(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 6, 1);

            p1.Add("@mon", month, dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }





        public Total numberOfJobApplicantsm7(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 7, 1);
            p1.Add("@mon", month, dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }





        public Total numberOfJobApplicantsm8(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 8, 1);
            p1.Add("@mon", month, dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }




        public Total numberOfJobApplicantsm9(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 9, 9);
            p1.Add("@mon", month , dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }




        public Total numberOfJobApplicantsm10(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 10, 1);
            p1.Add("@mon", month , dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }





        public Total numberOfJobApplicantsm11(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 11, 1);
            p1.Add("@mon", month, dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }




        public Total numberOfJobApplicantsm12(int comp_id)
        {
            var p1 = new DynamicParameters();
            p1.Add("@comp_id", comp_id, dbType: DbType.Int32);
            DateTime month = new DateTime(2022, 12, 1);
            p1.Add("@mon", month, dbType: DbType.DateTime);

            Total Result = _dbContext.Connection.Query<Total>("TEST.numberOfJobApplicants",
                p1, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return Result;
        }

    }
}
