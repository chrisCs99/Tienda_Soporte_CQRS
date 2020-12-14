using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.Appointment.Command;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.Appointment.Handler
{
    class InsertAppointmentHandler : IRequestHandler<InsertAppointmentCommand, VoidResult>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertAppointmentHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(InsertAppointmentCommand request, CancellationToken cancellationToken)
        {
            Domain.Model.Soporte.Appointment appointment = new Domain.Model.Soporte.Appointment(
                request.appointmentDTO.VisitDate, new Domain.Model.Soporte.ServiceOrder(request.appointmentDTO.ServiceOrder.ServiceOrderId));
            await _appointmentRepository.Insert(appointment);
            foreach (TechnicianDTO technician in request.appointmentDTO.Technicians)
            {
                await _appointmentRepository.InsertTechniciansInAppointment(appointment, new Domain.Model.Soporte.Technician(technician.TechnicianId));
            }
                await _unitOfWork.Commit();
            return new VoidResult();
        }
    }
}
