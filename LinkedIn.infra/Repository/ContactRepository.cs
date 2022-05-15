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
    public class ContactRepository : IContactRepository
    {

        private readonly IDbContext _dbContext;

        public ContactRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateContact(Contactu contactu)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("C_Email", contactu.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("C_Phone", contactu.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("C_websiteid", contactu.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
           

            _dbContext.Connection.ExecuteAsync(" Contact_Package.CreateContact", B, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateContact(Contactu contactu)
        {
            DynamicParameters B = new DynamicParameters();
            B.Add("C_Email", contactu.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("C_Phone", contactu.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            B.Add("C_websiteid", contactu.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync(" Contact_Package.UpdateContact", B, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteContact(int contactid)
        {
            DynamicParameters T = new DynamicParameters();
            T.Add("CT_Id", contactid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("Contact_Package.DeleteContact", T, commandType: CommandType.StoredProcedure);



            return true;
        }

        public List<Contactu> GetAllContact()
        {
            IEnumerable<Contactu> Result = _dbContext.Connection.Query<Contactu>("Contact_Package. GetAllContact", commandType: CommandType.StoredProcedure);
            return Result.ToList();

        }

    }
}
