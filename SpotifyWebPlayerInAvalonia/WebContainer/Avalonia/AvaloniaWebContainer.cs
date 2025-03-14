using Avalonia.Controls;
using AvaloniaWebView;
using SpotifyWebPlayerInAvalonia.Events;
using SpotifyWebPlayerInAvalonia.Models;
using SpotifyWebPlayerInAvalonia.Models.WebPlaybackState;
using SpotifyWebPlayerInAvalonia.Services;

namespace SpotifyWebPlayerInAvalonia.WebContainer.Avalonia;

internal class AvaloniaWebContainer(ReceiverOfWebPlayerMessages messagesReceiver) : BaseWebContainer(messagesReceiver), IWebContainer
{
    private readonly WebView _webView = new();

    public void Start(string htmlAndJsContent)
    {
        new Window
        {
            IsVisible = false,
            Content = _webView
        }.Show();

        _webView.HtmlContent = htmlAndJsContent;

        _webView.WebMessageReceived += (s, a) =>
        {
            ReceiveMessage(a.Message);
        };
    }

    public void SendCommand(string command)
    {
        _webView.PostWebMessageAsString(command, null);
    }    
}
