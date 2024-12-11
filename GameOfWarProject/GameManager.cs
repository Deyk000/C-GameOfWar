using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

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
                    deck.Add(new Card (currentFace,currentSuit ));
                }
            }
            return deck;
        }
        void ShuffleDeck(List<Card> deck)
        {
            Random random = new Random();
            for (int i = 0; i < deck.Count; i++)
            {
                int FirstCardIndex = random.Next(deck.Count);
                Card tempCard = deck[FirstCardIndex];
                deck[FirstCardIndex] = deck[i];
                deck[i] = tempCard;

            }
            
        }

        void DealCardsToPlayers()
        {
            while(deck.Count() > 0)
            {
                Card[] firstTwoDrawnCards = deck.Take(2).ToArray();
                deck.RemoveRange(0, 2);
                firstPlayerDeck.Enqueue(firstTwoDrawnCards[0]);
                secondPlayerDeck.Enqueue(firstTwoDrawnCards[1]);

            }
        }

        void AddCardsToWinner(Queue<Card> loserDeck, Queue<Card> winnerDeck)
        {
            while(loserDeck.Count > 0)
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
            if((int)firstPlayerCard.Face > (int)secondPlayerCard.Face)
            {
                Console.WriteLine("The first player has won the cards!");

                foreach(var card in pool)
                {
                    firstPlayerDeck.Enqueue(card);
                }
            }
            else
{
                Console.WriteLine("The second player has won the cards!");
                foreach (var card in pool)
                {
                    secondPlayerDeck.Enqueue(card);
                }
            }
        }

        Card firstPlayerCard;
        Card secondPlayerCard;

        void ProcessWar(Queue<Card> pool)
        {
            while((int)firstPlayerCard.Face == (int)secondPlayerCard.Face)
            {
                Console.WriteLine("WAR!");
                
                if (firstPlayerDeck.Count == 4)
                {
                    AddCardsToWinner(firstPlayerDeck, secondPlayerDeck);
                    Console.WriteLine("Fisrt player does not have enough cards to continue playing...");
                    break;
                }
                if (secondPlayerDeck.Count < 4)
                {
                    AddCardsToWinner(secondPlayerDeck, firstPlayerDeck);
                    Console.WriteLine("Second player does not have enough cards to continue playing...");
                    break;
                }
                AddWarCardsToPool(pool);
                firstPlayerCard = firstPlayerDeck.Dequeue();
                Console.WriteLine($"First player has drawn: {firstPlayerCard}");
                // Process war is not finished
            }
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

            while(!GameHasWinner())
            {
                Console.ReadLine();
                DealCardsToPlayers();
                Queue<Card> pool = new Queue<Card>();
                pool.Enqueue(firstPlayerCard);
                pool.Enqueue(secondPlayerCard);

            }
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
