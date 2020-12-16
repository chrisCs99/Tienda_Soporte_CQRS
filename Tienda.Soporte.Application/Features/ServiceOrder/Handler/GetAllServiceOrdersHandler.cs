using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Applicacion.Features.ServiceOrder.Query;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Applicacion.Features.ServiceOrder.Handler
{
    public class GetAllServiceOrdersHandler : IRequestHandler<GetAllServiceOrdersQuery, List<ServiceOrderHasProductsDTO>>
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;

        public GetAllServiceOrdersHandler(IServiceOrderRepository serviceOrderRepository)
        {
            _serviceOrderRepository = serviceOrderRepository;
        }

        public async Task<List<ServiceOrderHasProductsDTO>> Handle(GetAllServiceOrdersQuery request, 
            CancellationToken cancellationToken)
        {
            List<ServiceOrderHasProducts> serviceOrderList = await _serviceOrderRepository.GetServiceOrders();
            List<ServiceOrderHasProductsDTO> listResult = new List<ServiceOrderHasProductsDTO>();
            foreach (var item in serviceOrderList)
            {
                ServiceOrderDTO serviceOrderDTO = new ServiceOrderDTO(item.ServiceOrder.ServiceOrderId, item.ServiceOrder.CreationDate,
                        item.ServiceOrder.Status);

                ProductDTO product = new ProductDTO(item.Product.ProductId, item.Product.ProductBrand, item.Product.ProductName,
                        item.Product.ProductPrice);

                ServiceOrderDetail service = await _serviceOrderRepository.GetDetail(item.ServiceOrder.ServiceOrderId);
                ServiceOrderDetailDTO serviceOrderDetailDTO = new ServiceOrderDetailDTO(service.ServiceOrderDetailId, (int)service.ServiceType,
                service.Price, service.Description,
                service.AlternativeAddress);

                listResult.Add(new ServiceOrderHasProductsDTO(
                    item.ServiceOrdersHasProductsId,
                    serviceOrderDTO,
                    product,
                    serviceOrderDetailDTO
                    ));
            }
            return listResult;
        }
    }
}
