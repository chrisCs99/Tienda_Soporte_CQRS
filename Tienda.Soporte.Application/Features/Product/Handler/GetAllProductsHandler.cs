using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.Product.Query;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.Product.Handler
{
    class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Model.Soporte.Product> product = await _productRepository.GetProducts();
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            foreach (var item in product)
            {
                productDTOs.Add(
                    new ProductDTO(
                        item.ProductId, item.ProductBrand, item.ProductName, item.ProductPrice
                        )
                    );
            }
            return productDTOs;
        }
    }
}
