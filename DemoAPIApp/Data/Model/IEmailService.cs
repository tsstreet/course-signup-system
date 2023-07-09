namespace DemoAPIApp.Data.Model
{
    public interface IEmailService
    {
        bool SendEmail(string recipient, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public bool SendEmail(string recipient, string subject, string body)
        {
            return true; 
        }
    }
}
