using System.Collections.Generic;
using System.Data;
using System.Linq;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class ProductsRepository
  {
    private readonly IDbConnection _db;

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Product> Get()
    {
      string sql = "SELECT * FROM products";
      return _db.Query<Product>(sql).ToList();
    }

    internal Product Get(int id)
    {
      string sql = "SELECT * FROM products WHERE id = @id";
      return _db.QueryFirstOrDefault<Product>(sql, new { id });
    }

    internal Product Create(Product product)
    {
      string sql = @"
            INSERT INTO products
            (name, description, category)
            VALUES
            (@Name, @Description, @Category);
            SELECT LAST_INSERT_ID();";
      product.Id = _db.ExecuteScalar<int>(sql, product);
      return product;
    }

    internal void Edit(Product original)
    {
      string sql = @"
                UPDATE products
                SET
                    name = @Name,
                    description = @Description,
                    category = @Category
                WHERE id = @Id;";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM products WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}