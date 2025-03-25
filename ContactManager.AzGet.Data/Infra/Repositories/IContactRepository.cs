using ContactManager.AzGet.Data.Domain.Models;
//using ContactPersistence.Models;

namespace ContactPersistence.Data.Repositories;

public interface IContactRepository
{
    Task<List<Contact>> GetAllAsync();
    Task<List<Contact>> GetByDDDAsync(int ddd);
    Task<Contact?> GetByPhoneAsync(string phone);
    Task<Contact?> GetByIdAsync(Guid id);
}