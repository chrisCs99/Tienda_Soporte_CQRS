using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Application.DTO;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.Appointment.Query
{
    public class GetAppointmentByIdQuery : IRequest<List<AppointmentHasTechnicianDTO>>
    {
        public Guid Id { get; set; }

        public GetAppointmentByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
