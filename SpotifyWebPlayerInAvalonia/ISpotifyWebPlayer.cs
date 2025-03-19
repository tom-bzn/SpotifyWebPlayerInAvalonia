using SpotifyWebPlayerInAvalonia.PublicEvents;

namespace SpotifyWebPlayerInAvalonia;

public interface ISpotifyWebPlayer
{
    public event EventHandler<WebPlayerReadyEventArgs>? WebPlayerReady;
    public event EventHandler<WebPlaybackStateChangedEventArgs>? WebPlaybackStateChanged;

    public void StartPlayer(string accessToken, string playerName = "Web Player");
    public void TogglePlay();
    public void PlayNextTrack();
    public void PlayPreviousTrack();
    public void SetVolume(VolumeValueObject volume);
    public void RewindTo(uint seconds);
}
