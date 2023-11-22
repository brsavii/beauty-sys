using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Objects.Responses;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly IMapper _mapper;

        public CustomerRepository(ConfigContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public IQueryable<CustomerBasicInfo> GetCustomerBasicInfo() => _mapper.ProjectTo<CustomerBasicInfo>(_typedContext);
    }
}
