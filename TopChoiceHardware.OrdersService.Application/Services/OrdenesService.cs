using System.Collections.Generic;
using TopChoiceHardware.OrdersService.Domain.Commands;
using TopChoiceHardware.OrdersService.Domain.DTOs;
using TopChoiceHardware.OrdersService.Domain.Entities;

namespace TopChoiceHardware.OrdersService.Application.Services
{
    public interface IOrdenesService 
    {
        Orden CreateOrden(OrdenDto orden);
        List<Orden> GetOrden();
        Orden GetOrdenById(int id);

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

        public List<Orden> GetOrden()
        {
            return _repository.GetAll<Orden>();
        }

        public Orden GetOrdenById(int id)
        {
            return _repository.GetById<Orden>(id);
        }
    }
}
