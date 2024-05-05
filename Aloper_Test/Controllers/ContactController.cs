using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepositories;

namespace Aloper_Test.Controllers;

[ApiController]
[Route("api/contact")]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllContacts()
    {
        var contacts = await _contactRepository.GetAllContacts();
        if(contacts == null) return BadRequest(new { Message = "No contact found!" });
        return Ok(contacts);
    }
    
    [HttpGet("/GetContactById/{id}")]
    public async Task<IActionResult> GetContactById(string id)
    {
        var contact = await _contactRepository.GetContactById(id);
        if(contact == null) return BadRequest(new { Message = "Contact not found!" });
        return Ok(contact);
    }

    [HttpPost("/CreateContact")]
    public  IActionResult CreateContact([FromBody] Contact contact)
    {
        return CreatedAtAction(nameof(GetContactById), new { id = contact.id });
    }
}