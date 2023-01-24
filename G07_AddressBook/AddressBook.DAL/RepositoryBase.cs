using DatabaseHelper;

namespace AddressBook.DAL
{
	public abstract class RepositoryBase
	{
		protected MsSqlDatabase _database;

		protected RepositoryBase()
		{
			_database = new MsSqlDatabase("");
		}
	}
}