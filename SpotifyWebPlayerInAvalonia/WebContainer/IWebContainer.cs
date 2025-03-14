using SpotifyWebPlayerInAvalonia.Events;

namespace SpotifyWebPlayerInAvalonia.WebContainer;

public interface IWebContainer
{
    public event EventHandler<WebPlayerReadyEventArgs>? WebPlayerReady;
    public event EventHandler<WebPlaybackStateChangedEventArgs>? WebPlaybackStateChanged;

    public void Start(string htmlAndJsContent);
    public void SendCommand(string command);
}
