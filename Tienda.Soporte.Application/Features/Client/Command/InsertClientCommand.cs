using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.Client.Command
{
    public class InsertClientCommand : IRequest<VoidResult>
    {
        public ClientDTO clientDTO { get; set; }

        public InsertClientCommand(ClientDTO client)
        {
            clientDTO = client;
        }
    }
}
