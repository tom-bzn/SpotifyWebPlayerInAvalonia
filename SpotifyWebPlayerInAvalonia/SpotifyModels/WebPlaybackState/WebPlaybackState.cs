namespace SpotifyWebPlayerInAvalonia.SpotifyModels.WebPlaybackState;

public record WebPlaybackState(
    Disallows Disallows,
    bool Paused,
    long Position,
    long Duration,
    int RepeatMode,
    bool Shuffle,
    TrackWindow TrackWindow,
    Context? Context = null
);
