using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.ServiceOrder.Command;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.ServiceOrder.Handler
{
    public class CancellationServiceOrderHandler : IRequestHandler<CancelationServiceOrderCommand, VoidResult>
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancellationServiceOrderHandler(IServiceOrderRepository serviceOrderRepository, IUnitOfWork unitOfWork)
        {
            _serviceOrderRepository = serviceOrderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(CancelationServiceOrderCommand request, CancellationToken cancellationToken)
        {
            await _serviceOrderRepository.CancelServiceOrder(request.Id);
            await _unitOfWork.Commit();
            return new VoidResult();
        }
    }
}
