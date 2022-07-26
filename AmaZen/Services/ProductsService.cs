using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class ProductsService
  {
    private readonly ProductsRepository _repo;

    public ProductsService(ProductsRepository repo)
    {
      _repo = repo;
    }

    internal List<Product> Get()
    {
      return _repo.Get();
    }

    internal Product Get(int id)
    {
      Product foundProduct = _repo.Get(id);
      if (foundProduct == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundProduct;
    }

    internal Product Create(Product product)
    {
      Product newProduct = _repo.Create(product);
      return newProduct;
    }

    internal Product Edit(Product product)
    {
      Product original = Get(product.Id);
      original.Name = product.Name ?? original.Name;
      original.Description = product.Description ?? original.Description;
      original.Category = product.Category ?? original.Category;

      _repo.Edit(original);
      return original;
    }

    internal void Delete(int id)
    {
      Product foundProduct = Get(id);
      _repo.Delete(id);
    }
  }
}