using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.DTO;
using Tienda.Soporte.Application.Features.Appointment.Query;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.Appointment.Handler
{
    class GetAllAppointmentsHandler : IRequestHandler<GetAllAppointmentsQuery, List<AppointmentHasTechnicianDTO>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAllAppointmentsHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<AppointmentHasTechnicianDTO>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Model.Soporte.AppointmentHasTechnician> appointmentHasTechnicians = await _appointmentRepository.GetAppointments();
            List<AppointmentHasTechnicianDTO> appointmentDTOs = new List<AppointmentHasTechnicianDTO>();
            foreach (var item in appointmentHasTechnicians)
            {
                appointmentDTOs.Add(
                    new AppointmentHasTechnicianDTO(
                        item.AppoinmtentHasTechnicianId,
                        item.Appointment,item.Technician
                        )
                    );
            }
            return appointmentDTOs;
        }
    }
}
