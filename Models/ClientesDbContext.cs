using Microsoft.EntityFrameworkCore;

namespace Clientes.Models
{
    public class ClientesDbContext : DbContext
    {
        public ClientesDbContext(DbContextOptions<ClientesDbContext> opciones)
            : base(opciones)
        {
        }


        public DbSet<ClienteModel> Clientes { get; set; } = default!;
    }
}
