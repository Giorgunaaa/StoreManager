using System;
using System.Data;
using System.Data.SqlClient;
using AddressBook.DTO;

namespace AddressBook.DAL
{
	//todo: დავამატოთ ყველა საჭირო ფუნქცია ბაზის პროცედურების მიხედვით.
	public sealed class UserRepository : RepositoryBase<User>
	{
		public void Register(User user)
		{
			throw new NotImplementedException();
		}

		public string Login(string email, string password)
		{
			return _database.ExecuteScalar(
				"UserLogin_SP",
				CommandType.StoredProcedure,
				new SqlParameter("Email", email),
				new SqlParameter("Password", password)).ToString();
		}

		public void SetPassword(string currentPassword, string password)
		{
			throw new NotImplementedException();
		}
	}
}
