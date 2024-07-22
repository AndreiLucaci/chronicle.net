using Chronicle.Application.Repository;
using Chronicle.Domain.Entities;

namespace Chronicle.Application.Services
{
    public interface IUserService
    {
        Task<UserEntity> GetUserByIdAsync(string id);
        Task<UserEntity> RegisterUserAsync(string email, string name);
        Task<IEnumerable<UserEntity>> GetUsersAsync();
    }

    public class UserService() : IUserService
    {
        public Task<UserEntity> GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEntity>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> RegisterUserAsync(string email, string name)
        {
            throw new NotImplementedException();
        }
    }
}
