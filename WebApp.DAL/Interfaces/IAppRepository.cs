using WebApp.DAL.Entities;

namespace WebApp.DAL.Interfaces;

public interface IAppRepository
{
    Task AddAppAsync(string name);
    Task<AppData?> GetAppAsync(int id);
    Task<List<AppData?>> GetAllAppsAsync();
    Task UpdateAppAsync(int id, string? name);
    Task DeleteAppAsync(int id);
}
