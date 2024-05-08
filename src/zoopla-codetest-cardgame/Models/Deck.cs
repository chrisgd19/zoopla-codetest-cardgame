namespace zoopla_codetest_cardgame.Models;

public interface IDeck
{
    List<Card> CreateDeck(int numPacks);
    List<Card> ShuffleDeck(List<Card> deck);
}

public class Deck : IDeck
{
    public List<Card> CreateDeck(int numPacks)
    {
        var suits = new[] { "hearts", "diamonds", "clubs", "spades" };
        var values = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        return Enumerable.Range(0, numPacks)
            .SelectMany(_ => suits.SelectMany(suit => values.Select(value => new Card { Suit = suit, Value = value })))
            .ToList();
    }

    public List<Card> ShuffleDeck(List<Card> deck)
    {
        return deck.OrderBy(_ => Guid.NewGuid()).ToList();
    }
}