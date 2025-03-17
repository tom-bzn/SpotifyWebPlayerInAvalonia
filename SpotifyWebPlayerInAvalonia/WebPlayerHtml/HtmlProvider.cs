using System.Reflection;

namespace SpotifyWebPlayerInAvalonia.WebPlayerHtml;

internal class HtmlProvider
{
    private const string PlayerHtmlFileName = "spotify-player.html";

    public string GetHtmlAndJsContent(string accessToken, string playerName = "Spotify Web Player In Avalonia")
    {
        string content = GetContent();
        Dictionary<string, string> placeholdersWithValues = GetPlaceholdersWithValues(accessToken, playerName);

        return FillPlaceholdersWithValues(content, placeholdersWithValues);
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
