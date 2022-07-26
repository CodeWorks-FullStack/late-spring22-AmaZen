using System.Collections.Generic;
using System.Data;
using System.Linq;
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

    internal List<WarehouseProductViewModel> GetByProductId(int id)
    {
      string sql = @"
      SELECT
        w.*,
        wp.quantity,
        wp.id AS WarehouseProductId
      FROM warehouseproducts wp
      JOIN warehouses w ON w.id = wp.warehouseId
      WHERE wp.productId = @id
      ";
      return _db.Query<WarehouseProductViewModel>(sql, new { id }).ToList();
    }

    internal List<ProductWarehouseViewModel> GetByWarehouseId(int id)
    {
      string sql = @"
      SELECT
        p.*,
        wp.quantity,
        wp.id AS WarehouseProductId
      FROM warehouseproducts wp
      JOIN products p ON p.id = wp.productId
      WHERE wp.warehouseId = @id
      ";
      return _db.Query<ProductWarehouseViewModel>(sql, new { id }).ToList();
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM warehouseproducts WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }


  }
}