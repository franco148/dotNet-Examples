namespace EventsAndDelegates
{
    public class MailService
    {
        // public void OnVideoEncoded(object source, EventArgs e)
        // {
        //     System.Console.WriteLine("MailService: Sending an email...");
        // }

        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            System.Console.WriteLine("MailService: Sending an email..." + e.Video.Title);
        }
    }
}