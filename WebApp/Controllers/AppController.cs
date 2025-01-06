using WebApp.BLL.Interfaces;
using WebApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppController(IAppService appService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAppAsync([FromBody] AppDataParamsModel model)
    {
        bool isSucceed = await appService.AddAppAsync(model.Name);

        return !isSucceed ? BadRequest("Product Exists!") : Ok("App successfully added!");
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<ActionResult<AppData>> GetAppAsync([FromRoute] int id)
    {
        var app = await appService.GetAppAsync(id);

        return app == null ? NotFound($"App with {id} id not found!") : Ok(app);
    }

    [HttpGet]
    [Route("GetAllData")]
    public async Task<ActionResult<List<AppData>>> GetAllApps()
    {
        var apps = await appService.GetAllAppsAsync();

        return apps == null ? NotFound("Nothing in database found!") : Ok(apps);
    }

    [HttpPatch]
    [Route("Get/{id}")]
    public async Task<IActionResult> UpdateAppAsync([FromRoute] int id, [FromBody] AppDataParamsModel model)
    {
        bool isSucceed = await appService.UpdateAppAsync(id, model.Name);

        return !isSucceed ? NotFound($"App with {id} id not found!") : Ok("App successfully updated!");
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAppAsync([FromRoute] int id)
    {
        bool isSucceed = await appService.DeleteAppAsync(id);

        return !isSucceed ? NotFound($"App with {id} id not found or already deleted!") : Ok("App successfully deleted");
    }
}
