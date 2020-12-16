using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.JobForm.Query;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.DTO;

namespace Tienda.Soporte.Application.Features.JobForm.Handler
{
    class GetJobFormByIdHandler : IRequestHandler<GetJobFormByIdQuery, JobFormDTO>
    {
        private readonly IJobFormRepository _jobFormRepository;

        public GetJobFormByIdHandler(IJobFormRepository jobFormRepository)
        {
            _jobFormRepository = jobFormRepository;
        }

        public async Task<JobFormDTO> Handle(GetJobFormByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Model.Soporte.JobForm jobForm = await _jobFormRepository.GetJobFormById(request.Id);
            ServiceOrderDTO serviceOrderDTO = new ServiceOrderDTO(jobForm.Appointment.ServiceOrder.ServiceOrderId, jobForm.Appointment.ServiceOrder.CreationDate,
                        jobForm.Appointment.ServiceOrder.Status);
            AppointmentDTO appointmentDTO = new AppointmentDTO(
                    jobForm.Appointment.AppointmentId,
                    jobForm.Appointment.Status,
                    jobForm.Appointment.VisitDate,
                    serviceOrderDTO
                    );
            return new JobFormDTO(
                 jobForm.JobFormId, jobForm.Detail, jobForm.Date, appointmentDTO
                );
        }
    }
}
