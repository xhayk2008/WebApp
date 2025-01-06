using WebApp.DAL.Entities;

namespace WebApp.BLL.Interfaces;

public interface IAppService
{
    Task<bool> AddAppAsync(string name);
    Task<AppData?> GetAppAsync(int id);
    Task<List<AppData?>> GetAllAppsAsync();
    Task<bool> UpdateAppAsync(int id, string? name);
    Task<bool> DeleteAppAsync(int id);
}
