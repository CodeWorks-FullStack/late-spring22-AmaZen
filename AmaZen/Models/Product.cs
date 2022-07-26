namespace AmaZen.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
  }

  public class ProductWarehouseViewModel : Product
  {
    public int Quantity { get; set; }
    public int WarehouseProductId { get; set; }
  }

}