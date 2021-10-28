using System.Collections.Generic;
using TopChoiceHardware.OrdersService.Domain.Commands;
using TopChoiceHardware.OrdersService.Domain.DTOs;
using TopChoiceHardware.OrdersService.Domain.Entities;

namespace TopChoiceHardware.OrdersService.Application.Services
{
    public interface IOrdenProductoService
    {
        OrdenProducto CreateOrdenProducto(OrdenProductoDto ordenProducto);
        List<OrdenProducto> GetOrdenProducto();
        OrdenProducto GetOrdenProductoById(int id);
    }
    public class OrdenProductoService : IOrdenProductoService
    {
        private IGenericRepository _repository;

        public OrdenProductoService(IGenericRepository repository)
        {
            _repository = repository;
        }
        public OrdenProducto CreateOrdenProducto(OrdenProductoDto ordenProducto)
        {
            var entity = new OrdenProducto
            {
                OrdenId = ordenProducto.OrdenId,
                ProductId = ordenProducto.ProductId
            };
            _repository.Add(entity);
            return entity;
        }

        public List<OrdenProducto> GetOrdenProducto()
        {
            return _repository.GetAll<OrdenProducto>();
        }

        public OrdenProducto GetOrdenProductoById(int id)
        {
            return _repository.GetById<OrdenProducto>(id);
        }
    }
}
