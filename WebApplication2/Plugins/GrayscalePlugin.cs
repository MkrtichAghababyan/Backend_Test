namespace WebApplication2.Plugins
{
    public class GrayscalePlugin:IImagePlugin
    {
        public string Name => "grayscale";

        public void Apply(Stream imageStream, object? parameter)
        {
            Console.WriteLine("[Grayscale] Image converted to grayscale");
        }
    }
}
