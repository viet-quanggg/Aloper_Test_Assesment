using BusinessObject;
using BusinessObject.DTOs;
using DataAccess.Management;
using Repository.IRepositories;

namespace Repository.Repositories;

public class ContactRepository : IContactRepository
{
    public Task<ICollection<Contact>> GetAllContacts() => ContactManagement.Instance.GetAllContacts();
    public Task<Contact> GetContactById(string id) => ContactManagement.Instance.GetContactById(id);
    public async Task<Contact> CreateContact(ContactCreateModel contact)
    {
      return await ContactManagement.Instance.CreateContact(contact);
    }

    public async Task<Contact> UpdateContact(string id, ContactCreateModel contact)
    {
        return await ContactManagement.Instance.UpdateContact(id, contact);
    }

    public async Task<Contact> CancelContactById(string id)
    {
        return await ContactManagement.Instance.CancelContactById(id);
    }
}