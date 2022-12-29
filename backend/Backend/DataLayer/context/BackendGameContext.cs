using DataLayer.models.questions;
using DataLayer.models.users;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.context
{
    public class BackendGameContext : DbContext
    {
        public BackendGameContext(DbContextOptions<BackendGameContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Option> Options { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Question>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDelete);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);




        }
    }
}
