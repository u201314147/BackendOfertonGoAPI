namespace OfertonGoApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelDB2 : DbContext
    {
        public ModelDB2()
            : base("name=ModelDB2")
        {
        }

        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<PromotionProduct> PromotionProduct { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.RUC)
                .IsUnicode(false);

            modelBuilder.Entity<Business>()
                .Property(e => e.imageURL)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.image_url)
                .IsUnicode(false);

            modelBuilder.Entity<Promotion>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.adress)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.icon_url)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.birthday)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.imageURL)
                .IsUnicode(false);
        }
    }
}
