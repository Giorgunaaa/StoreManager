using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AddressBook.DTO;
using DatabaseHelper.Generic;

namespace AddressBook.DAL
{
    //todo: დავამატოთ ყველა საჭირო ფუნქცია ბაზის პროცედურების მიხედვით.
    public sealed class UserRepository : RepositoryBase<User>
    {
        public void Register(User user)
        {
            base.Insert(user);
        }

        public string Login(string email, string password)
        {
            return _database.ExecuteScalar(
                "LoginUser_SP",
                CommandType.StoredProcedure,
                new SqlParameter("Email", email),
                new SqlParameter("Password", password)).ToString();
        }

        public void SetPassword(string currentPassword, string password)
        {
            //repository.update(user entity)
            _database.ExecuteNonQuery(
                "SetUserPassword_SP",
                CommandType.StoredProcedure,
                new SqlParameter("Password", currentPassword),
                new SqlParameter("NewPassword", password));
        }

        protected override IEnumerable<SqlParameter> GetInsertParameters(User entity)
        {
            yield return new SqlParameter("Email", entity.Email);
            yield return new SqlParameter("Password", entity.Password);
        }

        protected override IEnumerable<SqlParameter> GetUpdateParameters(User entity)
        {
	        throw new NotImplementedException();
        }

        protected override IEnumerable<SqlParameter> GetDeleteParameters(User entity)
        {
	        throw new NotImplementedException();
        }
    }
}

