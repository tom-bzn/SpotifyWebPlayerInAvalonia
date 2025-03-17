namespace SpotifyWebPlayerInAvalonia.Events;

internal class MessageReceivedEventArgs(string rawMessage) : EventArgs
{
    public string RawMessage { get; } = rawMessage;
}
