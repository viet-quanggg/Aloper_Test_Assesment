using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject;

public class Service
{
    [Key]
    public int idService { get; set; }
    public decimal priceService { get; set; }
    public string dvt { get; set; }
    public int oldNumber { get; set; }
    public string name { get; set; }
    
    [JsonIgnore]
    public ICollection<ContactService> ContactServices { get; set; } = new List<ContactService>();

}