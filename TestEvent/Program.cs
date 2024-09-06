using ProcessPhoto;

namespace TestEvent
{

    class Program
    {

        static void main(string args[])
        {
            var video = new Video() { Title = "Video1 " }

            var videoEncoder = new VideoEncoder(); // publisher
            var mailService = new MailService(); // subscriber 

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;

            videoEncoder.Encode(video);

        }
    }

    public class MailService
    {
        public void OnVideoEncoded(object? source, VideoEventArgs args)
        {
            Console.WriteLine("Main service sending an email");
        }
    }
}