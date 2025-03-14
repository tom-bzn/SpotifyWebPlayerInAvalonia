using SpotifyWebPlayerInAvalonia.Events;
using SpotifyWebPlayerInAvalonia.Models;
using SpotifyWebPlayerInAvalonia.Models.WebPlaybackState;
using SpotifyWebPlayerInAvalonia.Services;

namespace SpotifyWebPlayerInAvalonia.WebContainer;

internal abstract class BaseWebContainer(ReceiverOfWebPlayerMessages messagesReceiver)
{
    public event EventHandler<WebPlayerReadyEventArgs>? WebPlayerReady;
    public event EventHandler<WebPlaybackStateChangedEventArgs>? WebPlaybackStateChanged;

    public void ReceiveMessage(string message)
    {
        (MessageFromWebPlayerType type, object data) = messagesReceiver.Receive(message);

            if (type == MessageFromWebPlayerType.DeviceId)
            {
                var deviceId = (string)data;
                var eventArgs = new WebPlayerReadyEventArgs { DeviceId = deviceId };
                WebPlayerReady?.Invoke(this, eventArgs);
            }
            else if (type == MessageFromWebPlayerType.PlaybackState)
            {
                var playbackState = (WebPlaybackState)data;
                var eventArgs = new WebPlaybackStateChangedEventArgs { PlaybackState = playbackState };
                WebPlaybackStateChanged?.Invoke(this, eventArgs);
            }
            else
            {
                throw new NotImplementedException($"Message type \"{type}\" has not been implemented yet.");
            }
    }
}