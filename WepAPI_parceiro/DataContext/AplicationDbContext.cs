using Microsoft.EntityFrameworkCore;
using WepAPI_parceiro.Models;

namespace WepAPI_parceiro.DataContext
{
	public class AplicationDbContext : DbContext
	{
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
 
        }

        public DbSet<ClienteModel> Clientes { get; set; }
    }
}
