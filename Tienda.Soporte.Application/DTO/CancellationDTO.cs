using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Soporte.Infraestructura.DTO
{
    public class CancellationDTO
    {
        public Guid Id { get; set; }

        public CancellationDTO(Guid id)
        {
            Id = id;
        }
    }
}
