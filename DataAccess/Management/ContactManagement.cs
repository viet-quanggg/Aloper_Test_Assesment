using System.Data;
using BusinessObject;
using BusinessObject.DTOs;
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

    public async Task<Contact> CreateContact(ContactCreateModel contact)
    {
        _context = new AloperContext();
        try
        {
            var exitedContact = await _context.Contacts.FirstOrDefaultAsync(c => c.id == contact.id);
            if (exitedContact == null)
            {
                var newContact = new Contact();
                newContact.id = contact.id;
                newContact.idRoom = contact.idRoom;
                newContact.rentalTerm = contact.rentalTerm;
                newContact.depositDate = contact.depositDate;
                newContact.depositAmount = contact.depositAmount;
                newContact.retailPrice = contact.retailPrice;
                newContact.rentalStartDate = contact.rentalStartDate;
                newContact.numberOfPeople = contact.numberOfPeople;
                newContact.numberOfVehicle = contact.numberOfVehicle;
                newContact.fullName = contact.fullName;
                newContact.phoneNumber = contact.phoneNumber;
                newContact.birthOfDay = contact.birthOfDay;
                newContact.identification = contact.identification;
                newContact.dateRange = contact.dateRange;
                newContact.issuedBy = contact.issuedBy;
                newContact.permanentAddress = contact.permanentAddress;
                newContact.signature = contact.signature;
                newContact.contractEndDate = contact.contractEndDate;
                newContact.note = contact.note;
                foreach (var furnituresId in contact.FurnituresIds)
                {
                    newContact.ContactFurnitures.Add(new ContactFurniture()
                    {
                        Contact = newContact,
                        idFurniture = furnituresId
                    });
                    
                }
                foreach (var servicesId in contact.ServicesIds)
                {
                    newContact.ContactServices.Add(new ContactService()
                    {
                        Contact = newContact,
                        idService = servicesId
                    });
                    
                }
                
                await _context.Contacts.AddAsync(newContact);
                await _context.SaveChangesAsync();
                return newContact;
            }
            else
            {
                throw new DuplicateNameException("Contact with id: " + contact.id + " is existed!");
            }

            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    public async Task<Contact> UpdateContact(string id, ContactCreateModel contact)
    {
        _context = new AloperContext();
        try
        {
            var exitedContact = await GetContactById(id);
            if (exitedContact != null)
            {
                exitedContact.idRoom = contact.idRoom;
                exitedContact.rentalTerm = contact.rentalTerm;
                exitedContact.depositDate = contact.depositDate;
                exitedContact.depositAmount = contact.depositAmount;
                exitedContact.retailPrice = contact.retailPrice;
                exitedContact.rentalStartDate = contact.rentalStartDate;
                exitedContact.numberOfPeople = contact.numberOfPeople;
                exitedContact.numberOfVehicle = contact.numberOfVehicle;
                exitedContact.fullName = contact.fullName;
                exitedContact.phoneNumber = contact.phoneNumber;
                exitedContact.birthOfDay = contact.birthOfDay;
                exitedContact.identification = contact.identification;
                exitedContact.dateRange = contact.dateRange;
                exitedContact.issuedBy = contact.issuedBy;
                exitedContact.permanentAddress = contact.permanentAddress;
                exitedContact.signature = contact.signature;
                exitedContact.contractEndDate = contact.contractEndDate;
                exitedContact.note = contact.note;

                var exitedFurnitureIds = exitedContact.ContactFurnitures.Select(cf => cf.idFurniture).ToList();
                var selectedFurnitureIds = contact.FurnituresIds.ToList();
                var toAddFurIds = selectedFurnitureIds.Except(exitedFurnitureIds).ToList();
                var toRemoveFurIds = exitedFurnitureIds.Except(selectedFurnitureIds).ToList();
                exitedContact.ContactFurnitures = exitedContact.ContactFurnitures
                    .Where(x => !toRemoveFurIds.Contains(x.idFurniture)).ToList();
                foreach (var addFurId in toAddFurIds)
                {
                    exitedContact.ContactFurnitures.Add(new ContactFurniture()
                    {
                        idFurniture = addFurId
                    });
                }
                
                var exitedServiceIds = exitedContact.ContactServices.Select(cf => cf.idService).ToList();
                var selectedServiceIds = contact.ServicesIds.ToList();
                var toAddSerIds = selectedServiceIds.Except(exitedServiceIds).ToList();
                var toRemoveSerIds = exitedServiceIds.Except(selectedServiceIds).ToList();
                exitedContact.ContactServices = exitedContact.ContactServices
                    .Where(x => !toRemoveSerIds.Contains(x.idService)).ToList();
                foreach (var addSerId in toAddSerIds)
                {
                    exitedContact.ContactServices.Add(new ContactService()
                    {
                        idService = addSerId
                    });
                }
                
                ;
                
                _context.Attach(exitedContact).State = EntityState.Modified;
                
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new DuplicateNameException("Contact with id: " + contact.id + " is not found!");
            }

            return exitedContact;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    public async Task<Contact> CancelContactById(string id)
    {
        _context = new AloperContext();
        try
        {
            var exitedContact = await _context.Contacts.FirstOrDefaultAsync(c => c.id == id);
            if (exitedContact != null)
            {
                exitedContact.rentalTerm = 0;
                _context.Attach(exitedContact).State = EntityState.Modified;
                
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new DuplicateNameException("Contact with id: " + id + " is not found!");
            }

            return exitedContact;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}