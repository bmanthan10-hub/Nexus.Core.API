namespace YourProjectName.Services
{
    public interface IMessageService
    {
        string GetMessage();
    }

    public class MessageService : IMessageService
    {
        public string GetMessage() => "Hello from Message Service";
    }
}