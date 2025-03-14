using SpotifyWebPlayerInAvalonia.Models.WebPlaybackState;

namespace SpotifyWebPlayerInAvalonia.Events;

public class WebPlaybackStateChangedEventArgs(WebPlaybackState state) : EventArgs
{
    public WebPlaybackState PlaybackState  { get; } = state;
}
