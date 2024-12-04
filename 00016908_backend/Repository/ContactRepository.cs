using _00016908_backend.Data;
using _00016908_backend.models;
using Microsoft.EntityFrameworkCore;

namespace _00016908_backend.Repository
{
    public class ContactRepository
    {
        private readonly ContactManagerContext _context;

        public ContactRepository(ContactManagerContext context)
        {
            _context = context;
        }

        public async Task<Contact> GetByIdAsync(long id)
        {
            return await _context.Contacts
                .Include(c => c.Group) // Include related group if needed
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts
                .Include(c => c.Group) // Include related group if needed
                .ToListAsync();
        }

        public async Task<IEnumerable<Contact>> GetByGroupIdAsync(long groupId)
        {
            return await _context.Contacts
                .Where(c => c.GroupId == groupId)
                .Include(c => c.Group) // Include related group if needed
                .ToListAsync();
        }

        public async Task<Contact> AddAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateAsync(Contact contact)
        {
            var existingContact = await _context.Contacts.FindAsync(contact.Id);
            if (existingContact == null) return null;

            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.Phone = contact.Phone;
            existingContact.Address = contact.Address;
            existingContact.GroupId = contact.GroupId;

            _context.Contacts.Update(existingContact);
            await _context.SaveChangesAsync();
            return existingContact;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null) return false;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
