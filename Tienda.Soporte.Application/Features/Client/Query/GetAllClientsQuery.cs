using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.Client.Query
{
    public class GetAllClientsQuery : IRequest<List<ClientDTO>>
    {
    }
}
