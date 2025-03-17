namespace SpotifyWebPlayerInAvalonia.SpotifyModels.WebPlaybackState;

public record TrackWindow(
    WebPlaybackTrack.WebPlaybackTrack CurrentTrack,
    WebPlaybackTrack.WebPlaybackTrack[] PreviousTracks,
    WebPlaybackTrack.WebPlaybackTrack[] NextTracks
);
