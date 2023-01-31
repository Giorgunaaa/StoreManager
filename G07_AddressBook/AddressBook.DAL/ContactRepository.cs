using AddressBook.DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DatabaseHelper.Generic;

namespace AddressBook.DAL
{
    public sealed class ContactRepository : RepositoryBase<Contact>
    {
        RepositoryBase<Contact> _repository;
        public void Insert(Contact contact)
        {
            _repository.Insert(contact )
     
                new SqlParameter("FirstName", contact.FirstName),
                new SqlParameter("LastName", contact.LastName),
                new SqlParameter("Phone", contact.Phone),
                new SqlParameter("Email", contact.Email),
                new SqlParameter("Address", contact.Address));
        }

        public void Update(Contact contact)
        {
            //_repository.update(contact entity)
            _database.ExecuteNonQuery(
                "UpdateContact_SP",
                CommandType.StoredProcedure,
                new SqlParameter("FirstName", contact.FirstName),
                new SqlParameter("LastName", contact.LastName),
                new SqlParameter("Phone", contact.Phone),
                new SqlParameter("Email", contact.Email),
                new SqlParameter("Address", contact.Address));
        }

        public void Delete(int id)
        {
            //_repository.delete(contact entity)
            _database.ExecuteNonQuery(
                "DeleteContact_SP",
                CommandType.StoredProcedure,
                new SqlParameter("ID", id));
        }

        public IEnumerable<Contact> Search(string text)
        {
            _database.ExecuteReader(
                "SearchContact_SP",
                CommandType.StoredProcedure,
                new SqlParameter("Text", text);
        }
    }
}
