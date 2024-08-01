using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Identity.Client;
namespace webapi.Models;

public class ApplicationDBContext: DbContext
{
    public DbSet<Product> Products {get; set;}

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options){}
}