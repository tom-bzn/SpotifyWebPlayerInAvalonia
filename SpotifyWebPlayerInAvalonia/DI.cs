using Microsoft.Extensions.DependencyInjection;
using SpotifyWebPlayerInAvalonia.WebContainers;
using SpotifyWebPlayerInAvalonia.WebContainers.Avalonia;

namespace SpotifyWebPlayerInAvalonia;

public static class DI
{
    public static void SetupDI(this IServiceCollection collection)
    {
        collection.AddTransient<ReceiverOfWebPlayerMessages>();
        collection.AddTransient<ISpotifyWebPlayer, SpotifyWebPlayer>();
        collection.AddTransient<IWebContainer, AvaloniaWebContainer>();
    }
}
