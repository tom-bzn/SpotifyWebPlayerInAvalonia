using SpotifyWebPlayerInAvalonia.Events;
using CommandType = SpotifyWebPlayerInAvalonia.Models.CommandForWebPlayerType;
using SpotifyWebPlayerInAvalonia.Services;
using SpotifyWebPlayerInAvalonia.WebContainer;

namespace SpotifyWebPlayerInAvalonia;

internal class WebPlayerFacade(
    ProviderOfPlayerHtmlAndJsContent htmlContentProvider,
    IWebContainer webContainer) : IWebPlayerFacade
{
    public event EventHandler<WebPlayerReadyEventArgs>? WebPlayerReady;
    public event EventHandler<WebPlaybackStateChangedEventArgs>? WebPlaybackStateChanged;

    public void StartPlayer(string accessToken, string playerName = "Web Player in Avalonia")
    {
        string content = htmlContentProvider.GetHtmlAndJsContent(accessToken, playerName);

        webContainer.WebPlayerReady += (s, a) =>
        {
            WebPlayerReady?.Invoke(this, a);
        };

        webContainer.WebPlaybackStateChanged += (s, a) =>
        {
            WebPlaybackStateChanged?.Invoke(this, a);
        };

        webContainer.Start(content);
    }

    public void PlayNextTrack()
    {
        webContainer.SendCommand(HtmlContract.CreateCommandWithoutParam(CommandType.PlayNextTrack));
    }

    public void PlayPreviousTrack()
    {
        webContainer.SendCommand(HtmlContract.CreateCommandWithoutParam(CommandType.PlayPreviousTrack));
    }

    public void SetVolume(VolumeValueObject volume)
    {
        webContainer.SendCommand(HtmlContract.CreateCommandWithParam(CommandType.SetVolume, volume.Volume.ToString()));
    }

    public void RewindTo(uint position)
    {
        webContainer.SendCommand(HtmlContract.CreateCommandWithParam(CommandType.RewindTo, position.ToString()));
    }
}
