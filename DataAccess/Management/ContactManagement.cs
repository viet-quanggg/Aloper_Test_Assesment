using System.Data;
using BusinessObject;
using DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Management;

public class ContactManagement
{
    AloperContext _context;
    private static ContactManagement instance;
    private static readonly object instanceLock = new object();
    
    public static ContactManagement Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new ContactManagement();
                }
            }
            return instance;
        }
    }
    

    public async Task<ICollection<Contact>> GetAllContacts()
    {
        _context = new AloperContext();
        try
        {
            var contacts = await _context.Contacts
                .Include(c => c.ContactServices)
                .ThenInclude(cs => cs.Service)
                .Include(c => c.ContactFurnitures)
                .ThenInclude(cf => cf.Furniture)
                .ToListAsync();
            if (contacts == null)
                throw new BadHttpRequestException("No contact found !");
            return contacts;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Contact> GetContactById(string id)
    {
        _context = new AloperContext();
        try
        {
            var contact = await _context.Contacts
                .Include(c => c.ContactServices)
                .ThenInclude(c => c.Service)
                .Include(c => c.ContactFurnitures)
                .ThenInclude(c => c.Furniture)
                .FirstOrDefaultAsync(c => c.id == id);
            if (contact != null)
                return contact;
            throw new BadHttpRequestException("Contact not found!");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Contact> CreateContact(Contact contact)
    {
        _context = new AloperContext();
        try
        {
            var exitedContact = await _context.Contacts.FirstOrDefaultAsync(c => c.id == contact.id);
            if (exitedContact == null)
            {
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new DuplicateNameException(contact.id);
            }

            return contact;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}