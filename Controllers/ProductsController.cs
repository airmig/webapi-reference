using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using webapi.Models;
namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController:ControllerBase{
    private readonly ApplicationDBContext _context;
    public ProductsController(ApplicationDBContext context){
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet]
    public IEnumerable<Product> GetProducts(){
        return _context.Products.ToList();
    }

    [HttpPost]
    public IActionResult AddProduct(Product product){
        try{
            _context.Add(product);
            _context.SaveChanges();
            return StatusCode(200, "Product Created");
        }
        catch{
            return StatusCode(500, "Unable to add product");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id){
        try{
            Product? product = _context.Products.Find(id) ?? throw new Exception();
            return StatusCode(200, product);
        }
        catch {
            return StatusCode(500, "Unable to get product");
        }
    }
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product product){
        try{
            if (id!=product.Id)
                return StatusCode(400, "Bad request");
            _context.Products.Update(product);
            _context.SaveChanges(true);
            return StatusCode(200, "Product updated.");
        }
        catch{
            return StatusCode(500, "Unable to update");
        }
    }
}