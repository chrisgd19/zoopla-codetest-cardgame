# Card Game

This is a simple Card game implementation in C#.

## Features

- Choose a number of packs of playing cards.
- Combine them into a single deck.
- Shuffle the deck.
- The first player to declare "Match!" takes all the cards in the pile.

## Todo
- [ ] Add unit tests
- [ ] Add global exception handler

## Prerequisites

- .NET SDK 8 installed on your machine.

## How to Run

1. Navigate to the project directory:

2. Build and run the game:

3. Follow the on-screen instructions to play the game.

4. Open terminal in src/zoopla-codetest-cardgame
```bash
dotnet run zoopla-codetest-cardgame.csproj
```

or

```bash
cd zoopla-codetest-cardgame
dotnet run --project src/zoopla-codetest-cardgame/zoopla-codetest-cardgame.csproj
```

## Game Rules

- "Match!" Game Rules Game Setup
Choose a number of packs of playing cards, and combine them into a single deck. Shuffle the deck.

- Playing the game
Cards are played sequentially from the top of the deck into the pile.
If two cards played sequentially match (see "Match condition" below), the first player to declare "Match!" takes all the cards in the pile. For the purposes of this simulation, the program should choose a random player as having declared "Match!" first.
Play then continues with the next card in the deck, starting a new pile. The game ends when no more cards can be drawn from the deck and no player can declare "Match!". (Any remaining cards in the pile may be discarded.)
The player that has taken the most cards is the winner. The game may end in a draw.

- Match condition
The match condition determines when two cards match for the duration of the game. There are three options:
● The suits of two cards must match
○ Example: "3 of hearts" and "5 of hearts" match because they are both
hearts.
● The values of two cards must match
○ Example: "7 of hearts" and "7 of clubs" match because they both have the value 7.
● Both suit and value must match
○ Example: "Jack of spades" only matches another "Jack of spades"

## Testing

Unit tests are provided in the `tests` directory.
You can run the tests by using the following command

```bash
cd zoopla-codetest-cardgame
dotnet test test/zoopla-codetest-cardgame-unittest.csproj
```