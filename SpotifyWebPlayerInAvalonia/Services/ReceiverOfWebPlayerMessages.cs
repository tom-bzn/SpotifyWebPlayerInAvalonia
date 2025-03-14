using System.Text.Json;
using SpotifyWebPlayerInAvalonia.Models;
using SpotifyWebPlayerInAvalonia.Models.WebPlaybackState;

namespace SpotifyWebPlayerInAvalonia.Services;

internal class ReceiverOfWebPlayerMessages
{
    /// <summary>
    /// Raw msg comes in a format {Type}: {rest of the msg}
    /// </summary>
    private const string Separator = ": ";

    private readonly JsonSerializerOptions _serializerOptions = new()
        { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };

    public (MessageFromWebPlayerType, object) Receive(string rawMessage)
    {
        (MessageFromWebPlayerType msgType, string remainingData) = Extract(rawMessage);
        object data = ConvertRemainingData(msgType, remainingData);

        return (msgType, data);
    }

    private (MessageFromWebPlayerType, string) Extract(string rawMessage)
    {
        var parts = rawMessage.Split(Separator);

        if (parts.Length < 2)
        {
            throw new ArgumentException("Message is invalid.");
        }

        if (!Enum.TryParse(parts[0], out MessageFromWebPlayerType type))
        {
            throw new ArgumentException("Message type is invalid.");
        }

        return (type, String.Join(Separator, parts[1..]));
    }

    private object ConvertRemainingData(MessageFromWebPlayerType type, string remainingData)
    {
        return type switch
        {
            MessageFromWebPlayerType.DeviceId => remainingData,
            MessageFromWebPlayerType.PlaybackState => Deserialize<WebPlaybackState>(remainingData),
            _ => throw new NotImplementedException($"Message type {type} is not implemented.")
        };
    }

    private T Deserialize<T>(string data)
    {
        return JsonSerializer.Deserialize<T>(data, _serializerOptions) ??
               throw new JsonException("Message deserialization result is null.");
    }
}
