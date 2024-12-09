using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWarProject
{
    internal class GameManager
    {
        public List<Card> GenerateDeck()
        {
            for (int i = 0; i <= 52; i++)
            {

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
            Queue<Card> firstPlayerDeck = new Queue<Card>();
            Queue<Card> secondPlayerDeck = new Queue<Card>();
            DealCardsToPlayers();






        }
    }
}