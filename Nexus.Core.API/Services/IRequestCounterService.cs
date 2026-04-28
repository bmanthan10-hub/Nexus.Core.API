namespace YourProjectName.Services
{
    public interface IRequestCounterService
    {
        int Increment();
    }

    public class RequestCounterService : IRequestCounterService
    {
        private int _count = 0;

        // in every call count will increase
        public int Increment() => ++_count;
    }
}