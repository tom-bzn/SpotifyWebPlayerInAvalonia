using SpotifyWebPlayerInAvalonia.Models.WebPlaybackState;

namespace SpotifyWebPlayerInAvalonia.Events;

public class WebPlaybackStateChangedEventArgs : EventArgs
{
    public required WebPlaybackState PlaybackState { get; init; }
}
