using Equipment.Core.Domain.EquipmentAggregate;
using Equipment.Core.Domain.ValueObjects;

namespace Equipment.Infrastructure.Databases.EquipmentDb;

public class EquipmentDbContext(DbContextOptions<EquipmentDbContext> options) : DbContext(options)
{
    public DbSet<Core.Domain.EquipmentAggregate.Equipment> Equipment => Set<Core.Domain.EquipmentAggregate.Equipment>();
    public DbSet<Attachment> Attachments => Set<Attachment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Core.Domain.EquipmentAggregate.Equipment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasConversion(id => id.Value, value => new EquipmentId(value))
                .ValueGeneratedNever();

            entity.Property(p => p.EquipmentNumber)
                .HasConversion(id => id.Value, value => new EquipmentNumber(value))
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(10000000, 1)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            entity.ComplexProperty(p => p.SerialNumber);

            entity.Ignore(p => p.DomainEvents);

            entity.HasMany(c => c.Attachments)
                .WithOne()
                .HasForeignKey(l => l.EquipmentId)
                .HasPrincipalKey(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasConversion(id => id.Value, value => new AttachmentId(value))
                .ValueGeneratedNever();

            entity.ComplexProperty(p => p.EquipmentNumber);

            entity.Property(e => e.EquipmentId)
                .HasConversion(id => id.Value, value => new EquipmentId(value));
        });
    }
}