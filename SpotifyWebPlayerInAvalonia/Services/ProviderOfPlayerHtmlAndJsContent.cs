using System.Reflection;
using CommandType = SpotifyWebPlayerInAvalonia.Models.CommandForWebPlayerType;
using MessageType = SpotifyWebPlayerInAvalonia.Models.MessageFromWebPlayerType;

namespace SpotifyWebPlayerInAvalonia.Services;

internal class ProviderOfPlayerHtmlAndJsContent
{
    private const string PlayerHtmlFileName = "spotify-player.html";

    public string GetHtmlAndJsContent(string accessToken, string playerName = "Spotify Web Player In Avalonia")
    {
        string content = GetContent();
        Dictionary<string, string> placeholdersWithValues = GetPlaceholdersWithValues(accessToken, playerName);

        return FillPlaceholdersWithValues(content, placeholdersWithValues);
    }

    public string CreateCommandWithParam(CommandType commandType, string parameter)
    {
        HtmlContract.CommandsWithParam.TryGetValue(commandType, out string? prefix);

        if (prefix == null)
        {
            throw new ArgumentOutOfRangeException(nameof(commandType), "Command type not found.");
        }

        return prefix + parameter;
    }

    public string CreateCommandWithoutParam(CommandType commandType)
    {
        HtmlContract.CommandsWithParam.TryGetValue(commandType, out string? command);

        if (command == null)
        {
            throw new ArgumentOutOfRangeException(nameof(commandType), "Command type not found.");
        }

        return command;
    }

    private string GetContent()
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
        return new Dictionary<string, string>
        {
            { "[-token-]", accessToken },
            { "[-playerName-]", playerName }
        };
    }
}
