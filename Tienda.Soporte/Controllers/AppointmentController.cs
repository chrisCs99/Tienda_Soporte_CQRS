using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Application.DTO;
using Tienda.Soporte.Application.Features.Appointment.Command;
using Tienda.Soporte.Application.Features.Appointment.Query;
using Tienda.Soporte.Domain.Model.Soporte;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentController(IAppointmentRepository appointmentRepository,
            IUnitOfWork unitOfWork, IMediator mediator)
        {
            _appointmentRepository = appointmentRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAppointment([FromBody] AppointmentDTO appointment)
        {
            try
            {
                await _mediator.Send(new InsertAppointmentCommand(appointment));
                return Ok(new { 
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

        [HttpPost]
        [Route("cancelAppointment")]
        public async Task<IActionResult> CancelServiceOrder([FromBody] CancellationDTO cancellation)
        {
            try
            {
                await _mediator.Send(new CancellationAppointmentCommand(cancellation.Id));
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);   
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                List<AppointmentHasTechnicianDTO> appointmentList = await _mediator.Send(new GetAllAppointmentsQuery());
                return Ok(new
                {
                    Appoinments = appointmentList
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
                List<AppointmentHasTechnicianDTO> appointments = await _mediator.Send(new GetAppointmentByIdQuery(id));
                return Ok(new
                {
                    Appointment = appointments
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
