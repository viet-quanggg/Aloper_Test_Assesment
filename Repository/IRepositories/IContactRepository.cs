using BusinessObject;

namespace Repository.IRepositories;

public interface IContactRepository
{ 
    Task<ICollection<Contact>> GetAllContacts();
    Task<Contact> GetContactById(string id);
    Task<Contact> CreateContact(Contact contact);
    Task<Contact> UpdateContact(string id, Contact contact);
    Task<Contact> CancelContactById(string id);
}