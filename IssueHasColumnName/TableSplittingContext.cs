using Microsoft.EntityFrameworkCore;

namespace IssueHasColumnName
{
    class TableSplittingContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<DetailedOrder> DetailedOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
                @"Server=.;Database=EFTableSplitting;Trusted_Connection=True;ConnectRetryCount=0");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailedOrder>()
                .ToTable("Orders")
                .HasBaseType((string)null)
                .Ignore(o => o.DetailedOrder);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders")
                    .HasOne(o => o.DetailedOrder).WithOne()
                    .HasForeignKey<DetailedOrder>(o => o.Id);

                entity.Property(f => f.Id).HasColumnName("IdFoo");
                entity.Property(f => f.Name).HasColumnName("NameFoo");
            });
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DetailedOrder DetailedOrder { get; set; }
        //public string Foo { get; set; }
    }

    public class DetailedOrder : Order
    {
        public string Foo { get; set; }
    }
}