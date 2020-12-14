using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.Appointment.Command;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.Appointment.Handler
{
    public class CancellationAppointmentHandler : IRequestHandler<CancellationAppointmentCommand, VoidResult>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancellationAppointmentHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(CancellationAppointmentCommand request, CancellationToken cancellationToken)
        {
            await _appointmentRepository.CancelAppointment(request.Id);
            await _unitOfWork.Commit();
            return new VoidResult();
        }
    }
}
