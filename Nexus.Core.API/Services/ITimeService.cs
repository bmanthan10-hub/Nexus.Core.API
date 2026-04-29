namespace YourProjectName.Services
{
    public interface ITimeService
    {
        string GetTime();
    }

    public class TimeService : ITimeService
    {
        private readonly string _time;

        public TimeService()
        {
            // this time will be set only once when the application starts.
            _time = DateTime.Now.ToLongTimeString();
        }

        public string GetTime() => _time;
    }
}