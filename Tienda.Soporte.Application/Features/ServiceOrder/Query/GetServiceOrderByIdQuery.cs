using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.ServiceOrder.Query
{
    public class GetServiceOrderByIdQuery : IRequest<List<ServiceOrderHasProductsDTO>>
    {
        public Guid Id { get; set; }

        public GetServiceOrderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
