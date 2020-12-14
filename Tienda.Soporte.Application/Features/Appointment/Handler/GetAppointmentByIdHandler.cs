using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.DTO;
using Tienda.Soporte.Application.Features.Appointment.Query;
using Tienda.Soporte.Domain.Persistence.Repository;

namespace Tienda.Soporte.Application.Features.Appointment.Handler
{
    class GetAppointmentByIdHandler : IRequestHandler<GetAppointmentByIdQuery, List<AppointmentHasTechnicianDTO>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentByIdHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        async Task<List<AppointmentHasTechnicianDTO>> IRequestHandler<GetAppointmentByIdQuery, List<AppointmentHasTechnicianDTO>>.Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Model.Soporte.AppointmentHasTechnician> appointmentHasTechnician = await _appointmentRepository.GetAppointmentById(request.Id);
            List<AppointmentHasTechnicianDTO> appointmentDTOs = new List<AppointmentHasTechnicianDTO>();
            foreach (var item in appointmentHasTechnician)
            {
                appointmentDTOs.Add(
                    new AppointmentHasTechnicianDTO(
                        item.AppoinmtentHasTechnicianId,
                        item.Appointment, item.Technician
                        )
                    );
            }
            return appointmentDTOs;
        }
    }
}
