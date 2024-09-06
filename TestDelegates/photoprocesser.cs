namespace Delegates
{
    public class PhotoProcessor
    {

        //Use Delegates when an Eventing pattern is used 
        //When the caller doesn't need to access other properties --> see interface as alternative 

        //Generic Delegates 
        //Action   --> return void 
        //Action<T> -->< return void
        //Func <TREsult>
        //Func <T, TResult>
        //public delegate void PhotoFilterHandler(Photo photo);

        //public void Process(string path, PhotoFilterHandler filterHandler)
        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }
    }

}