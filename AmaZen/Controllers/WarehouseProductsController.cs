using System;
using AmaZen.Services;
using AmaZen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WarehouseProductsController : ControllerBase
  {
    private readonly WarehouseProductsService _wps;

    public WarehouseProductsController(WarehouseProductsService wps)
    {
      _wps = wps;
    }

    [HttpPost]
    [Authorize]
    public ActionResult<WarehouseProduct> Create([FromBody] WarehouseProduct newWarehouseProduct)
    {
      try
      {
        return Ok(_wps.Create(newWarehouseProduct));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _wps.Delete(id);
        return Ok("delete successful");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}