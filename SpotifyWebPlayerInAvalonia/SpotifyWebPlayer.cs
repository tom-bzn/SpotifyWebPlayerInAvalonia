using SpotifyWebPlayerInAvalonia.PublicEvents;
using SpotifyWebPlayerInAvalonia.SpotifyModels.WebPlaybackState;
using SpotifyWebPlayerInAvalonia.WebContainers;
using SpotifyWebPlayerInAvalonia.WebPlayerHtml;

namespace SpotifyWebPlayerInAvalonia;

internal class SpotifyWebPlayer(
    HtmlProvider htmlContentProvider,
    MessagesGenerator messagesGenerator,
    IWebContainer webContainer,
    ReceiverOfWebPlayerMessages messagesReceiver) : ISpotifyWebPlayer
{
    public event EventHandler<WebPlayerReadyEventArgs>? WebPlayerReady;
    public event EventHandler<WebPlaybackStateChangedEventArgs>? WebPlaybackStateChanged;

    public void StartPlayer(string accessToken, string playerName = "Web Player in Avalonia")
    {
        string content = htmlContentProvider.GetHtmlAndJsContent(accessToken, playerName);

        webContainer.MessageReceived += (s, args) =>
        {
            ReceiveMessage(args.RawMessage);
        };

        webContainer.Start(content);
    }

    public void PlayNextTrack()
    {
        string message = messagesGenerator.CreateInputMessage(InputMessageType.PlayNextTrack);

        webContainer.SendCommand(message);
    }

    public void PlayPreviousTrack()
    {
        string message = messagesGenerator.CreateInputMessage(InputMessageType.PlayPreviousTrack);

        webContainer.SendCommand(message);
    }

    public void SetVolume(VolumeValueObject volume)
    {
        string message = messagesGenerator.CreateInputMessage(InputMessageType.SetVolume, volume.Volume.ToString());

        webContainer.SendCommand(message);
    }

    public void RewindTo(uint position)
    {
        string message = messagesGenerator.CreateInputMessage(InputMessageType.RewindTo, position.ToString());

        webContainer.SendCommand(message);
    }

    private void ReceiveMessage(string rawMessage)
    {
        (OutputMessageType type, object data) = messagesReceiver.Receive(rawMessage);

        if (type == OutputMessageType.DeviceId)
        {
            var deviceId = (string)data;
            var eventArgs = new WebPlayerReadyEventArgs(deviceId);
            WebPlayerReady?.Invoke(this, eventArgs);
        }
        else if (type == OutputMessageType.PlaybackState)
        {
            var playbackState = (WebPlaybackState)data;
            var eventArgs = new WebPlaybackStateChangedEventArgs(playbackState);
            WebPlaybackStateChanged?.Invoke(this, eventArgs);
        }
        else
        {
            throw new NotImplementedException($"Message type \"{type}\" has not been implemented yet.");
        }
    }
}
