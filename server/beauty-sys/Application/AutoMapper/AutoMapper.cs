using AutoMapper;
using Domain.Models;
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

            CreateMap<Customer, DailySchedule>()
                .ForMember(g => g.CustomerName, opts => opts.MapFrom(c => c.Name));
        }
    }
}
