using System.Collections.Generic;
using System.Data;
using System.Linq;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class WarehousesRepository
  {
    private readonly IDbConnection _db;

    public WarehousesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Warehouse> Get()
    {
      string sql = "SELECT * FROM warehouses";
      return _db.Query<Warehouse>(sql).ToList();

    }

    internal Warehouse Get(int id)
    {
      string sql = "SELECT * FROM warehouses WHERE id = @id";
      return _db.QueryFirstOrDefault<Warehouse>(sql, new { id });
    }

    internal Warehouse Create(Warehouse warehouse)
    {
      string sql = @"
                INSERT INTO warehouses
                (name, location)
                VALUES
                (@Name, @Location);
                SELECT LAST_INSERT_ID();";
      warehouse.Id = _db.ExecuteScalar<int>(sql, warehouse);
      return warehouse;
    }

    internal void Edit(Warehouse original)
    {
      string sql = @"
                    UPDATE warehouses
                    SET
                        name = @Name,
                        location = @Location
                    WHERE id = @Id;";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM warehouses WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}