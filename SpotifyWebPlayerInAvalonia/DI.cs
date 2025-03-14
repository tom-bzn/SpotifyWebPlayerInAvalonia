using Microsoft.Extensions.DependencyInjection;
using SpotifyWebPlayerInAvalonia.WebContainer;
using SpotifyWebPlayerInAvalonia.WebContainer.Avalonia;

namespace SpotifyWebPlayerInAvalonia;

public static class DI
{
    public static void SetupDI(this IServiceCollection collection)
    {
        collection.AddTransient<ISpotifyWebPlayer, SpotifySpotifyWebPlayer>();
        collection.AddTransient<IWebContainer, AvaloniaWebContainer>();
    }
}
