using CRUPersonRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUPersonRepository.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
    }
}
