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
    class GetAllJobFormsHandler : IRequestHandler<GetAllJobFormsQuery, List<JobFormDTO>>
    {
        private readonly IJobFormRepository _jobFormRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAllJobFormsHandler(IJobFormRepository jobFormRepository, IAppointmentRepository appointmentRepository)
        {
            _jobFormRepository = jobFormRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<JobFormDTO>> Handle(GetAllJobFormsQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Model.Soporte.JobForm> jobForms = await _jobFormRepository.GetJobForms();
            List<JobFormDTO> jobFormDTOs = new List<JobFormDTO>();
            foreach (var item in jobForms)
            {
                AppointmentDTO appointmentDTO = new AppointmentDTO(
                    item.Appointment.AppointmentId,
                    item.Appointment.Status,
                    item.Appointment.VisitDate,
                    item.Appointment.ServiceOrder
                    );
                jobFormDTOs.Add(
                    new JobFormDTO(
                        item.JobFormId,
                        item.Detail,
                        item.Date,
                        appointmentDTO
                    ));
            }
            return jobFormDTOs;
        }
    }
}
