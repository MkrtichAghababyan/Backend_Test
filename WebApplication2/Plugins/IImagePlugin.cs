namespace WebApplication2.Plugins
{
    public interface IImagePlugin
    {
        string Name { get; }
        void Apply(Stream imageStream, object? parameter);
    }
}
