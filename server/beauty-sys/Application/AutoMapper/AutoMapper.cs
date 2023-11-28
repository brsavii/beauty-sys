using AutoMapper;
using Domain.Models;
using Domain.Objects.Reponses;
using Domain.Objects.Requests;
using Domain.Objects.Responses;

namespace Application.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            Maps();
        }

        private void Maps()
        {
            CreateMap<CreateProcedureRequest, Procedure>()
                .ForMember(p => p.InsertedAt, opts => opts.MapFrom(c => DateTime.Now));

            CreateProjection<Scheduling, GetSchedulingsToCalendarResponse>()
                .ForMember(g => g.Day, opts => opts.MapFrom(s => s.StartDateTime.Day))
                .ForMember(g => g.DailySchedule.CustomerBasicInfo, opts => opts.MapFrom(s => s.Customer))
                .ForMember(g => g.DailySchedule.EmployeeBasicInfo, opts => opts.MapFrom(s => s.Employee))
                .ForMember(g => g.DailySchedule.ProcedureBasicInfo, opts => opts.MapFrom(s => s.Procedure))
                .ForMember(g => g.DailySchedule.SalonBasicInfo, opts => opts.MapFrom(s => s.Salon))
                .ForMember(g => g.DailySchedule.PaymentBasicInfo, opts => opts.MapFrom(s => s.Payment));

            CreateProjection<Customer, DailySchedule>();

            CreateMap<Scheduling, SchedulingDetailsIds>();

            CreateProjection<Customer, CustomerBasicInfo>();

            CreateProjection<Employee, EmployeeBasicInfo>()
                .ForMember(g => g.JobPositionName, opts => opts.MapFrom(e => e.JobPosition.Name));

            CreateProjection<Procedure, ProcedureBasicInfo>();

            CreateMap<Salon, SalonBasicInfo>();

            CreateMap<Payment, PaymentBasicInfo>();

            CreateProjection<Procedure, ProcedureResponse>();

            CreateProjection<User, UserResponse>();

            CreateMap<CreateJobPositionRequest, JobPosition>()
                 .ForMember(p => p.InsertedAt, opts => opts.MapFrom(c => DateTime.Now));

            CreateMap<JobPosition, JobPositionResponse>();

            CreateMap<Customer, CustomerResponse>();

            CreateMap<Employee, EmployeeResponse>();

            CreateMap<JobPosition, JobPositionResponse>();
        }
    }
}
