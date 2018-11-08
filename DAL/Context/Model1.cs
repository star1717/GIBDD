namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Shtraf> Shtraf { get; set; }
        public virtual DbSet<Udostover> Udostovers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .Property(e => e.Family_name)
                .IsFixedLength();

            modelBuilder.Entity<Driver>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Driver>()
                .Property(e => e.Last_name)
                .IsFixedLength();

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.Shtraf)
                .WithRequired(e => e.Driver)
                .HasForeignKey(e => e.Kod_driver_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Driver>()
                .HasMany(e => e.Udostover)
                .WithRequired(e => e.Driver)
                .HasForeignKey(e => e.Kod_driver_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shtraf>()
                .Property(e => e.opisanie)
                .IsFixedLength();

            modelBuilder.Entity<Udostover>()
                .Property(e => e.Kategori)
                .IsFixedLength();
        }
    }
}
