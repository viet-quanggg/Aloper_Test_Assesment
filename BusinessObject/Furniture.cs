namespace BusinessObject;

public class Furniture
{
    public int idFurniture;
    public decimal price;
    public string note;
    public string name;
    public string status;
    public bool isActive;
    
    public ICollection<ContactFurniture> ContactFurnitures { get; set; } = new List<ContactFurniture>();

}