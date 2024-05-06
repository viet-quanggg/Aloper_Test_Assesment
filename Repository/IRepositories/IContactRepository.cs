using BusinessObject;
using BusinessObject.DTOs;

namespace Repository.IRepositories;

public interface IContactRepository
{ 
    Task<ICollection<Contact>> GetAllContacts();
    Task<Contact> GetContactById(string id);
    Task<Contact> CreateContact(ContactCreateModel contact);
    Task<Contact> UpdateContact(string id, ContactCreateModel contact);
    Task<Contact> CancelContactById(string id);
}