using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.ServiceOrder.Query;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.ServiceOrder.Handler
{
    class GetServiceOrderByIdHandler : IRequestHandler<GetServiceOrderByIdQuery, List<ServiceOrderHasProductsDTO>>
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;

        public GetServiceOrderByIdHandler(IServiceOrderRepository serviceOrderRepository)
        {
            _serviceOrderRepository = serviceOrderRepository;
        }

        public async Task<List<ServiceOrderHasProductsDTO>> Handle(GetServiceOrderByIdQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Model.Soporte.ServiceOrderHasProducts> serviceOrderList = await _serviceOrderRepository.GetServiceOrderById(request.Id);
            List<ServiceOrderHasProductsDTO> listResult = new List<ServiceOrderHasProductsDTO>();
            foreach (var item in serviceOrderList)
            {
                ServiceOrderDTO serviceOrderDTO = new ServiceOrderDTO(item.ServiceOrder.ServiceOrderId, item.ServiceOrder.CreationDate,
                        new ClientDTO(item.ServiceOrder.Client.ClientId, item.ServiceOrder.Client.Name,
                        item.ServiceOrder.Client.Lastname, item.ServiceOrder.Client.Phone, item.ServiceOrder.Client.Email,
                        item.ServiceOrder.Client.Address), item.ServiceOrder.Status);

                ProductDTO product = new ProductDTO(item.Product.ProductId, item.Product.ProductBrand, item.Product.ProductName,
                        item.Product.ProductPrice);

                Domain.Model.Soporte.ServiceOrderDetail service = await _serviceOrderRepository.GetDetail(item.ServiceOrder.ServiceOrderId);
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
