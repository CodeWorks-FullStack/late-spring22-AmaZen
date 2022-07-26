using System.Data;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class WarehouseProductsRepository
  {
    private readonly IDbConnection _db;

    public WarehouseProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal WarehouseProduct Create(WarehouseProduct newWarehouseProduct)
    {
      string sql = @"
        INSERT INTO warehouseproducts 
          (warehouseId, productId, quantity) 
        VALUES 
          (@WarehouseId, @ProductId, @Quantity); 
        SELECT LAST_INSERT_ID();";
      newWarehouseProduct.Id = _db.ExecuteScalar<int>(sql, newWarehouseProduct);
      return newWarehouseProduct;
    }

    internal WarehouseProduct CheckForExists(WarehouseProduct newWarehouseProduct)
    {
      string sql = "SELECT * FROM warehouseproducts WHERE warehouseId = @WarehouseId AND productId = @ProductId LIMIT 1";
      return _db.QueryFirstOrDefault<WarehouseProduct>(sql, newWarehouseProduct);
    }

    internal WarehouseProduct Get(int id)
    {
      string sql = "SELECT * FROM warehouseproducts WHERE id = @id";
      return _db.QueryFirstOrDefault<WarehouseProduct>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM warehouseproducts WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    // TODO GetProducts(int warehouseId)

  }
}