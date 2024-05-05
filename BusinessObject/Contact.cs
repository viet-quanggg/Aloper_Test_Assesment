using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject;

public class Contact
{
    public int idRoom { get; set; }
    [Key]
    public string id { get; set; }
    public int rentalTerm { get; set; }
    public DateTime depositDate { get; set; }
    public decimal depositAmount { get; set; }
    public decimal retailPrice { get; set; }
    public DateTime rentalStartDate { get; set; }
    public int numberOfPeople { get; set; } 
    public int numberOfVehicle { get; set; }
    public string fullName { get; set; }
    public string phoneNumber { get; set; }
    public DateTime birthOfDay { get; set; }
    public string identification { get; set; }
    public DateTime dateRange { get; set; }
    public string issuedBy { get; set; }
    public string permanentAddress { get; set; }
    public string signature { get; set; }
    public DateTime contractEndDate { get; set; }
    public string note { get; set; }
    [JsonIgnore]
    public ICollection<ContactFurniture> ContactFurnitures { get; set; } = new List<ContactFurniture>();
    [JsonIgnore]
    public ICollection<ContactService> ContactServices { get; set; } = new List<ContactService>();
}