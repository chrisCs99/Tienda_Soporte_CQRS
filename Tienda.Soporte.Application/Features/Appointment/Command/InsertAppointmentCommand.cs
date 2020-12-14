using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.Appointment.Command
{
    public class InsertAppointmentCommand : IRequest<VoidResult>
    {
        public AppointmentDTO appointmentDTO { get; set; }

        public InsertAppointmentCommand(AppointmentDTO appointmentDTO)
        {
            this.appointmentDTO = appointmentDTO;
        }
    }
}
