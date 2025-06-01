using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly PluginManager _pluginManager;

        public ImageController(PluginManager pluginManager)
        {
            _pluginManager = pluginManager;
        }

        [HttpPost("Process")]
        public async Task<IActionResult> ProcessImage([FromForm] IFormFile file, [FromForm] string effectsJson)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Image file is required.");
            }
            var effects = System.Text.Json.JsonSerializer.Deserialize<List<EffectDescriptor>>(effectsJson);
            if (effects == null || effects.Count == 0)
            {
                return BadRequest("At least one effect must be specified.");
            }

            using var inputStream = file.OpenReadStream();
            using var memoryStream = new MemoryStream();
            await inputStream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            foreach (var effect in effects)
            {
                var plugin = _pluginManager.GetPlugin(effect.Name);
                if (plugin != null)
                {
                    plugin.Apply(memoryStream, effect.Parameter);
                }
            }

            memoryStream.Position = 0;
            return File(memoryStream.ToArray(), "application/octet-stream", "processed_" + file.FileName);
        }
    }
}
