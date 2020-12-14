using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.ServiceOrder.Command
{
    public class CancelationServiceOrderCommand : IRequest<VoidResult>
    {
        public Guid Id { get; set; }

        public CancelationServiceOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}
