using _00016908_backend.models;

namespace _00016908_backend.Repository
{
    public interface IGroupRepository
    {
        Task<Group> GetByIdAsync(long id);                    // Retrieve a group by ID
        Task<IEnumerable<Group>> GetAllAsync();              // Retrieve all groups
        Task<Group> AddAsync(Group group);                   // Add a new group
        Task<Group> UpdateAsync(Group group);                // Update an existing group
        Task<bool> DeleteAsync(long id);                     // Delete a group by ID
    }
}
