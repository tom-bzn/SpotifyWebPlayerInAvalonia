using Microsoft.Extensions.DependencyInjection;
using SpotifyWebPlayerInAvalonia.WebContainers;
using SpotifyWebPlayerInAvalonia.WebContainers.Avalonia;
using SpotifyWebPlayerInAvalonia.WebPlayerHtml;

namespace SpotifyWebPlayerInAvalonia;

public static class DI
{
    public static void AddSpotifyWebPlayerInAvalonia(this IServiceCollection collection)
    {
        collection.AddSingleton<InputMessagesEncoder>();
        collection.AddSingleton<OutputMessagesDecoder>();
        collection.AddSingleton<HtmlProvider>();
        collection.AddTransient<ISpotifyWebPlayer, SpotifyWebPlayer>();
        collection.AddTransient<IWebContainer, AvaloniaWebContainer>();
    }
}
