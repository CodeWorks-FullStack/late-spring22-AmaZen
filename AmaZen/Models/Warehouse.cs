namespace AmaZen.Models
{
  public class Warehouse
  {
    public int Id { get; set; }
    public string Location { get; set; }
    public string Name { get; set; }
  }

  public class WarehouseProductViewModel : Warehouse
  {
    public int Quantity { get; set; }
    public int WarehouseProductId { get; set; }
  }
}