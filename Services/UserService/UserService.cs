using BankSmall.Data;
using BankSmall.Models;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        user.Deleted = false;

        // تعيين DepartmentId تلقائيًا
 
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    private bool? GetDefaultDepartmentId()
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users
                             .AsNoTracking()
                             .OrderBy(u => u.Id)
                             .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        if (id <= 0) return null;

        return await _context.Users
                             .AsNoTracking()
                             .FirstOrDefaultAsync(u => u.Id == id);
    }

    //public async Task AddAsync(User user)
    //{
    //    if (user == null) throw new ArgumentNullException(nameof(user));

    //    user.Deleted = false;
     
    //    await _context.Users.AddAsync(user);
    //    await _context.SaveChangesAsync();
    //}

    public async Task<bool> UpdateAsync(User user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        var existing = await _context.Users.FindAsync(user.Id);
        if (existing == null) return false;

        existing.Name = user.Name;
        existing.CardNumber = user.CardNumber;

 

        _context.Users.Update(existing);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _context.Users.FindAsync(id);
        if (existing == null) return false;

        existing.Deleted = true;
        

        _context.Users.Update(existing);
        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<List<User>> GetAllIncludingDeletedAsync()
    {
        return await _context.Users
                             .AsNoTracking()
                             .IgnoreQueryFilters()
                             .OrderBy(u => u.Id)
                             .ToListAsync();
    }

   
    public async Task<bool> RestoreAsync(int id)
    {
        var existing = await _context.Users
                                     .IgnoreQueryFilters()
                                     .FirstOrDefaultAsync(u => u.Id == id);
        if (existing == null) return false;

        existing.Deleted = false;
       
        _context.Users.Update(existing);
        await _context.SaveChangesAsync();
        return true;
    }

    public Task<bool> IgnoreQueryFilters(User user)
    {
        throw new NotImplementedException();
    }
}
