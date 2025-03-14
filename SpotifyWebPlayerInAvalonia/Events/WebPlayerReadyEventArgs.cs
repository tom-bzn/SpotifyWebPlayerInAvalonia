namespace SpotifyWebPlayerInAvalonia.Events;

public class WebPlayerReadyEventArgs : EventArgs
{
    public required string DeviceId { get; init; }
}
