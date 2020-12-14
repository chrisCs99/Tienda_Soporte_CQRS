using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tienda.Soporte.Application.Features.JobForm.Command;
using Tienda.Soporte.Domain.Persistence;
using Tienda.Soporte.Domain.Persistence.Repository;
using Tienda.Soporte.Infraestructura.Features;

namespace Tienda.Soporte.Application.Features.JobForm.Handler
{
    class InsertJobFormHandler : IRequestHandler<InsertJobFormCommand, VoidResult>
    {
        private readonly IJobFormRepository _jobFormRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertJobFormHandler(IJobFormRepository jobFormRepository, IUnitOfWork unitOfWork)
        {
            _jobFormRepository = jobFormRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(InsertJobFormCommand request, CancellationToken cancellationToken)
        {
            Domain.Model.Soporte.JobForm jobForm = new Domain.Model.Soporte.JobForm(
                request.jobFormDTO.Detail, request.jobFormDTO.Date, 
                new Domain.Model.Soporte.Appointment(request.jobFormDTO.Appointment.AppointmentId)
                );

            await _jobFormRepository.Insert(jobForm);
            await _unitOfWork.Commit();

            return new VoidResult();
        }
    }
}
