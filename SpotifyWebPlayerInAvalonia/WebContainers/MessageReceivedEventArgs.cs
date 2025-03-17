namespace SpotifyWebPlayerInAvalonia.WebContainers;

public class MessageReceivedEventArgs(string rawMessage) : EventArgs
{
    public string RawMessage { get; } = rawMessage;
}
