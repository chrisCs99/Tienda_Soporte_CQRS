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
                listResult.Add(new ServiceOrderHasProductsDTO(
                    item.ServiceOrdersHasProductsId,
                    item.ServiceOrder,
                    item.Product
                    ));
            }
            return listResult;
        }
    }
}
