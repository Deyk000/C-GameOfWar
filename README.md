# Game Of War

This is a "Game Of War" C# project game, created by the following team:

- **[Deyan Georgiev](https://github.com/Deyk000)** - Team Leader, Coder
- **[Alexander Buchkov](https://github.com/Retr0Aa)** - Coder
- **[Stefan](https://github.com/Necr0Lancer)** - Presenter
- **[Kostadin Maystorov](https://github.com/USAAAAAAA)** - Documentation
- **[Victoria Dobreva](https://github.com/Vdb1231)** - Contributor

## Game Rules and Description

**Game of War** is a simple yet exciting card game typically played by two players, using a standard deck of cards. Below are the rules followed in our implementation:

### Rules:

1. The two players start with half of a shuffled deck of cards each.
2. Each turn, both players draw one card from their decks.
3. The player with the higher-value card wins the round and collects both cards.
4. In the case of a tie:
   - Both players place three cards face-down and one card face-up.
   - The player with the higher-value face-up card wins all cards on the table.
5. The game continues until one player collects all the cards.

The winner is the player who successfully captures all cards in the deck.

---

## Project Content

### Structure of the Project:

- **Classes**
  - `Card.cs`
  - `GameManager.cs`
  - `MainMenuScreen.cs`

- **Enums**
  - `CardFace.cs`
  - `CardSuit.cs`

- **Program**
  - `Program.cs`

---

## Classes and Enums

### `Card.cs`
Defines a playing card with a face (value) and suit.

**Methods:**
- `Card(CardFace face, CardSuit suite)` - Constructor for creating a card with a specified face and suit.
- `GetFace()` - Returns a string representation of the card, suitable for display.
- `ToString()` - (Override) Returns a default string representation of the card.

---

### `GameManager.cs`
Handles the core game logic.

**Key Methods:**
- `GenerateDeck()` - Generates a standard deck of 52 cards.
- `ShuffleDeck(List<Card> deck)` - Shuffles the deck using a randomization algorithm.
- `DealCardsToPlayers()` - Deals half of the deck to each player.
- `StartGame()` - Main game loop where players draw cards, and the winner is determined.
- `ProcessWar(Queue<Card> pool)` - Handles tie scenarios ("war" logic).
- `GameHasWinner()` - Checks if the game has a winner.
- `EndGame()` - Ends the game and navigates to the main menu.

---

### `MainMenuScreen.cs`
Manages the main menu and user interactions.

**Key Methods:**
- `StartMenu()` - Loads and displays the main menu.
- `RedrawMenu()` - Handles menu options and navigation.
- `PlayGame()` - Initiates a new game.

---

### `CardFace.cs`
An enum that defines the face values of cards, from `Two` (2) to `Ace` (14).

### `CardSuit.cs`
An enum that defines the suits of cards using Unicode symbols (`♠`, `♣`, `♥`, `♦`).

---

## Program.cs

The entry point of the application. It initializes the main menu and starts the game when prompted by the user.

---

## How to Play

1. Launch the application.
2. Select "Play" from the main menu.
3. Follow the instructions displayed in the console.
4. Press `Enter` to progress through each round.
5. Enjoy the game until a winner is determined!

---

## Contributors

This project was developed as a collaborative team effort with contributions from coding, testing, and presenting to documentation.

### GitHub Repository
[Game Of War Repository](https://github.com/Deyk000/C-GameOfWar)

---

## Acknowledgments

Special thanks to our team and mentor for their guidance and collaboration in developing this project. We hope you enjoy playing the "Game Of War"!

