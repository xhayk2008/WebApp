using WebApp.DAL;
using WebApp.DAL.Entities;
using WebApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApp.BLL.Interfaces;

namespace WebApp.BLL.Services;

public class AppService(AppDbContext db,
    IAppRepository repository) : IAppService
{
    public async Task<bool> AddAppAsync(string name)
    {
        var app = await db.AppDatas.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);

        if (app != null)
            return false;

        await repository.AddAppAsync(name);
        return true;
    }

    public async Task<AppData?> GetAppAsync(int id)
    {
        var app = await repository.GetAppAsync(id);

        return app;
    }

    public async Task<List<AppData?>> GetAllAppsAsync()
    {
        var apps = await repository.GetAllAppsAsync();

        return apps;
    }
    public async Task<bool> UpdateAppAsync(int id, string? name)
    {
        var app = await db.AppDatas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (app == null)
            return false;

        await repository.UpdateAppAsync(id, name);
        return true;
    }

    public async Task<bool> DeleteAppAsync(int id)
    {
        var app = await db.AppDatas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        if (app == null)
            return false;

        await repository.DeleteAppAsync(id);
        return true;
    }
}
