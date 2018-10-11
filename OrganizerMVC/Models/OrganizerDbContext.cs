using Microsoft.AspNet.Identity.EntityFramework;

namespace OrganizerMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OrganizerDbContext : IdentityDbContext<ApplicationUser>
    {
        // Your context has been configured to use a 'OrganizerDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'OrganizerMVC.Models.OrganizerDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'OrganizerDbContext' 
        // connection string in the application configuration file.
        public OrganizerDbContext()
            : base("name=OrganizerDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public static OrganizerDbContext Create()
        {
            return new OrganizerDbContext();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Organizer> Organizers { get; set; }
        public virtual DbSet<OrganizerEvent> OrganizerEvents { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organizer>()
                .HasRequired(a => a.User)
                .WithMany(u => u.Organizers)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Organizer>()
            //    .HasOptional(o => o.OrganizerEvents)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Event>()
            //    .HasOptional(o => o.OrganizerEvents)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasRequired(r => r.Sport)
                .WithMany(s => s.Events)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizerEvent>()
                .HasRequired(r => r.Organizer)
                .WithMany(o => o.OrganizerEvents)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizerEvent>()
                .HasRequired(r => r.Event)
                .WithMany(o => o.OrganizerEvents)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}