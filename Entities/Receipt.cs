namespace Entities;

public class Receipt : Entity
{
    public string? ShopName { get; set; }    
    public DateTime DateTime { get; set; }
    public ICollection<ReceiptPosition> Positions { get; set; } = new List<ReceiptPosition>();
}