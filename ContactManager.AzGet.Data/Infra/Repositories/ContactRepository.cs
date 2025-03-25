using ContactManager.AzGet.Data.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactPersistence.Data.Repositories;

public class ContactRepository(ApplicationDbContext dbContext) : IContactRepository
{
    public async Task<List<Contact>> GetAllAsync()
    {
        return await dbContext
            .Contacts
            .ToListAsync();
    }

    public async Task<List<Contact>> GetByDDDAsync(int ddd)
    {
        return await dbContext
            .Contacts
            .Where(o => o.Region.DddCode == ddd)
            .ToListAsync();
    }

    public async Task<Contact?> GetByIdAsync(Guid id)
    {
        return await dbContext
            .Contacts
            .FindAsync(id);
    }

    public async Task<Contact?> GetByPhoneAsync(string phone)
    {
        return await dbContext
            .Contacts
            .Where(o => o.Phone == phone)
            .FirstOrDefaultAsync();
    }
}
