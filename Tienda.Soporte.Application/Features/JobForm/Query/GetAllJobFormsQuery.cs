using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.JobForm.Query
{
    public class GetAllJobFormsQuery : IRequest<List<JobFormDTO>>
    {
    }
}
