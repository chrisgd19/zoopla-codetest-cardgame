using Microsoft.Extensions.Logging;
using zoopla_codetest_cardgame.Constants;
using zoopla_codetest_cardgame.Models;

namespace zoopla_codetest_cardgame.Services;

public interface IGameService
{
    void PlayGame();
}

public class GameService : IGameService {
    private readonly IDeck _deck;
    private readonly Random _random;
    private readonly ILogger<GameService> _logger;
    
    public GameService(IDeck deck, Random random, ILogger<GameService> logger)
    {
        _deck = deck;
        _random = random;
        _logger = logger;
    }
    
    public void PlayGame()
    {
        _logger.LogInformation(GameMessages.WelcomeMessage);
        
        var numPacks = GetNumberOfPacks();
        var matchCondition = GetMatchCondition();
        
        var deck = _deck.CreateDeck(numPacks);
        var shuffledDeck = _deck.ShuffleDeck(deck);
        
        var winner = Start(shuffledDeck, matchCondition);
        _logger.LogInformation(winner != null ? $"{winner.Name} wins!" : "It's a draw!");

        _logger.LogInformation(GameMessages.GameEndedMessage);
    }
    
    private int GetNumberOfPacks()
    {
        _logger.LogInformation(GameMessages.NumberOfPacksMessage);
        
        int numPacks;
        while (!int.TryParse(Console.ReadLine(), out numPacks) || numPacks <= 0)
        {
            _logger.LogError(GameMessages.InvalidNumberOfPacksMessage);
        }
        
        return numPacks;
    }
    
    private MatchCondition GetMatchCondition()
    {
        _logger.LogInformation(GameMessages.MatchConditionMessage);
        while(true)
        {
            if (Enum.TryParse(Console.ReadLine(), true, out MatchCondition matchCondition))
            {
                return matchCondition;
            }
            
            _logger.LogError(GameMessages.InvalidMatchConditionMessage);
        }
    }
    
    private Player GetWinner(Player[] players)
    {
        return players.OrderByDescending(player => player.Score).FirstOrDefault();
    }
    
    
    private Player Start(List<Card> deck, MatchCondition matchCondition)
    {
        var players = new[] { new Player { Name = "Player 1" }, new Player { Name = "Player 2" } };
        var pile = new List<Card>();

        foreach(var card in deck)
        {
            var matchingCard = pile.LastOrDefault();
            var isMatch = matchingCard != null &&
                ((matchCondition == MatchCondition.Suit && matchingCard.Suit == card.Suit) ||
                (matchCondition == MatchCondition.Value && matchingCard.Value == card.Value) ||
                (matchCondition == MatchCondition.Both && matchingCard.Value == card.Value && matchingCard.Suit == card.Suit));

            if(isMatch)
            {
                var winner = players[_random.Next(0, 2)];
                winner.Score += pile.Count + 1;
                pile.Clear();
            }
            else
            {
                pile.Add(card);
            }
        }
        
        _logger.LogInformation($"{players[0].Name} Score: { players[0].Score }");
        _logger.LogInformation($"{players[1].Name} Score: { players[1].Score }");

        return GetWinner(players);
    }
}