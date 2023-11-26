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
                .ForMember(g => g.Day, opts => opts.MapFrom(s => s.StartDate.Day))
                .ForMember(g => g.DailySchedules, opts => opts.MapFrom(s => s.Customer));

            CreateProjection<Customer, DailySchedule>()
                .ForMember(g => g.CustomerName, opts => opts.MapFrom(c => c.Name));

            CreateMap<Scheduling, SchedulingDetailsIds>();

            CreateProjection<Customer, CustomerBasicInfo>()
                .ForMember(g => g.CustomerName, opts => opts.MapFrom(c => c.Name));

            CreateProjection<Employee, EmployeeBasicInfo>()
                .ForMember(g => g.EmployeeName, opts => opts.MapFrom(e => e.Name));

            CreateProjection<Procedure, ProcedureBasicInfo>()
                .ForMember(g => g.ProcedureName, opts => opts.MapFrom(p => p.Name));

            CreateProjection<Procedure, ProcedureResponse>();

            CreateProjection<User, UserResponse>();
        }
    }
}
