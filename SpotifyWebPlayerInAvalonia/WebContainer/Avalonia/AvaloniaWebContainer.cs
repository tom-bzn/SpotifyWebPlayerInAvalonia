using Avalonia.Controls;
using AvaloniaWebView;
using SpotifyWebPlayerInAvalonia.Events;

namespace SpotifyWebPlayerInAvalonia.WebContainer.Avalonia;

internal class AvaloniaWebContainer : IWebContainer
{
    public event EventHandler<MessageReceivedEventArgs>? MessageReceived;

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
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(a.Message));
        };
    }

    public void SendCommand(string command)
    {
        _webView.PostWebMessageAsString(command, null);
    }    
}
