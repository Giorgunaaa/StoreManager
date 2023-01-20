using System;
using AddressBook.DTO;

namespace AddressBook.DAL
{
	//todo: დავამატოთ ყველა საჭირო ფუნქცია ბაზის პროცედურების მიხედვით.
    public sealed class UserRepository : RepositoryBase
    {
	    public void Register(User user)
	    {
		    throw new NotImplementedException();
	    }

	    public string Login(string email, string password)
	    {
		    throw new NotImplementedException();
	    }

	    public void SetPassword(string currentPassword, string password)
	    {
		    throw new NotImplementedException();
	    }
    }
}
