namespace SpotifyWebPlayerInAvalonia.PublicEvents;

public class WebPlayerReadyEventArgs(string deviceId) : EventArgs
{
    public string DeviceId { get; } = deviceId;
}
