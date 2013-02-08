
namespace App.Resx
{
    public class ResourcesHelper
    {
        public System.IO.Stream GetImageStream(string resxname)
        {
            return GetType().Assembly.GetManifestResourceStream("App.Resx.Image." + resxname);
        }
    }
}
