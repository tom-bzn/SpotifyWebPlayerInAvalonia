using SpotifyWebPlayerInAvalonia.Events;
using SpotifyWebPlayerInAvalonia.Models;
using SpotifyWebPlayerInAvalonia.Models.WebPlaybackState;
using CommandType = SpotifyWebPlayerInAvalonia.Models.CommandForWebPlayerType;
using SpotifyWebPlayerInAvalonia.Services;
using SpotifyWebPlayerInAvalonia.WebContainer;

namespace SpotifyWebPlayerInAvalonia;

internal class WebPlayerFacade(
    ProviderOfPlayerHtmlAndJsContent htmlContentProvider,
    IWebContainer webContainer,
    ReceiverOfWebPlayerMessages messagesReceiver) : IWebPlayerFacade
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
        webContainer.SendCommand(htmlContentProvider.CreateCommandWithoutParam(CommandType.PlayNextTrack));
    }

    public void PlayPreviousTrack()
    {
        webContainer.SendCommand(htmlContentProvider.CreateCommandWithoutParam(CommandType.PlayPreviousTrack));
    }

    public void SetVolume(VolumeValueObject volume)
    {
        webContainer.SendCommand(
            htmlContentProvider.CreateCommandWithParam(CommandType.SetVolume, volume.Volume.ToString()));
    }

    public void RewindTo(uint position)
    {
        webContainer.SendCommand(htmlContentProvider.CreateCommandWithParam(CommandType.RewindTo, position.ToString()));
    }

    private void ReceiveMessage(string rawMessage)
    {
        (MessageFromWebPlayerType type, object data) = messagesReceiver.Receive(rawMessage);

        if (type == MessageFromWebPlayerType.DeviceId)
        {
            var deviceId = (string)data;
            var eventArgs = new WebPlayerReadyEventArgs(deviceId);
            WebPlayerReady?.Invoke(this, eventArgs);
        }
        else if (type == MessageFromWebPlayerType.PlaybackState)
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
