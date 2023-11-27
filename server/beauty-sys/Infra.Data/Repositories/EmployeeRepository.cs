using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Objects.Reponses;
using Domain.Objects.Responses;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly IMapper _mapper;

        public EmployeeRepository(ConfigContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public IQueryable<EmployeeBasicInfo> GetEmployeeBasicInfo() => _mapper.ProjectTo<EmployeeBasicInfo>(_typedContext.AsNoTracking());

        public ICollection<EmployeeResponse> GetEmployees(int? id, string? name, int currentPage, int takeQuantity)
        {
            var query = GetAll(currentPage, takeQuantity);

            if (id.HasValue)
                query = query.Where(c => c.EmployeeId == id.Value);

            if (name != null)
                query = query.Where(c => c.Name.Contains(name));

            return _mapper.ProjectTo<EmployeeResponse>(query).ToList();
        }

        public async Task<bool> HasEmployeeWithSameCpf(string cpf) => await _typedContext.AsNoTracking().AnyAsync(e => e.Cpf == cpf);
    }
}
