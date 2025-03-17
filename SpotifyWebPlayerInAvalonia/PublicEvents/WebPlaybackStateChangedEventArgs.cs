using SpotifyWebPlayerInAvalonia.SpotifyModels.WebPlaybackState;

namespace SpotifyWebPlayerInAvalonia.PublicEvents;

public class WebPlaybackStateChangedEventArgs(WebPlaybackState state) : EventArgs
{
    public WebPlaybackState PlaybackState  { get; } = state;
}
