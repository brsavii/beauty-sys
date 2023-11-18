using AutoMapper;
using Domain.Models;
using Domain.Objects.Requests;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
