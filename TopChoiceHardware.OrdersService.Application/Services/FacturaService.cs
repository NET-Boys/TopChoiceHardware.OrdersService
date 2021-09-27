using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.OrdersService.Domain.Commands;
using TopChoiceHardware.OrdersService.Domain.DTOs;
using TopChoiceHardware.OrdersService.Domain.Entities;

namespace TopChoiceHardware.OrdersService.Application.Services
{
    public interface IFacturaService
    {
        Factura CreateFactura(FacturaDto ordenProducto);
        List<Factura> GetFactura();
        Factura GetFacturaById(int id);
    }
    public class FacturaService : IFacturaService
    {
        private IGenericRepository _repository;

        public FacturaService(IGenericRepository repository)
        {
            _repository = repository;
        }
        public Factura CreateFactura(FacturaDto factura)
        {
            var entity = new Factura
            {
                UserId = factura.UserId,
                OrdenId = factura.OrdenId,
                Date = factura.Date
            };
            _repository.Add(entity);
            return entity;
        }

        public List<Factura> GetFactura()
        {
            return _repository.GetAll<Factura>();
        }

        public Factura GetFacturaById(int id)
        {
            return _repository.GetById<Factura>(id);
        }
    }
}
