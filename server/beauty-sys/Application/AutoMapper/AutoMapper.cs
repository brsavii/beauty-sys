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

        #region Usuario

        private void Maps()
        {
            CreateMap<CreateProcedureRequest, Procedure>();
        }

        #endregion
    }
}
