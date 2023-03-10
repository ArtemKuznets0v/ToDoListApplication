using Microsoft.EntityFrameworkCore;
using ToDoListApplication.Models;

namespace ToDoListApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<ToDoListModel> ToDoLists{ get; set; }
    }
}
