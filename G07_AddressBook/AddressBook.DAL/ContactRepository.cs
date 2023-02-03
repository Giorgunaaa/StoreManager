using AddressBook.DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DatabaseHelper.Generic;

namespace AddressBook.DAL
{
    public sealed class ContactRepository : RepositoryBase<Contact>
    {
        public void Insert(Contact contact)
        {
            base.Insert(contact);
        }

        public void Update(Contact contact)
        {
            base.Update(contact);
        }

        public void Delete(int id)
        {
            base.Delete(id);
        }

        public IEnumerable<Contact> Search(string text)
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerable<SqlParameter> GetInsertParameters(Contact entity)
        {
	        yield return new SqlParameter("FirstName", entity.FirstName);
	        yield return new SqlParameter("LastName", entity.LastName);
	        yield return new SqlParameter("Phone", entity.Phone);
	        yield return new SqlParameter("Email", entity.Email);
	        yield return new SqlParameter("Address", entity.Address);
        }

        protected override IEnumerable<SqlParameter> GetUpdateParameters(Contact entity)
        {
            yield return new SqlParameter("FirstName", entity.FirstName);
            yield return new SqlParameter("LastName", entity.LastName);
            yield return new SqlParameter("Phone", entity.Phone);
            yield return new SqlParameter("Email", entity.Email);
            yield return new SqlParameter("Address", entity.Address);
        }

        protected override IEnumerable<SqlParameter> GetDeleteParameters(Contact entity)
        {
            return new SqlParameter("ID", entity.Id);
        }
    }
}
