using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaWarChallenge
{
    public class Battle
    {
        //perform the battle
        public string PerformBattle(Player player1, Player player2)
        {
            string resultString = "";
            //select 2 cards
            Card player1Card = player1.MyCards.Dequeue();
            Card player2Card = player2.MyCards.Dequeue();

            //compare the cards and output the appropriate string
            //also add the cards to the winner's stack
            if (player1Card.Value > player2Card.Value)
                resultString += player1Win(player1, player2, player1Card, player2Card);
            else if (player2Card.Value > player1Card.Value)
                resultString += player2Win(player1, player2, player1Card, player2Card);
            else if (player2Card.Value == player1Card.Value)
            {
                resultString += SecondBattle(player1, player2, player1Card, player2Card);
            }
            return resultString;
        }

        //string for player 1 win & add cards to player1's stack
        private string player1Win(Player player1, Player player2, Card player1Card, Card player2Card)
        {
            player1.MyCards.Enqueue(player1Card);
            player1.MyCards.Enqueue(player2Card);
            return String.Format("<br>{0}: {1} of {2}<br>{3}: {4} of {5}<br>" +
                "{0} won ({1} of {2} & {4} of {5})<br>",
                player1.Name, player1Card.CardType, player1Card.Suit,
                player2.Name, player2Card.CardType, player2Card.Suit);
        }

        //string for player 2 win & add cards to player2's stack
        private string player2Win(Player player1, Player player2, Card player1Card, Card player2Card)
        {
            player2.MyCards.Enqueue(player1Card);
            player2.MyCards.Enqueue(player2Card);
            return String.Format("<br>{0}: {1} of {2}<br>{3}: {4} of {5}<br>" +
                "{3} won ({1} of {2} & {4} of {5})<br>",
                player1.Name, player1Card.CardType, player1Card.Suit,
                player2.Name, player2Card.CardType, player2Card.Suit);
        }

        //string for second (war) battle results
        private string SecondBattle(Player player1, Player player2, Card player1Card, Card player2Card)
        {
            string resultString = String.Format("<br>{0} of {1} ties {2} of {3}<br>" +
                    "******WAR******<br>",
                    player1Card.CardType, player1Card.Suit,
                    player2Card.CardType, player2Card.Suit);
            List<Card> cards = new List<Card>();
            List<Card> holdCards = new List<Card>();
            //add current cards to list
            cards.Add(player1Card);
            cards.Add(player2Card);

            begin:
            //add six cards to list
            addCards(player1, player2, cards);
            

            //select the next card for each player
            Card p1Card = player1.MyCards.Dequeue();
            Card p2Card = player2.MyCards.Dequeue();

            //add those cards to list
            cards.Add(p1Card);
            cards.Add(p2Card);

            if (p1Card.Value == p2Card.Value)
            {
                resultString += tieWar(p1Card, p2Card);
                holdCards.Clear();
                goto begin;
            }
            else if (p1Card.Value > p2Card.Value)
                resultString += p1WinWar(cards, player1, p1Card, p2Card);
            else if(p2Card.Value > p1Card.Value)
                resultString += p2WinWar(cards, player2, p1Card, p2Card);
            return resultString;
        }

        //string for tie war
        private string tieWar(Card p1Card, Card p2Card)
        {
            string resultString = "";
            resultString += String.Format("<br>{0} of {1} ties {2} of {3}<br>" +
                    "******WAR******<br>",
                    p1Card.CardType, p1Card.Suit,
                    p2Card.CardType, p2Card.Suit);
            
            return resultString;
        }

        //string for player1 win war & add cards to player1's stack
        private string p1WinWar(List<Card> cards, Player player, Card p1Card, Card p2Card)
        {
            string resultString = "Player 1 wins: <br>";
            resultString += String.Format("Player 1 : {0} of {1}<br>Player 2 : {2} of {3}<br>",
                    p1Card.CardType, p1Card.Suit, p2Card.CardType, p2Card.Suit);
            foreach (Card card in cards)
            {
                player.MyCards.Enqueue(card);
                resultString += String.Format("{0} of {1}<br>",
                    card.CardType, card.Suit);
            }
            return resultString;
        }

        //string for player2 win war & add cards to player2's stack
        private string p2WinWar(List<Card> cards, Player player, Card p1Card, Card p2Card)
        {
            string resultString = "Player 2 wins: <br>";
            resultString += String.Format("Player 1 : {0} of {1}<br>Player 2 : {2} of {3}<br>",
                    p1Card.CardType, p1Card.Suit, p2Card.CardType, p2Card.Suit);
            foreach (Card card in cards)
            {
                player.MyCards.Enqueue(card);
                resultString += String.Format("{0} of {1}<br>",
                    card.CardType, card.Suit);
            }
            return resultString;
        }

        //hold cards in list till after war
        private void addCards(Player player1, Player player2, List<Card> cards)
        {
            cards.Add(player1.MyCards.Dequeue());
            cards.Add(player1.MyCards.Dequeue());
            cards.Add(player1.MyCards.Dequeue());
            cards.Add(player2.MyCards.Dequeue());
            cards.Add(player2.MyCards.Dequeue());
            cards.Add(player2.MyCards.Dequeue());
        }
    }
}