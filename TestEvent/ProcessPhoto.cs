namespace ProcessPhoto
{

    public class VideoEventArgs : EventArgs
    {
        public Video? Video { get; set; }
    }

    public class Video
    {
        public string Title { set; get; } = string.Empty;
    }
    public class VideoEncoder
    {
        // how to make an event
        // 1 - Define a delagate
        // 2 - Define an event based on that delegate
        // 3 - raise an event 


        //public delegate void VideoEncodedEventHandler(object source, EventArgs args);

        //instead of delegate 
        //EventHandler 
        //EventHandler<>

        //public event VideoEncodedEventHandler VideoEncoded;
        public event EventHandler<VideoEventArgs>? VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(1000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            EventHandler eventHandler = VideoEncoded;    
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs { Video = video });
        }


    }


}