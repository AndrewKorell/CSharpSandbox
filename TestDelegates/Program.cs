

namespace Delegates
{

    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            Action<Photo> filterHandler = filters.ApplyBrightness;
            //PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            filterHandler += RemoveRedEye;

            processor.Process("photo.jpg", filterHandler);

        }

        public static void RemoveRedEye(Photo photo)
        {
            Console.WriteLine("Remove Red Eye");
        }
    }
}
