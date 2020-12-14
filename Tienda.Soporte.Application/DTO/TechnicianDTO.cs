using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.SharedKernel.ValueObjects;
using Tienda.SharedKernel.ValueObjects.Email;
using Tienda.SharedKernel.ValueObjects.PhoneNumber;

namespace Tienda.Soporte.Infraestructura.DTO
{
    public class TechnicianDTO
    {
        public TechnicianDTO(Guid technicianId, PersonNameValue name, PersonNameValue lastname, string cI, PhoneNumberValue phone, EmailValue email)
        {
            TechnicianId = technicianId;
            Name = name;
            Lastname = lastname;
            CI = cI;
            Phone = phone;
            Email = email;
        }

        public TechnicianDTO()
        {
        }

        public TechnicianDTO(Guid technicianId)
        {
            TechnicianId = technicianId;
        }

        public Guid TechnicianId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string CI { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
