
namespace SpotifyWebPlayerInAvalonia.WebContainers;

public interface IWebContainer
{
    public event EventHandler<MessageReceivedEventArgs>? MessageReceived;

    public void Start(string htmlAndJsContent);
    public void SendCommand(string command);
}
