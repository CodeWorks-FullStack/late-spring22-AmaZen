using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class WarehouseProductsService
  {
    private readonly WarehouseProductsRepository _repo;

    public WarehouseProductsService(WarehouseProductsRepository repo)
    {
      _repo = repo;
    }

    internal WarehouseProduct Create(WarehouseProduct newWarehouseProduct)
    {
      WarehouseProduct exists = _repo.CheckForExists(newWarehouseProduct);

      if (exists != null)
      {
        // Handle however you want throw an error, or return the original relationship
        return exists;
      }

      return _repo.Create(newWarehouseProduct);
    }

    internal WarehouseProduct Get(int id)
    {
      WarehouseProduct found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal void Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
    }

    internal List<ProductWarehouseViewModel> GetByWarehouseId(int id)
    {
      return _repo.GetByWarehouseId(id);
    }

    internal List<WarehouseProductViewModel> GetByProductId(int id)
    {
      return _repo.GetByProductId(id);
    }
  }
}