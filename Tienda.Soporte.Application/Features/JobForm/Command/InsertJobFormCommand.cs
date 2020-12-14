using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.JobForm.Command
{
    public class InsertJobFormCommand : IRequest<VoidResult>
    {
        public JobFormDTO jobFormDTO { get; set; }

        public InsertJobFormCommand(JobFormDTO jobFormDTO)
        {
            this.jobFormDTO = jobFormDTO;
        }
    }
}
