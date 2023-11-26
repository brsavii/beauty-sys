using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
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

        public async Task<bool> HasEmployeeWithSameCpf(string cpf) => await _typedContext.AsNoTracking().AnyAsync(e => e.Cpf == cpf);
    }
}
