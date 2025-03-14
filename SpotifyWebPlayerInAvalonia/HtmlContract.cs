using CommandType = SpotifyWebPlayerInAvalonia.Models.CommandForWebPlayerType;
using MessageType = SpotifyWebPlayerInAvalonia.Models.MessageFromWebPlayerType;

namespace SpotifyWebPlayerInAvalonia;

/// <summary>
/// Answers how certain messages and commands are named/understood in html.
/// </summary>
internal static class HtmlContract
{
    public static Dictionary<CommandType, string> CommandsWithParam { get; } = new()
    {
        { CommandType.SetVolume, "cmd:setVolume:" }, // <- notice ":" at the end, indicating some value will appear after that
        { CommandType.RewindTo, "cmd:rewindTo:" },
    };

    public static Dictionary<CommandType, string> CommandsWithoutParam { get; } = new()
    {
        { CommandType.TogglePlay, "cmd:togglePlay" }, // <- no ":" at the end, no extra value
        { CommandType.PlayNextTrack, "cmd:playNextTrack" },
        { CommandType.PlayPreviousTrack, "cmd:playPreviousTrack" },
    };

    public static Dictionary<MessageType, string> Messages { get; } = new()
    {
        { MessageType.DeviceId, "DeviceId:" }, // <- notice ":" at the end, some value should be passed
        { MessageType.PlaybackState, "PlaybackState:" },
    };
}
