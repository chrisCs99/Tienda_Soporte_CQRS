using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.Technician.Command;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.Technician.Handler
{
    class InsertTechnicianHandler : IRequestHandler<InsertTechnicianCommand, VoidResult>
    {
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertTechnicianHandler(IUnitOfWork unitOfWork, ITechnicianRepository technicianRepository)
        {
            _technicianRepository = technicianRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<VoidResult> Handle(InsertTechnicianCommand request, CancellationToken cancellationToken)
        {
            Domain.Model.Soporte.Technician technician = new Domain.Model.Soporte.Technician(
                request.technicianDTO.Name, request.technicianDTO.Lastname,
                request.technicianDTO.CI, request.technicianDTO.Phone,
                    request.technicianDTO.Email
                );

            await _technicianRepository.Insert(technician);
            await _unitOfWork.Commit();

            return new VoidResult();
        }
    }
}
