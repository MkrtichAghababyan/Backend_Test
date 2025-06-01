namespace WebApplication2.Plugins
{
    public class BlurPlugin:IImagePlugin
    {
        public string Name => "blur";

        public void Apply(Stream imageStream, object? parameter)
        {
            Console.WriteLine($"[Blur] Applied blur with intensity {parameter}px");
        }
    }
}
