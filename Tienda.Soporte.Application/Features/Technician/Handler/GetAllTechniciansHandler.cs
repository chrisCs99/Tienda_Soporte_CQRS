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
    class GetAllTechniciansHandler : IRequestHandler<GetAllTechniciansQuery, List<TechnicianDTO>>
    {

        private readonly ITechnicianRepository _technicianRepository;

        public GetAllTechniciansHandler(ITechnicianRepository technicianRepository)
        {
            _technicianRepository = technicianRepository;
        }

        public async Task<List<TechnicianDTO>> Handle(GetAllTechniciansQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Model.Soporte.Technician> technicians = await _technicianRepository.GetTechnicians();
            List<TechnicianDTO> technicianDTOs = new List<TechnicianDTO>();

            foreach (var item in technicians)
            {
                technicianDTOs.Add(
                    new TechnicianDTO(
                        item.TechnicianId,
                        item.Name, item.Lastname,
                        item.CI, item.Phone,
                        item.Email
                        )
                    );
            }

            return technicianDTOs;
        }
    }
}
