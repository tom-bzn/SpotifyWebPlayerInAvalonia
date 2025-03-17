namespace SpotifyWebPlayerInAvalonia.WebPlayerHtml;

/// <summary>
/// Answers how certain messages and commands are named/understood in html.
/// </summary>
internal static class HtmlContract
{
    public static Dictionary<InputMessageType, string> CommandsWithParam { get; } = new()
    {
        { InputMessageType.SetVolume, "cmd:setVolume:" }, // <- notice ":" at the end, indicating some value will appear after that
        { InputMessageType.RewindTo, "cmd:rewindTo:" },
    };

    public static Dictionary<InputMessageType, string> CommandsWithoutParam { get; } = new()
    {
        { InputMessageType.TogglePlay, "cmd:togglePlay" }, // <- no ":" at the end, no extra value
        { InputMessageType.PlayNextTrack, "cmd:playNextTrack" },
        { InputMessageType.PlayPreviousTrack, "cmd:playPreviousTrack" },
    };

    public static Dictionary<OutputMessageType, string> Messages { get; } = new()
    {
        { OutputMessageType.DeviceId, "DeviceId:" }, // <- notice ":" at the end, some value should be passed
        { OutputMessageType.PlaybackState, "PlaybackState:" },
    };
}
