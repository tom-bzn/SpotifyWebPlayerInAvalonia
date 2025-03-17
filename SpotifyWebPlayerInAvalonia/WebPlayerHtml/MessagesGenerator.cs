namespace SpotifyWebPlayerInAvalonia.WebPlayerHtml;

internal class MessagesGenerator
{
    public string CreateInputMessage(InputMessageType type)
    {
        HtmlContract.CommandsWithoutParam.TryGetValue(type, out string? command);

        if (command == null)
        {
            throw new ArgumentOutOfRangeException(nameof(type), "Command type not found.");
        }

        return command;
    }

    public string CreateInputMessage(InputMessageType type, string parameter)
    {
        HtmlContract.CommandsWithParam.TryGetValue(type, out string? prefix);

        if (prefix == null)
        {
            throw new ArgumentOutOfRangeException(nameof(type), "Command type not found.");
        }

        return prefix + parameter;
    }
}
