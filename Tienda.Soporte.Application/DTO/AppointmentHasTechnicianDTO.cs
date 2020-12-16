using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Application.DTO
{
    public class AppointmentHasTechnicianDTO
    {
        public Guid AppoinmtentHasTechnicianId { get; set; }
        public Appointment Appointment { get; set; }
        public Technician Technician { get; set; }

        public AppointmentHasTechnicianDTO(Guid appoinmtentHasTechnicianId, Appointment appointment, Technician technician)
        {
            AppoinmtentHasTechnicianId = appoinmtentHasTechnicianId;
            Appointment = appointment;
            Technician = technician;
        }

        public AppointmentHasTechnicianDTO()
        {
        }
    }
}
