namespace SpotifyWebPlayerInAvalonia.Events;

public class WebPlayerReadyEventArgs(string deviceId) : EventArgs
{
    public string DeviceId { get; } = deviceId;
}
