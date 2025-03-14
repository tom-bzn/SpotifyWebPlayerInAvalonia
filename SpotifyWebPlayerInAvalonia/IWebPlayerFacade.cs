using SpotifyWebPlayerInAvalonia.Events;

namespace SpotifyWebPlayerInAvalonia;

public interface IWebPlayerFacade
{
    public event EventHandler<WebPlayerReadyEventArgs>? WebPlayerReady;
    public event EventHandler<WebPlaybackStateChangedEventArgs>? WebPlaybackStateChanged;

    public void StartPlayer(string accessToken, string playerName = "Web Player");
    public void PlayNextTrack();
    public void PlayPreviousTrack();
    public void SetVolume(VolumeValueObject volume);
    public void RewindTo(uint position); // position in seconds
}
