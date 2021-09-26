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
    public interface IMetodoPagoService
    {
        MetodoPago CreateMetodoPago(MetodoPagoDto ordenProducto);
        IEnumerable <MetodoPago> GetMetodoPago();
    }
    public class MetodoPagoService : IMetodoPagoService
    {
        private IGenericRepository _repository;

        public MetodoPagoService(IGenericRepository repository)
        {
            _repository = repository;
        }
        public MetodoPago CreateMetodoPago(MetodoPagoDto metodoPago)
        {
            var entity = new MetodoPago
            {
                Title = metodoPago.Title,
                Description = metodoPago.Description
            };
            _repository.Add(entity);
            return entity;
        }

        public IEnumerable<MetodoPago> GetMetodoPago()
        {
            return _repository.GetAll<MetodoPago>().ToArray();
        }
    }
}
