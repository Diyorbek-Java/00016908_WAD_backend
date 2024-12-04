using _00016908_backend.Data;
using _00016908_backend.models;

using Microsoft.EntityFrameworkCore;

namespace _00016908_backend.Repository
{
    public class GroupRepository : IGroupRepository
    {

        private readonly ContactManagerContext _context;

        public GroupRepository(ContactManagerContext context)
        {
            _context = context;
        }

        public async Task<Group> GetByIdAsync(long id)
        {
            return await _context.Groups
                .Include(g => g.Contacts)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _context.Groups
                .Include(g => g.Contacts) // Include related contacts if needed
                .ToListAsync();
        }

        public async Task<Group> AddAsync(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task<Group> UpdateAsync(Group group)
        {
            var existingGroup = await _context.Groups.FindAsync(group.Id);
            if (existingGroup == null) return null;

            existingGroup.Name = group.Name;
            existingGroup.Contacts = group.Contacts; // Optional: Update related contacts

            _context.Groups.Update(existingGroup);
            await _context.SaveChangesAsync();
            return existingGroup;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null) return false;

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
