using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AngularJSMvc.Models.Entities
{
    public class AngularJSDbContext : DbContext
    {
        public AngularJSDbContext() : base("name = AngularJSDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}