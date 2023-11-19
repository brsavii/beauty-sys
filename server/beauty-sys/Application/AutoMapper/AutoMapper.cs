using AutoMapper;
using Domain.Models;
using Domain.Objects.Requests;

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
        }
    }
}
