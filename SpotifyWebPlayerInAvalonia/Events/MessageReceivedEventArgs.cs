namespace SpotifyWebPlayerInAvalonia.Events;

public class MessageReceivedEventArgs(string rawMessage) : EventArgs
{
    public string RawMessage { get; } = rawMessage;
}
