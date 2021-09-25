using TopChoiceHardware.OrdersService.Domain.Commands;
using TopChoiceHardware.OrdersService.Domain.Entities;
using TopChoiceHardware.OrdersService.Domain.DTOs;
namespace TopChoiceHardware.OrdersService.Application.Services
{
    public interface IOrdenesService 
    {
        Orden CreateOrden(OrdenDto orden);
        OrdenProducto CreateOrdenProducto(OrdenProductoDto ordenProducto);
        MetodoPago CreateMetodoPago(MetodoPagoDto metodoPago);
        Factura CreateFactura(FacturaDto factura);

    }
    public class OrdenesService : IOrdenesService
    {
        private IGenericRepository _repository;

        public OrdenesService (IGenericRepository repository) 
        {
            _repository = repository;
        }
        public Orden CreateOrden (OrdenDto orden) 
        {
            var entity = new Orden
            {
                UserId = orden.UserId,
                PaymentMethodId = orden.PaymentMethodId,
                AddressId = orden.AddressId,
                Total = orden.Total
            };
            _repository.Add(entity);
            return entity;
        }
        public OrdenProducto CreateOrdenProducto (OrdenProductoDto ordenProducto) 
        {
            var entity = new OrdenProducto
            {
                OrdenId = ordenProducto.OrdenId,
                ProductId = ordenProducto.ProductId
            };
            _repository.Add(entity);
            return entity;
        }
        public MetodoPago CreateMetodoPago (MetodoPagoDto metodoPago) 
        {
            var entity = new MetodoPago
            {
                Title = metodoPago.Title,
                Description = metodoPago.Description
            };
            _repository.Add(entity);
            return entity;
        }
        public Factura CreateFactura (FacturaDto factura) 
        {
            var entity = new Factura
            {
                UserId = factura.UserId,
                OrderId = factura.OrderId,
                Date = factura.Date
            };
            _repository.Add(entity);
            return entity;
        }
        
    }
}
