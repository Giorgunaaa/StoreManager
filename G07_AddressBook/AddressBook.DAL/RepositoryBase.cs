using AddressBook.DTO;
using DatabaseHelper;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook.DAL
{
	// დაასრულეთ და გატესტეთ შემდეგი ფუნქციონალი: Insert, Update, Delete.
	// ეს ფუნქციები უნდა მუშაობდეს ყველა მემკვიდრე კლასებისთვის.
	public abstract class RepositoryBase<T>
	{
		protected MsSqlDatabase _database;

		protected RepositoryBase()
		{
			_database = new MsSqlDatabase(@"server=DESKTOP-VPHH4BG; database=G07_AC_AddressBook; integrated security=true");
		}

		protected string EntityName => typeof(T).Name;

		public void Insert(T entity)
		{
			_database.ExecuteNonQuery(
				$"Insert{EntityName}_SP",
				CommandType.StoredProcedure,
				GetInsertParameters(entity).ToArray());
		}

		public void Update(T entity)
		{
			_database.ExecuteNonQuery(
				$"Update{EntityName}_SP",
				CommandType.StoredProcedure);
		}

		public void Delete(int id)
		{
			_database.ExecuteNonQuery(
				$"Delete{EntityName}_SP",
				CommandType.StoredProcedure);				
		}

		protected abstract IEnumerable<SqlParameter> GetInsertParameters(T entity);
		protected abstract IEnumerable<SqlParameter> GetUpdateParameters(T entity);
		protected abstract IEnumerable<SqlParameter> GetDeleteParameters(T entity);
	}
}