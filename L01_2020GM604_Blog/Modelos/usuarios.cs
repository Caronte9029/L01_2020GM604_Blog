using Microsoft.EntityFrameworkCore;

namespace L01_2020GM604_Blog.Modelos
{
    public class usuarios : DbContext
    {
        public usuarios(DbContextOptions<usuarios> options): base(options) { 
            

        
        }

        public DbSet<usuariosData> usuario { get; set; }

    }
}
