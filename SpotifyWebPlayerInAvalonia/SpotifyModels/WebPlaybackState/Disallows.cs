namespace SpotifyWebPlayerInAvalonia.SpotifyModels.WebPlaybackState;

public record Disallows(
    bool Pausing,
    bool PeekingNext,
    bool PeekingPrev,
    bool Resuming,
    bool Seeking,
    bool SkippingNext,
    bool SkippingPrev
);
