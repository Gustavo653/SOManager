using Common.Infrastructure;
using SO.Domain.Identity;

namespace SO.Infrastructure
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(long id);
        Task<User> GetUserByUserNameAsync(string userName);
    }
}
