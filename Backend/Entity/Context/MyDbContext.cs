using Entity.Helper;
using Entity.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Context
{
    public class MyDbContext: DbContext
    {
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions options): base(options) { }


        public DbSet<Entity.Models.Class> Classes { get; set; }
        public DbSet<Entity.Models.Lesson> Lessons { get; set; }
        public DbSet<Entity.Models.Student> Students { get; set; }
        public DbSet<Entity.Models.Teacher> Teachers { get; set; }
        public DbSet<Entity.Models.Log.Log> Logs { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.ConnectionString);
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries<BaseEntity>();
            foreach(var entry in entities)
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedDateTime = DateTime.UtcNow,
                    EntityState.Modified => entry.Entity.UpdatedDateTime = DateTime.UtcNow
                };
            }
            return base.SaveChanges();
        }

    }
}
