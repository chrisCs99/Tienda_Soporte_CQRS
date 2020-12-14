using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.JobForm.Query
{
    public class GetJobFormByIdQuery : IRequest<JobFormDTO>
    {
        public Guid Id { get; set; }

        public GetJobFormByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
