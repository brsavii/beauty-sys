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

            CreateMap<Scheduling, GetFullSchedulings>()
                .ForMember(g => g.Day, opts => opts.MapFrom(s => s.StartDateTime.Day))
                .ForMember(g => g.TotalValue, opts => opts.MapFrom(s => GetSchedulingValue(s.Procedure.Value, s.Payment.Discount)))
                .ForMember(g => g.CustomerBasicInfo, opts => opts.MapFrom(s => s.Customer))
                .ForMember(g => g.EmployeeBasicInfo, opts => opts.MapFrom(s => s.Employee))
                .ForMember(g => g.ProcedureBasicInfo, opts => opts.MapFrom(s => s.Procedure))
                .ForMember(g => g.SalonBasicInfo, opts => opts.MapFrom(s => s.Salon))
                .ForMember(g => g.PaymentBasicInfo, opts => opts.MapFrom(s => s.Payment));

            CreateMap<GetFullSchedulings, SchedulingDetail>();

            CreateMap<Scheduling, SchedulingDetailsIds>();

            CreateMap<Customer, CustomerBasicInfo>();

            CreateMap<Employee, EmployeeBasicInfo>()
                .ForMember(g => g.JobPositionName, opts => opts.MapFrom(e => e.JobPosition.Name));

            CreateMap<Procedure, ProcedureBasicInfo>();

            CreateMap<Salon, SalonBasicInfo>();

            CreateMap<Payment, PaymentBasicInfo>();

            CreateMap<Procedure, ProcedureResponse>();

            CreateMap<User, UserResponse>();

            CreateMap<CreateJobPositionRequest, JobPosition>()
                 .ForMember(p => p.InsertedAt, opts => opts.MapFrom(c => DateTime.Now));

            CreateMap<CreatePaymentRequest, Payment>()
                 .ForMember(p => p.InsertedAt, opts => opts.MapFrom(c => DateTime.Now));

            CreateMap<CreateCustomerRequest, Customer>()
                 .ForMember(p => p.InsertedAt, opts => opts.MapFrom(c => DateTime.Now));

            CreateMap<CreateEmployeeRequest, Employee>()
                 .ForMember(p => p.InsertedAt, opts => opts.MapFrom(c => DateTime.Now));

            CreateMap<CreateSalonRequest, Salon>()
                 .ForMember(p => p.InsertedAt, opts => opts.MapFrom(c => DateTime.Now));

            CreateMap<CreateSchedulingRequest, Scheduling>()
                .ForMember(p => p.InsertedAt, opts => opts.MapFrom(c => DateTime.Now));

            CreateMap<CreateUserRequest, User>()
                .ForMember(p => p.InsertedAt, opts => opts.MapFrom(c => DateTime.Now));

            CreateMap<JobPosition, JobPositionResponse>();

            CreateMap<Customer, CustomerResponse>();

            CreateMap<Employee, EmployeeResponse>();

            CreateMap<JobPosition, JobPositionResponse>();

            CreateMap<Scheduling, GetSchedulingDetailResponse>()
                .ForMember(p => p.Day, opts => opts.MapFrom(c => c.StartDateTime.Day))
                .ForMember(p => p.Value, opts => opts.MapFrom(c => GetSchedulingValue(c.Procedure.Value, c.Payment.Discount)))
                .ForMember(p => p.SalonName, opts => opts.MapFrom(c => c.Salon.Name))
                .ForMember(p => p.CustomerBasicInfo, opts => opts.MapFrom(c => c.Customer))
                .ForMember(p => p.EmployeeBasicInfo, opts => opts.MapFrom(c => c.Employee))
                .ForMember(p => p.ProcedureBasicInfo, opts => opts.MapFrom(c => c.Procedure));
        }

        private static decimal GetSchedulingValue(decimal value, decimal? discount)
        {
            var schedulingValue = value - discount ?? 0;

            if (schedulingValue < 0)
                throw new InvalidOperationException("O valor do procedimento é negativo");

            return schedulingValue;
        }
    }
}
