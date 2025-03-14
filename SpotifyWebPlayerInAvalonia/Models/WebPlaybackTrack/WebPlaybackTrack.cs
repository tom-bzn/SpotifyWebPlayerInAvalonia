namespace SpotifyWebPlayerInAvalonia.Models.WebPlaybackTrack;

public record WebPlaybackTrack(
    string Uri, 
    string Id, 
    string Type, 
    string MediaType, 
    string Name, 
    bool IsPlayable, 
    Album Album, 
    Artist[] Artists
);
