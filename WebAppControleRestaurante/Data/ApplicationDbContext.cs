using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppControleRestaurante.Models;

namespace WebAppControleRestaurante.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebAppControleRestaurante.Models.PagtoMesaModel> PagtoMesaModel { get; set; }
    }
}