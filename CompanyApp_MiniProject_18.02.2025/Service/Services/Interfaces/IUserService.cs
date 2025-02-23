using Domain.Entities;


namespace Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task RegisterAsync(User user);
        Task<bool> LoginAsync(string email, string password);
    }
}
