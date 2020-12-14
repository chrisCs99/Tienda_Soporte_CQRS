using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.Appointment.Command
{
    public class CancellationAppointmentCommand : IRequest<VoidResult>
    {
        public Guid Id{ get; set; }

        public CancellationAppointmentCommand(Guid id)
        {
            Id = id;
        }
    }
}
