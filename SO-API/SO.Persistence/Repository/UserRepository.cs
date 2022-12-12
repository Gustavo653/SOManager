using Common.DataAccess;
using Microsoft.EntityFrameworkCore;
using SO.Domain.Identity;
using SO.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SO.DataAccess.Repository
{
    public class UserRepository : BaseRepository<User, SOContext>, IUserRepository
    {
        public UserRepository(SOContext context) : base(context)
        {
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await GetListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await GetEntities().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await GetEntities().FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
