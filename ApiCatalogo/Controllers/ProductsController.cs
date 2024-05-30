using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        var products = _context.Products.AsNoTracking().ToList();
        if (products is null)
        {
            return NotFound("Products nao encontrados");
        }
        return products;
    }

    [HttpGet("{id:int}", Name="GetProduct")]
    public ActionResult<Product> Get(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            return NotFound("Produto nao encontrado!");
        }
        return product;
    }

    [HttpPost]
    public ActionResult Post(Product p)
    {
        if (p == null) return BadRequest();

        _context.Products.Add(p);
        _context.SaveChanges();
        return new CreatedAtRouteResult("GetProduct", new { id = p.ProductId }, p);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Product p)
    {
        if (id != p.ProductId)
        {
            return BadRequest();
        }

        _context.Entry(p).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(p);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {

        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

        if (product is null) return NotFound("Produto nao encontrado!");
        _context.Products.Remove(product);
        _context.SaveChanges();

        return Ok("Produto Deletado! " + product.ProductId);
    }
}
