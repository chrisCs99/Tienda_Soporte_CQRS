using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.Product.Query
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
