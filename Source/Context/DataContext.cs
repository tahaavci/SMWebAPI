using Microsoft.EntityFrameworkCore;
using SMWebApi.Models;
namespace SMWebApi.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Debt> Debts { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FlatUser> FlatUsers { get; set; }

        public DbSet<Session> Sessions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            //modelBuilder.Entity<FlatUser>()
            //    .HasKey(pk => pk.Id);


            /*
             * 
             modelBuilder.Entity<FlatUser>()
                .HasKey(pk => new { pk.flat_id, pk.user_id });
            

             modelBuilder.Entity<FlatUser>()
                .HasOne(f => f.user)
                .WithMany(u => u.flatUsers)
                .HasForeignKey(f => f.flat_id);


            modelBuilder.Entity<FlatUser>()
                .HasOne(fu => fu.flat)
                .WithMany(u => u.flatUsers)
                .HasForeignKey(f => f.flat_id);
            
            */


            //  -------Building-------


            /*
            modelBuilder.Entity<Building>()
                .HasOne(b => b.buildManager)
                .WithMany(u => u.buildManagers)
                .HasForeignKey( b => b.user_id)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Building>()
                .HasOne(b => b.buildSettle)
                .WithMany(s => s.settleBuildings)
                .HasForeignKey(b => b.settle_id)
                .OnDelete(DeleteBehavior.NoAction);

            */

        }

    }
}
