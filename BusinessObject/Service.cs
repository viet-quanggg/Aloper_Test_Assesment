namespace BusinessObject;

public class Service
{
    public int idService;
    public decimal priceService;
    public string dvt;
    public int oldNumber;
    public string name;
    
    public ICollection<ContactService> ContactServices { get; set; } = new List<ContactService>();

}