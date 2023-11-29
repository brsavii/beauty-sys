using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Objects.Reponses;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(ConfigContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int? GetUserIdByNameAndPass(string name, string passowd) => _typedContext.FirstOrDefault(u => u.Name.Equals(name) && u.Password.Equals(passowd))?.UserId;

        public ICollection<UserResponse> GetUsers(int? id, string? name, int currentPage, int takeQuantity)
        {
            var query = GetAll(currentPage, takeQuantity);

            if (id.HasValue)
                query = query.Where(c => c.UserId == id.Value);

            if (name != null)
                query = query.Where(c => c.Name.Contains(name));

            return _mapper.ProjectTo<UserResponse>(query).ToList();
        }

        public async Task<bool> HasUserWithSameName(string name) => await _typedContext.AnyAsync(u => u.Name == name);
    }
}
