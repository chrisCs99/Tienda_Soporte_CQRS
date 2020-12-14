using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.Technician.Query
{
    public class GetAllTechniciansQuery : IRequest<List<TechnicianDTO>>
    {
    }
}
