using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.Client.Query;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.Client.Handler
{
    class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientDTO>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientByIdHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientDTO> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Model.Soporte.Client client = await _clientRepository.GetClientById(request.Id);

            return new ClientDTO(
                client.ClientId,
                    client.Name, client.Lastname,
                    client.Phone,
                    client.Email, client.Address
                );
        }
    }
}
