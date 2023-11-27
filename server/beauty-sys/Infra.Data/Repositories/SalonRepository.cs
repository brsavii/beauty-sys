using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Objects.Responses;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class SalonRepository : BaseRepository<Salon>, ISalonRepository
    {
        public SalonRepository(ConfigContext context) : base(context)
        {
        }
    }
}
