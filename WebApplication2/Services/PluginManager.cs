using WebApplication2.Plugins;

namespace WebApplication2.Services
{
    public class PluginManager
    {
        private readonly Dictionary<string, IImagePlugin> _plugins = new();

        public PluginManager()
        {
            RegisterPlugin(new ResizePlugin());
            RegisterPlugin(new GrayscalePlugin());
            RegisterPlugin(new BlurPlugin());
        }

        public void RegisterPlugin(IImagePlugin plugin)
        {
            _plugins[plugin.Name.ToLower()] = plugin;
        }

        public IImagePlugin? GetPlugin(string name)
        {
            return _plugins.TryGetValue(name.ToLower(), out var plugin) ? plugin : null;
        }
    }
}
