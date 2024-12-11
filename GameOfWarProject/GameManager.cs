using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfWarProject
{
    public class GameManager
    {
        int totalMoves = 0;
        Queue<Card> firstPlayerDeck = new Queue<Card>();
        Queue<Card> secondPlayerDeck = new Queue<Card>();
        Queue<Card> pool = new Queue<Card>();
        List<Card> deck = new List<Card>();
        List<Card> GenerateDeck()
        {
            CardFace[] faces = (CardFace[])Enum.GetValues(typeof(CardFace));
            CardSuit[] suits = (CardSuit[])Enum.GetValues(typeof(CardSuit));

            for (int suite = 0; suite < suits.Length; suite++)
            {
                for (int face = 0; face < faces.Length; face++)
                {
                    CardFace currentFace = faces[face];
                    CardSuit currentSuit = suits[suite];
                    deck.Add(new Card(currentFace, currentSuit));
                }
            }
            return deck;
        }
        void ShuffleDeck(List<Card> deck)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int swapIndex = random.Next(i + 1);
                (deck[i], deck[swapIndex]) = (deck[swapIndex], deck[i]);
            }
        }

        void LogTotalCards()
        {
            int totalCards = firstPlayerDeck.Count + secondPlayerDeck.Count + pool.Count;
            Console.WriteLine($"Total cards in play: {totalCards}");
        }

        void DealCardsToPlayers()
        {
            while (deck.Count() > 0)
            {
                Card[] firstTwoDrawnCards = deck.Take(2).ToArray();
                deck.RemoveRange(0, 2);
                firstPlayerDeck.Enqueue(firstTwoDrawnCards[0]);
                secondPlayerDeck.Enqueue(firstTwoDrawnCards[1]);

            }
        }

        void AddCardsToWinner(Queue<Card> loserDeck, Queue<Card> winnerDeck)
        {
            while (loserDeck.Count > 0)
            {
                winnerDeck.Enqueue(loserDeck.Dequeue());
            }
        }
        void AddWarCardsToPool(Queue<Card> pool)
        {
            for (int i = 0; i < 3; i++)
            {
                pool.Enqueue(firstPlayerDeck.Dequeue());
                pool.Enqueue(secondPlayerDeck.Dequeue());
            }
        }

        void DetermineRoundWinner(Queue<Card> pool)
        {
            if ((int)firstPlayerCard.Face > (int)secondPlayerCard.Face)
            {
                Console.WriteLine("The first player has won the cards!");
                while (pool.Any())
                {
                    firstPlayerDeck.Enqueue(pool.Dequeue());
                }
            }
            else if ((int)firstPlayerCard.Face < (int)secondPlayerCard.Face)
            {
                Console.WriteLine("The second player has won the cards!");
                while (pool.Any())
                {
                    secondPlayerDeck.Enqueue(pool.Dequeue());
                }
            }
            else
            {
                Console.WriteLine("It's a tie!");
                ProcessWar(pool);
            }
        }

        Card firstPlayerCard;
        Card secondPlayerCard;

        void ProcessWar(Queue<Card> pool)
        {
            while ((int)firstPlayerCard.Face == (int)secondPlayerCard.Face)
            {
                Console.WriteLine("WAR!");

                if (firstPlayerDeck.Count < 4 || secondPlayerDeck.Count < 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A player does not have enough cards to continue war.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    AddCardsToWinner(pool, firstPlayerDeck.Count > secondPlayerDeck.Count ? firstPlayerDeck : secondPlayerDeck);

                    EndGame();
                }

                for (int i = 0; i < 3; i++)
                {
                    pool.Enqueue(firstPlayerDeck.Dequeue());
                    pool.Enqueue(secondPlayerDeck.Dequeue());
                }

                firstPlayerCard = firstPlayerDeck.Dequeue();
                secondPlayerCard = secondPlayerDeck.Dequeue();
                pool.Enqueue(firstPlayerCard);
                pool.Enqueue(secondPlayerCard);

                Console.WriteLine($"First player has drawn: {firstPlayerCard.GetFace()}");
                Console.WriteLine($"Second player has drawn: {secondPlayerCard.GetFace()}");
            }

            DetermineRoundWinner(pool);
        }

        public void StartGame()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(@"
=====================================================================
||                                                               ||
||                  Welcome to the Game of War!                  ||
||                                                               ||
||                                                               ||
|| HOW TO PLAY:                                                 ||
|| + Each of the two players are dealt one half of a shuffled   ||
||   deck of cards.                                             ||
|| + Each turn, each player draws one card from their deck.     ||
|| + The player that drew the card with higher value gets both  ||
||   cards.                                                     ||
|| + Both cards return to the winner's deck.                    ||
|| + If there is a draw, both players place the next three      ||
||   cards face down and then another card face-up. The owner   ||
||   of the higher face-up card gets all the cards on the table.||
||                                                               ||
|| HOW TO WIN:                                                  ||
|| + The player who collects all the cards wins.                ||
||                                                               ||
|| CONTROLS:                                                    ||
|| + Press [Enter] to draw a new card until we have a winner.   ||
||                                                               ||
||                                                               ||
||                          Have fun!                           ||
=====================================================================");

            List<Card> deck = GenerateDeck();
            ShuffleDeck(deck);
            DealCardsToPlayers();

            Console.WriteLine($"First player starts with {firstPlayerDeck.Count} cards.");
            Console.WriteLine($"Second player starts with {secondPlayerDeck.Count} cards.");
            //LogTotalCards();

            while (!GameHasWinner())
            {
                Thread.Sleep(100);

                if (!firstPlayerDeck.Any() || !secondPlayerDeck.Any())
                {
                    break;
                }

                totalMoves++;
                firstPlayerCard = firstPlayerDeck.Dequeue();
                secondPlayerCard = secondPlayerDeck.Dequeue();

                Console.WriteLine($"First player has drawn: {firstPlayerCard.GetFace()}");
                Console.WriteLine($"Second player has drawn: {secondPlayerCard.GetFace()}");

                Queue<Card> pool = new Queue<Card>();
                pool.Enqueue(firstPlayerCard);
                pool.Enqueue(secondPlayerCard);

                if ((int)firstPlayerCard.Face > (int)secondPlayerCard.Face)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The first player has won the cards!");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var card in pool)
                    {
                        firstPlayerDeck.Enqueue(card);
                    }
                }
                else if ((int)firstPlayerCard.Face < (int)secondPlayerCard.Face)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The second player has won the cards!");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var card in pool)
                    {
                        secondPlayerDeck.Enqueue(card);
                    }
                }
                else
                {
                    ProcessWar(pool);
                }

                Console.WriteLine("⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");
                Console.WriteLine($"First player currently has {firstPlayerDeck.Count} cards.");
                Console.WriteLine($"Second player currently has {secondPlayerDeck.Count} cards.");
                Console.WriteLine("⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯⎯");

                //LogTotalCards();
            }

            if (firstPlayerDeck.Any())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"After a total of {totalMoves} moves, the first player has won!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"After a total of {totalMoves} moves, the second player has won!");
                Console.ForegroundColor = ConsoleColor.White;
            }

            EndGame();
        }

        public void EndGame()
        {
            Console.WriteLine("Press Any key to continue");

            Console.ReadKey();

            // Open Main Menu
            Console.Clear();
            MainMenuScreen screen = new MainMenuScreen();
            screen.StartMenu();
        }

        public bool GameHasWinner()
        {
            if (!firstPlayerDeck.Any())
            {
                Console.WriteLine($"After a total of {totalMoves} moves, the second player has won!");
                return true;
            }

            if (!secondPlayerDeck.Any())
            {
                Console.WriteLine($"After a total of {totalMoves} moves, the first player has won!");
                return true;
            }

            return false;
        }

    }
}
