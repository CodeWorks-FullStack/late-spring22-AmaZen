using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WarehousesController : ControllerBase
  {
    private readonly WarehousesService _ws;
    private readonly WarehouseProductsService _wps;

    public WarehousesController(WarehousesService ws, WarehouseProductsService wps)
    {
      _ws = ws;
      _wps = wps;
    }

    [HttpGet]
    public ActionResult<List<Warehouse>> Get()
    {
      try
      {
        List<Warehouse> warehouses = _ws.Get();
        return Ok(warehouses);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Warehouse> Get(int id)
    {
      try
      {
        Warehouse warehouse = _ws.Get(id);
        return Ok(warehouse);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // TODO [HttpGet("{id}/products")]

    [HttpPost]
    [Authorize]
    public ActionResult<Warehouse> Create([FromBody] Warehouse warehouse)
    {
      try
      {
        Warehouse newWarehouse = _ws.Create(warehouse);
        // NOTE created returns two values, the endpoint where data can be found(string), and the data
        return Created($"/api/warehouses/{newWarehouse.Id}", newWarehouse);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Warehouse> Edit([FromBody] Warehouse warehouse, int id)
    {
      try
      {
        warehouse.Id = id;
        Warehouse updated = _ws.Edit(warehouse);
        return Ok(updated);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _ws.Delete(id);
        return Ok("Deleted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}