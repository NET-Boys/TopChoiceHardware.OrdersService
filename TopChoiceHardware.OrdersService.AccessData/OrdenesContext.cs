using TopChoiceHardware.OrdersService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TopChoiceHardware.OrdersService.AccessData
{
    public class OrdenesContext : DbContext
    {
        public OrdenesContext(DbContextOptions<OrdenesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.OrdenId);

            });
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

            });
            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodId);
                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(e => e.Description)
                      .IsRequired()
                      .HasMaxLength(255);

            });
            modelBuilder.Entity<OrdenProducto>(entity =>
            {
                entity.HasKey(e => e.OrdenProductoId);

            });
        }
    }
}
