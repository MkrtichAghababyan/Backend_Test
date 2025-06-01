namespace WebApplication2.Plugins
{
    public class ResizePlugin:IImagePlugin
    {
        public string Name => "resize";

        public void Apply(Stream imageStream, object? parameter)
        {
            Console.WriteLine($"[Resize] Image resized to {parameter}px");
        }
    }
}
