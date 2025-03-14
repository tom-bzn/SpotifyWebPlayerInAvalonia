using System.Reflection;
using CommandType = SpotifyWebPlayerInAvalonia.Models.CommandForWebPlayerType;
using MessageType = SpotifyWebPlayerInAvalonia.Models.MessageFromWebPlayerType;

namespace SpotifyWebPlayerInAvalonia.Services;

internal class ProviderOfPlayerHtmlAndJsContent
{
    private const string PlayerHtmlFileName = "spotify-player.html";

    public string GetHtmlAndJsContent(string accessToken, string playerName = "Spotify Web Player In Avalonia")
    {
        string content = ContentWithPlaceholders();
        Dictionary<string, string> placeholdersWithValues = GetPlaceholdersWithValues(accessToken, playerName);

        return FillPlaceholdersWithValues(content, placeholdersWithValues);
    }

    private string ContentWithPlaceholders()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourcePath = $"{assembly.GetName().Name}.{PlayerHtmlFileName}";

        using Stream? stream = assembly.GetManifestResourceStream(resourcePath);
        if (stream == null)
        {
            throw new FileNotFoundException("Resource not found.", PlayerHtmlFileName);
        }

        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }

    private string FillPlaceholdersWithValues(string content, Dictionary<string, string> placeholdersWithValues)
    {
        foreach (KeyValuePair<string, string> entry in placeholdersWithValues)
        {
            content = content.Replace(entry.Key, entry.Value);
        }

        return content;
    }

    private Dictionary<string, string> GetPlaceholdersWithValues(string accessToken, string playerName)
    {
        var placeholdersWithValuesDictionaries = new[]
        {
            TokenAndPlayerName(accessToken, playerName),
            CommandsWithValues(),
            CommandsWithoutValues(),
            Messages(),
        };

        return placeholdersWithValuesDictionaries
            .SelectMany(d => d)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    private Dictionary<string, string> TokenAndPlayerName(string accessToken, string playerName)
    {
        return new Dictionary<string, string>
        {
            { "token", accessToken },
            { "playerName", playerName }
        };
    }

    private Dictionary<string, string> CommandsWithValues()
    {
        var cmdMsgPrefixes = HtmlContract.CommandsWithParam;

        return new Dictionary<string, string>
        {
            { "setVolumeCmdPrefix", cmdMsgPrefixes[CommandType.SetVolume] },
            { "rewindToCmdPrefix", cmdMsgPrefixes[CommandType.RewindTo] }
        };
    }

    private Dictionary<string, string> CommandsWithoutValues()
    {
        var cmdMsg = HtmlContract.CommandsWithoutParam;

        return new Dictionary<string, string>
        {
            { "playNextTrackCmd", cmdMsg[CommandType.PlayNextTrack] },
            { "playPreviousTrackCmd", cmdMsg[CommandType.PlayPreviousTrack] },
            { "togglePlayCmd", cmdMsg[CommandType.TogglePlay] },
        };
    }

    private Dictionary<string, string> Messages()
    {
        var msgPrefixes = HtmlContract.Messages;

        return new Dictionary<string, string>
        {
            { "deviceIdPrefix", msgPrefixes[MessageType.DeviceId] },
            { "playbackStatePrefix", msgPrefixes[MessageType.PlaybackState] }
        };
    }
}
