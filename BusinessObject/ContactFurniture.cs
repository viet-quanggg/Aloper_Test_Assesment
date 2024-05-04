namespace BusinessObject;

public class ContactFurniture
{
    public string contactId { get; set; }
    public Contact Contact { get; set; }
    
    public int idFurniture { get; set; }
    public Furniture Furniture { get; set; }
}