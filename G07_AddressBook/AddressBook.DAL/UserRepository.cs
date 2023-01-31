using System;
using System.Data;
using System.Data.SqlClient;
using AddressBook.DTO;
using DatabaseHelper.Generic;

namespace AddressBook.DAL
{
    //todo: დავამატოთ ყველა საჭირო ფუნქცია ბაზის პროცედურების მიხედვით.
    public sealed class UserRepository : RepositoryBase<User>
    {
        RepositoryBase<User> repository;
        public void Register(User user)
        {
            //repository.Insert(entity<user>((new SqlParameter("Email", user.Email), new SqlParameter("Password", user.Password).ToString());
            _database.ExecuteNonQuery(
                  "InsertUser_SP",
                   CommandType.StoredProcedure,
                   new SqlParameter("Email", user.Email),
                   new SqlParameter("Password", user.Password)).ToString();
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
    }
}

