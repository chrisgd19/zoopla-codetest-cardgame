using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using zoopla_codetest_cardgame.Models;
using zoopla_codetest_cardgame.Services;

namespace zoopla_codetest_cardgame;

public class Program {
    private static void Main(string[] _)
    {
        var serviceProvider = ConfigureServiceProvider();
        var gameService = serviceProvider.GetRequiredService<GameService>();
    
        gameService.PlayGame();
    }
    
    private static IServiceProvider ConfigureServiceProvider()
    {
        return new ServiceCollection()
            .AddSingleton<GameService>()
            .AddSingleton<IDeck, Deck>()
            .AddSingleton<Random>()
            .AddLogging(builder =>
            {
                builder.AddConsole();
            })
            .BuildServiceProvider();
    }
}