using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.Technician.Command
{
    public class InsertTechnicianCommand : IRequest<VoidResult>
    {
        public TechnicianDTO technicianDTO { get; set; }

        public InsertTechnicianCommand(TechnicianDTO technician)
        {
            technicianDTO = technician;
        }
    }
}
