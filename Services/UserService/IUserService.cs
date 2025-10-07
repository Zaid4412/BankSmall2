using System.Collections.Generic;
using System.Threading.Tasks;
using BankSmall.Models;

public interface IUserService
{
    Task<List<User>> GetAllAsync();              
    Task<User?> GetByIdAsync(int id);            
    Task AddAsync(User user);                     
    Task<bool> UpdateAsync(User user);            
    Task<bool> DeleteAsync(int id);
    Task<bool> IgnoreQueryFilters(User user);
}
