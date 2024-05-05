using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Data;

public class AloperContext : DbContext
{
    public AloperContext()
    {
        
    }

    public AloperContext(DbContextOptions<AloperContext> options) : base(options)
    {
        
    }
    
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Furniture> Furnitures { get; set; }
    public DbSet<Service>  Services { get; set; }
    public DbSet<ContactService> ContactServices { get; set; }
    public DbSet<ContactFurniture> ContactFurnitures { get; set; }
    
    private string GetConnectionString()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfiguration configuration = builder.Build();
        return configuration.GetConnectionString("DefaultConnection");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
            options.UseSqlServer("Server=(local);Database=Aloper;uid=sa;pwd=123456@Aa;Trusted_Connection=false;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(c => c.id);
            entity.HasMany(c => c.ContactServices)
                .WithOne(c => c.Contact);
        });

        modelBuilder.Entity<Furniture>(entity =>
        {
            entity.HasKey(f => f.idFurniture);
        });
        
        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(f => f.idService);
        });
        
        //Configure between Contact and Furniture
        modelBuilder.Entity<ContactFurniture>()
            .HasKey(cf => new { cf.contactId, cf.idFurniture });

        modelBuilder.Entity<ContactFurniture>()
            .HasOne(cf => cf.Contact)
            .WithMany(cf => cf.ContactFurnitures)
            .HasForeignKey(cf => cf.contactId);

        modelBuilder.Entity<ContactFurniture>()
            .HasOne(cf => cf.Furniture)
            .WithMany(cf => cf.ContactFurnitures)
            .HasForeignKey(cf => cf.idFurniture);
        
        
        //Configure between Contact and Service
        modelBuilder.Entity<ContactService>()
            .HasKey(cf => new { cf.contactId, cf.idService });

        modelBuilder.Entity<ContactService>()
            .HasOne(cs => cs.Contact)
            .WithMany(cs => cs.ContactServices)
            .HasForeignKey(cf => cf.contactId);

        modelBuilder.Entity<ContactService>()
            .HasOne(cs => cs.Service)
            .WithMany(cs => cs.ContactServices)
            .HasForeignKey(cs => cs.idService);
    }
    
}