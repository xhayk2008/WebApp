using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.DAL.Entities;
using WebApp.DAL.Interfaces;

namespace WebApp.DAL.Repository;

public class AppRepository(AppDbContext db) : IAppRepository
{
    public async Task AddAppAsync(string name)
    {
        var newApp = new AppData
        {
            Name = name
        };

        await db.AddAsync(newApp);
        await db.SaveChangesAsync();
    }

    public async Task<AppData?> GetAppAsync(int id)
    {
        var app = await db.AppDatas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        return app;
    }

    public async Task<List<AppData?>> GetAllAppsAsync()
    {
        var apps = new List<AppData?>();

        await foreach (var app in db.AppDatas)
            apps.Add(app);

        return apps;
    }

    public async Task UpdateAppAsync(int id, string? name)
    {
        var app = await db.AppDatas.AsNoTracking().FirstAsync(x => x.Id == id);

        if (name != null)
        {
            app.Name = name;
        }

        db.AppDatas.Update(app);

        await db.SaveChangesAsync();
    }

    public async Task DeleteAppAsync(int id)
    {
        var app = await db.AppDatas.AsNoTracking().FirstAsync(x => x.Id == id);

        db.AppDatas.Remove(app);
        await db.SaveChangesAsync();
    }
}
