namespace SpotifyWebPlayerInAvalonia;

/// <summary>
/// A value between 0 and 100.
/// </summary>
public class VolumeValueObject
{
    public uint Volume { get; init; }

    public VolumeValueObject(uint volume)
    {
        if (volume > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(volume), "Volume must be between 0 and 100.");
        }

        Volume = volume;
    }
}
