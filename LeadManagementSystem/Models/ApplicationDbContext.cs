using Microsoft.EntityFrameworkCore;
using LeadManagementSystem.Models;

//Db Context Configuration

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
          SalesPeople = Set<SalesPerson>();
        Leads = Set<Lead>();
        LeadActivities = Set<LeadActivity>();
    }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<SalesPerson>().ToTable("SalesPerson"); 
    modelBuilder.Entity<Lead>().ToTable("Leads");

            // Configure the one-to-many relationship
            modelBuilder.Entity<LeadActivity>()
                .HasOne(la => la.Lead)
                .WithMany(l => l.LeadActivities)
                .HasForeignKey(la => la.LeadId)
                .OnDelete(DeleteBehavior.Cascade); 

}


    public DbSet<SalesPerson> SalesPeople { get; set; }
    public DbSet<Lead> Leads { get; set; }
    public DbSet<LeadActivity> LeadActivities { get; set; }

}
