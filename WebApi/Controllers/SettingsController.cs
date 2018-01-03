using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[Controller]")]
public class SettingsController : Controller
{
    private readonly ConfigurationContext context;

    public SettingsController(ConfigurationContext context)
    {
        this.context = context;
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> Get()
    {
        IActionResult result = null;
        AppSettings settings = null;

        try
        {
            if ((await context.AppSettings.AnyAsync()) == true)
            {
                settings = await context.AppSettings.FirstOrDefaultAsync();
                result = StatusCode(StatusCodes.Status200OK, settings);
            }
            else
            {
                result = StatusCode(StatusCodes.Status404NotFound, "Can't find any default configuration values");
            }
        }
        catch (Exception ex)
        {
            result = StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }

        return result;
    }
}