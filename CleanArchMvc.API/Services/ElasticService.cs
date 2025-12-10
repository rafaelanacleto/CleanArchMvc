using CleanArchMvc.API.Models;

namespace CleanArchMvc.API.Services
{
    public class ElasticService : IElasticService
    {
        public Task<bool> AddOrUpdate(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddOrUpdateBulk(IEnumerable<User> users, string indexName)
        {
            throw new NotImplementedException();
        }

        public Task CreateIndexAsync(string indexName)
        {
            throw new NotImplementedException();
        }

        public Task<long?> DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
