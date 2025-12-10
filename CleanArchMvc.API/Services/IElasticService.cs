using CleanArchMvc.API.Models;

namespace CleanArchMvc.API.Services
{
    public interface IElasticService
    {
        // create index
        Task CreateIndexAsync(string indexName);

        //add or update document
        Task<bool> AddOrUpdate(User user);

        //add or update documents in bulk
        Task<bool> AddOrUpdateBulk(IEnumerable<User> users, string indexName);

        //Get user
        Task<User> GetUserAsync(string key);

        //Get All users
        Task<IEnumerable<User>> GetAllUsersAsync();

        //Delete user
        Task<bool> DeleteUserAsync(string key);

        //Delete all
        Task<long?> DeleteAllAsync();

    }
}
