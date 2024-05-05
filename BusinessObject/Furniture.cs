using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject;

public class Furniture
{
    [Key]
    public int idFurniture { get; set; }
    public decimal price { get; set; }
    public string note { get; set; }
    public string name { get; set; }
    public string status { get; set; }
    public bool isActive { get; set; }
    
    [JsonIgnore]
    public ICollection<ContactFurniture> ContactFurnitures { get; set; } = new List<ContactFurniture>();

}