using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.Technician.Command;
using Tienda.Soporte.Application.Features.Technician.Query;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TechnicianController(ITechnicianRepository technicianRepository,
            IUnitOfWork unitOfWork, IMediator mediator)
        {
            _technicianRepository = technicianRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertTechnician([FromBody] TechnicianDTO technician)
        {
            try
            {
                await _mediator.Send(new InsertTechnicianCommand(technician));
                return Ok(new
                {
                    Ok = true,
                    Message = "Registro insertado exitosamente"
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Ok = false,
                    Error = e
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTechnicians()
        {
            try
            {
                List<TechnicianDTO> technicianList = await _mediator.Send(new GetAllTechniciansQuery());
                return Ok(new
                {
                    technicians = technicianList
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetTechnicianById(Guid id)
        {
            try
            {
                TechnicianDTO technician = await _mediator.Send(new GetTechnicianByIdQuery(id));
                return Ok(new
                {
                    Technician = technician
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
