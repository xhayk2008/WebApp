using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;

namespace WebApp.DAL;

public class AppDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<AppData> AppDatas { get; init; }
}
