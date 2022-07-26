using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class WarehousesService
  {
    private readonly WarehousesRepository _repo;

    public WarehousesService(WarehousesRepository repo)
    {
      _repo = repo;
    }

    internal List<Warehouse> Get()
    {
      return _repo.Get();
    }

    internal Warehouse Get(int id)
    {
      Warehouse foundWarehouse = _repo.Get(id);
      if (foundWarehouse == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundWarehouse;
    }

    internal Warehouse Create(Warehouse warehouse)
    {
      Warehouse newWarehouse = _repo.Create(warehouse);
      return newWarehouse;
    }

    internal Warehouse Edit(Warehouse warehouse)
    {
      Warehouse original = Get(warehouse.Id);
      original.Name = warehouse.Name ?? original.Name;
      original.Location = warehouse.Location ?? original.Location;

      _repo.Edit(original);
      return original;
    }

    internal void Delete(int id)
    {
      Warehouse foundWarehouse = Get(id);
      _repo.Delete(id);
    }
  }
}