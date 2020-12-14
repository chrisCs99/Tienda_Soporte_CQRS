using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.Client.Command;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.Client.Handler
{
    class InsertClientHandler : IRequestHandler<InsertClientCommand, VoidResult>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertClientHandler(IUnitOfWork unitOfWork, IClientRepository client)
        {
            _unitOfWork = unitOfWork;
            _clientRepository = client;
        }
        public async Task<VoidResult> Handle(InsertClientCommand request, CancellationToken cancellationToken)
        {
            Domain.Model.Soporte.Client objClient = new Domain.Model.Soporte.Client(
                request.clientDTO.Name, request.clientDTO.Lastname,
                    request.clientDTO.Phone,
                    request.clientDTO.Email, request.clientDTO.Address
                );
            await _clientRepository.Insert(objClient);
            await _unitOfWork.Commit();

            return new VoidResult();
        }
    }
}
