using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaWarChallenge
{
    public class Deck
    {
        private Random _random;
        public List<Card> Cards = new List<Card>();
        public Queue<Card> ShuffledCards = new Queue<Card>();
        
        //initialize the full 52 card deck
        public Deck()
        {
            Cards.Add(new Card() { Suit = "Hearts", Value = 2, CardType = "2" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 3, CardType = "3" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 4, CardType = "4" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 5, CardType = "5" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 6, CardType = "6" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 7, CardType = "7" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 8, CardType = "8" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 9, CardType = "9" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 10, CardType = "10" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 11, CardType = "Jack" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 12, CardType = "Queen" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 13, CardType = "King" });
            Cards.Add(new Card() { Suit = "Hearts", Value = 14, CardType = "Ace" });
            Cards.Add(new Card() { Suit = "Spades", Value = 2, CardType = "2" });
            Cards.Add(new Card() { Suit = "Spades", Value = 3, CardType = "3" });
            Cards.Add(new Card() { Suit = "Spades", Value = 4, CardType = "4" });
            Cards.Add(new Card() { Suit = "Spades", Value = 5, CardType = "5" });
            Cards.Add(new Card() { Suit = "Spades", Value = 6, CardType = "6" });
            Cards.Add(new Card() { Suit = "Spades", Value = 7, CardType = "7" });
            Cards.Add(new Card() { Suit = "Spades", Value = 8, CardType = "8" });
            Cards.Add(new Card() { Suit = "Spades", Value = 9, CardType = "9" });
            Cards.Add(new Card() { Suit = "Spades", Value = 10, CardType = "10" });
            Cards.Add(new Card() { Suit = "Spades", Value = 11, CardType = "Jack" });
            Cards.Add(new Card() { Suit = "Spades", Value = 12, CardType = "Queen" });
            Cards.Add(new Card() { Suit = "Spades", Value = 13, CardType = "King" });
            Cards.Add(new Card() { Suit = "Spades", Value = 14, CardType = "Ace" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 2, CardType = "2" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 3, CardType = "3" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 4, CardType = "4" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 5, CardType = "5" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 6, CardType = "6" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 7, CardType = "7" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 8, CardType = "8" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 9, CardType = "9" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 10, CardType = "10" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 11, CardType = "Jack" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 12, CardType = "Queen" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 13, CardType = "King" });
            Cards.Add(new Card() { Suit = "Clubs", Value = 14, CardType = "Ace" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 2, CardType = "2" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 3, CardType = "3" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 4, CardType = "4" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 5, CardType = "5" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 6, CardType = "6" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 7, CardType = "7" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 8, CardType = "8" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 9, CardType = "9" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 10, CardType = "10" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 11, CardType = "Jack" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 12, CardType = "Queen" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 13, CardType = "King" });
            Cards.Add(new Card() { Suit = "Diamonds", Value = 14, CardType = "Ace" });
        }

        //use a Random to shuffle the deck and place them in a queue
        public void Shuffle(Random random)
        {
            _random = random;

            for (int i = Cards.Count - 1; i > -1; i--)
            {
                int x = _random.Next(0, i + 1);
                Card card = Cards.ElementAt(x);
                ShuffledCards.Enqueue(card);
                Cards.Remove(card);
            }
        }

        //deal the cards
        public void Deal(Player player1, Player player2)
        {

            for(int i = ShuffledCards.Count; i > -1; i--)
            {
                //no more cards do nothing
                if (ShuffledCards.Count == 0)
                {
                    break;
                }
                //give player1 first card
                else if (player1.MyCards.Count == player2.MyCards.Count)
                {
                    Card myCard = ShuffledCards.Dequeue();
                    player1.MyCards.Enqueue(myCard);
                }
                //give player2 his card
                else if (player1.MyCards.Count > player2.MyCards.Count)
                {
                    Card myCard = ShuffledCards.Dequeue();
                    player2.MyCards.Enqueue(myCard);
                }
                //ensures even stacks of cards
                else if (player1.MyCards.Count < player2.MyCards.Count)
                {
                    Card myCard = ShuffledCards.Dequeue();
                    player1.MyCards.Enqueue(myCard);
                }
            }
        }
    }
}