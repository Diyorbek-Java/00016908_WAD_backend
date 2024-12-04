using _00016908_backend.models;

namespace _00016908_backend.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllRecept();
        Task<Contact> GetSingleRecept(int id);
        Task CreateRecept(Contact contact);
        Task UpdateRecept(Contact contact);
        Task DeleteRecept(int id);
    }
}
