using Microsoft.EntityFrameworkCore;
using PokemanWebApi.Model;

namespace PokemanWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {  
        }

        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Pokeman> Pokemans { get; set; }
        public DbSet<PokemanCatagory> PokemanCatagories { get; set; }
        public DbSet<PokemanOwner> PokemanOwners { get; set; }  
        public DbSet<Review> Reviews { get; set; }  
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemanCatagory>()
                .HasKey(p => new { p.PokemanId, p.CatagoryId });
            modelBuilder.Entity<PokemanCatagory>()
                .HasOne(p => p.Pokeman)
                .WithMany(p => p.PokemanCatagories)
                .HasForeignKey(p => p.PokemanId);
            modelBuilder.Entity<PokemanCatagory>()
                .HasOne(p => p.Catagory)
                .WithMany(p => p.PokemanCatagories)
                .HasForeignKey(p => p.CatagoryId);

            modelBuilder.Entity<PokemanOwner>()
                .HasKey(k => new { k.PokemanId, k.OwnerId });
            modelBuilder.Entity<PokemanOwner>()
                .HasOne(p => p.Pokeman)
                .WithMany(p => p.PokemanOwners)
                .HasForeignKey(p => p.PokemanId);
            modelBuilder.Entity<PokemanOwner>()
                .HasOne(p => p.Owner)
                .WithMany(p => p.PokemanOwners)
                .HasForeignKey(p => p.OwnerId);
                
            
                
        }

    }
}
