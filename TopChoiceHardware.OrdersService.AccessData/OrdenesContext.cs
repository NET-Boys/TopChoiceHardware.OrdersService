using Microsoft.EntityFrameworkCore;
using TopChoiceHardware.OrdersService.Domain.Entities;

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

            modelBuilder.Entity<MetodoPago>().HasData(

                new MetodoPago
                {
                    PaymentMethodId = 1,
                    Title = "Visa",
                    Description = "Tarjeta Visa"
                },
                new MetodoPago
                {
                    PaymentMethodId = 2,
                    Title = "Master Card",
                    Description = "Tarjeta Master Card"
                },
                new MetodoPago
                {
                    PaymentMethodId = 3,
                    Title = "Mercado Pago",
                    Description = "Mercado Pago"
                },
                new MetodoPago
                {
                    PaymentMethodId = 4,
                    Title = "BitCoin",
                    Description = "Cripto Monedas"
                }

            );
        }
    }
}
