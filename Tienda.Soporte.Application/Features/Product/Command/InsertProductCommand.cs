using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.Product.Command
{
    public class InsertProductCommand: IRequest<VoidResult>
    {
        public ProductDTO productDTO { get; set; }

        public InsertProductCommand(ProductDTO product)
        {
            productDTO = product;
        }
    }
}
