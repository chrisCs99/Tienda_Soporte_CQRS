using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.Product.Command;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.Product.Handler
{
    class InsertProductHandler : IRequestHandler<InsertProductCommand, VoidResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<VoidResult> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Model.Soporte.Product product = new Domain.Model.Soporte.Product(
                request.productDTO.ProductBrand, request.productDTO.ProductName, request.productDTO.ProductPrice
                );

            await _productRepository.Insert(product);
            await _unitOfWork.Commit();

            return new VoidResult();
        }
    }
}
