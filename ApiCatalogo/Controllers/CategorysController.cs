using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategorysController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategorysController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("products")]
    public ActionResult<IEnumerable<Category>> GetCategoryProducts()
    {
        return _context.Categorys.Include(p => p.Products).Where(c => c.CategoryId < 5).ToList();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> Get()
    {
        try
        {
            return _context.Categorys.AsTracking().ToList();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um Problema ao tratar sua Solicitacao");
        }
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public ActionResult<Category> Get(int id)
    {
        try
        {
            var cat = _context.Categorys.FirstOrDefault(p => p.CategoryId == id);
            if (cat == null)
            {
                return NotFound("Produto nao encontrado!");
            }
            return Ok(cat);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um Problema ao tratar sua Solicitacao");
        }
    }

    [HttpPost]
    public ActionResult Post(Category c)
    {
        if (c == null) return BadRequest("dados invalidos");

        _context.Categorys.Add(c);
        _context.SaveChanges();
        return new CreatedAtRouteResult("GetCategory", new { id = c.CategoryId }, c);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Category c)
    {
        if (id != c.CategoryId) return BadRequest("dados invalidos");

        _context.Entry(c).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(c);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {

        var cat = _context.Categorys.FirstOrDefault(c => c.CategoryId == id);

        if (cat is null) return NotFound($"Categoria com id {id} nao encontrada!");

        _context.Categorys.Remove(cat);
        _context.SaveChanges();

        return Ok("Categoria Deletada!" + cat);
    }
}
