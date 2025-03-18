using Microsoft.Extensions.DependencyInjection;
using SpotifyWebPlayerInAvalonia.WebContainers;
using SpotifyWebPlayerInAvalonia.WebContainers.Avalonia;
using SpotifyWebPlayerInAvalonia.WebPlayerHtml;

namespace SpotifyWebPlayerInAvalonia;

public static class DI
{
    public static void SetupDI(this IServiceCollection collection)
    {
        collection.AddTransient<OutputMessagesDecoder>();
        collection.AddTransient<ISpotifyWebPlayer, SpotifyWebPlayer>();
        collection.AddTransient<IWebContainer, AvaloniaWebContainer>();
    }
}
