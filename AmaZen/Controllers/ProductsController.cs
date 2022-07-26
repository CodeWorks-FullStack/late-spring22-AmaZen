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
  public class ProductsController : ControllerBase
  {
    private readonly ProductsService _ps;
    private readonly WarehouseProductsService _wps;

    public ProductsController(ProductsService ps, WarehouseProductsService wps)
    {
      _ps = ps;
      _wps = wps;
    }

    [HttpGet]
    public ActionResult<List<Product>> Get()
    {
      try
      {
        List<Product> products = _ps.Get();
        return Ok(products);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
      try
      {
        Product product = _ps.Get(id);
        return Ok(product);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}/warehouses")]
    public ActionResult<List<WarehouseProductViewModel>> GetWarehouses(int id)
    {
      try
      {
        List<WarehouseProductViewModel> warehouses = _wps.GetByProductId(id);
        return Ok(warehouses);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Product> Create([FromBody] Product product)
    {
      try
      {
        Product newProduct = _ps.Create(product);
        return Created($"/api/products/{newProduct.Id}", newProduct);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Product> Edit([FromBody] Product product, int id)
    {
      try
      {
        product.Id = id;
        Product editProduct = _ps.Edit(product);
        return Ok(editProduct);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Product> Delete(int id)
    {
      try
      {
        _ps.Delete(id);
        return Ok("Deleted");
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}