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
    class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, List<ClientDTO>>
    {
        private readonly IClientRepository _clientRepository;

        public GetAllClientsHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientDTO>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Model.Soporte.Client> clients = await _clientRepository.GetClients();
            List<ClientDTO> clientDTOs = new List<ClientDTO>();
            foreach (var item in clients)
            {
                clientDTOs.Add(new ClientDTO(
                    item.ClientId,
                    item.Name, item.Lastname,
                    item.Phone,
                    item.Email, item.Address
                    ));
            }
            return clientDTOs;
        }
    }
}
