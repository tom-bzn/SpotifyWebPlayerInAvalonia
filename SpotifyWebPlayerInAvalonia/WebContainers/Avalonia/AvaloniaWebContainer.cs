using Avalonia.Controls;
using AvaloniaWebView;

namespace SpotifyWebPlayerInAvalonia.WebContainers.Avalonia;

internal class AvaloniaWebContainer : IWebContainer
{
    public event EventHandler<MessageReceivedEventArgs>? MessageReceived;

    private readonly WebView _webView = new();

    public void Start(string htmlAndJsContent)
    {
        Window window = new()
        {
            Width = 50,
            Height = 50,
            Opacity = 0.1,
            Content = _webView
        };

        window.Show();

        _webView.HtmlContent = htmlAndJsContent;

        _webView.WebMessageReceived += (s, a) =>
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(a.Message));
        };

        window.Hide();
    }

    public void SendCommand(string command)
    {
        _webView.PostWebMessageAsString(command, null);
    }    
}
