using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }        
    }

    public class VideoEncoder
    {
        // 1. Define a delegate
        // 2. Define an event based on that delegate
        // 3. Raise the event

        // public delegate void VideoEncoderEventHandler(object source, EventArgs args);
        public delegate void VideoEncoderEventHandler(object source, VideoEventArgs args);

        public event VideoEncoderEventHandler VideoEncoded;

        // In dotnet anyway we already have and EventHandler that can be used instead of following the 3 steps mentioned above
        // public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            System.Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded();
        }

        // protected virtual void OnVideoEncoded()
        // {
        //     if (VideoEncoded != null)
        //     {
        //         VideoEncoded(this, EventArgs.Empty);
        //     }
        // }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs() { Video = video} );
            }
        }
    }
}