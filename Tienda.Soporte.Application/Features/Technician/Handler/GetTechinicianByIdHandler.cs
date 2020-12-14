using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.Technician.Query;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.Technician.Handler
{
    class GetTechinicianByIdHandler : IRequestHandler<GetTechnicianByIdQuery, TechnicianDTO>
    {
        private readonly ITechnicianRepository _technicianRepository;
            
        public GetTechinicianByIdHandler(ITechnicianRepository techinicianRepository)
        {
            _technicianRepository = techinicianRepository;
        }

        public async Task<TechnicianDTO> Handle(GetTechnicianByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Model.Soporte.Technician item = await _technicianRepository.GetTechnicianById(request.Id);

            return new TechnicianDTO(
                        item.TechnicianId,
                        item.Name, item.Lastname,
                        item.CI, item.Phone,
                        item.Email
                );
        }
    }
}
