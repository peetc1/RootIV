namespace TripTracker.Logic.Interfaces
{
    public interface IFileCommandResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
        string[] Lines { get; set; }
    }
}
