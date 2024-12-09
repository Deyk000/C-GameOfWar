using System;
using System.Collections.Generic;
using System.Linq;
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

        Card firstPlayerCard;
        Card secondPlayerCard;

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
            
            pool.Enqueue(firstPlayerCard);
            pool.Enqueue(secondPlayerCard);
            List<Card> deck = GenerateDeck();
            ShuffleDeck(deck);
            DealCardsToPlayers();

            //while(!GameHasWinner())
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
