using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Soporte.Domain.Model;
using Tienda.Soporte.Domain.Model.Soporte;

namespace Tienda.Soporte.Infraestructura.DTO
{
    public class AppointmentDTO
    {
        public Guid AppointmentId { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime VisitDate { get; set; }
        public ServiceOrderDTO ServiceOrder { get; set; }
        public List<TechnicianDTO> Technicians { get; set; }

        public AppointmentDTO(Guid appointmentId, AppointmentStatus status, DateTime visitDate, ServiceOrderDTO serviceOrder)
        {
            AppointmentId = appointmentId;
            Status = status;
            VisitDate = visitDate;
            ServiceOrder = serviceOrder;
        }

        public AppointmentDTO(Guid appointmentId)
        {
            AppointmentId = appointmentId;
        }

        public AppointmentDTO()
        {
        }
    }
}
