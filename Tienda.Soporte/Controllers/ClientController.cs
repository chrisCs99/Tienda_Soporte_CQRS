using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.Client.Command;
using Tienda.Soporte.Application.Features.Client.Query;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IMediator _mediator;

        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IClientRepository clientRepository,
            IUnitOfWork unitOfWork, IMediator mediator)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertClient([FromBody] ClientDTO client)
        {
            try
            {
                await _mediator.Send(new InsertClientCommand(client));
                return Ok(new
                {
                    Ok = true,
                    Message = "Registro insertado exitosamente"
                });
            } catch (Exception e)
            {
                return BadRequest(new { 
                    Ok = false,
                    Error = e
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                List<ClientDTO> clientList = await _mediator.Send(new GetAllClientsQuery());
                return Ok(new { 
                    clients = clientList
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            try
            {
                ClientDTO client = await _mediator.Send(new GetClientByIdQuery(id));
                return Ok(new
                {
                    Client = client
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
