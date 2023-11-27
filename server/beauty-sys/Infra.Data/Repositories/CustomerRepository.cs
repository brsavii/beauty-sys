using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Objects.Reponses;
using Domain.Objects.Responses;
using Infra.Data.Context;
using Microsoft.IdentityModel.Tokens;

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

        public ICollection<CustomerResponse> GetCustomers(int currentPage, int takeQuantity, int? id, string? name)
        {
            var query = GetAll(currentPage, takeQuantity);

            if (id.HasValue)
                query = query.Where(c => c.CustomerId == id.Value);

            if (name != null)
                query = query.Where(c => c.Name.Contains(name));

            return _mapper.ProjectTo<CustomerResponse>(query).ToList();
        }
    }
}
