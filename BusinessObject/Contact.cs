namespace BusinessObject;

public class Contact
{
    public int idRoom;
    public string id;
    public int rentalTerm;
    public DateTime depositDate;
    public decimal depositAmount;
    public decimal retailPrice;
    public DateTime rentalStartDate;
    public int numberOfPeople;
    public int numberOfVehicle;
    public string fullName;
    public string phoneNumber;
    public DateTime birthOfDay;
    public string identification;
    public DateTime dateRange;
    public string issuedBy;
    public string permanentAddress;
    public string signature;
    public DateTime contractEndDate;
    public string note;

    public ICollection<ContactFurniture> ContactFurnitures { get; set; } = new List<ContactFurniture>();

    public ICollection<ContactService> ContactServices { get; set; } = new List<ContactService>();
}