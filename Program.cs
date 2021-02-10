using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck TheDeck = new Deck();
            Player Zach = new Player("Zach");
            TheDeck.Shuffle();
            TheDeck.Deal();

            Zach.Draw(TheDeck);
            Zach.Discard();
            Zach.Draw(TheDeck);
            Zach.ShowPlyrHand();
            TheDeck.Reset();
            Zach.Discard();
            Zach.Draw(TheDeck);
            Zach.ShowPlyrHand();
            TheDeck.Reset();
            Zach.ShowPlyrHand();
        }
    }

    public class Card
    {
        public string stringVal;
        public string suit;
        public int val;

        public Card(string stringValInput, string suitInput, int valInput)
        {
            stringVal = stringValInput;
            suit = suitInput;
            val = valInput;
        }
    }

    public class Deck
    {
        public List<Card> cards;
        public string[] stringVal = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        public string[] suit = { "Clubs", "Spades", "Hearts", "Diamonds" };
        public int[] val = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        public Deck()
        {
            cards = new List<Card>();
            DeckReady();
        }

        public Card Deal()
        {
            if (cards.Count > 0)
            {
                Card cardRemove = cards[0];
                cards.RemoveAt(0);
                System.Console.WriteLine(cardRemove.val + " of " + cardRemove.suit);
                return cardRemove;
            }
            return null;
        }

        public void DeckReady()
        {
            for (int i = 0; i < suit.Length; i++)
            {
                for (int j = 0; j < val.Length; j++)
                {
                    cards.Add(new Card(stringVal[j], suit[i], val[j]));
                }
            }
            System.Console.WriteLine("READY TO DEAL, DECK IS READY");
        }

        public void Reset()
        {
            cards.Clear();
            DeckReady();
            System.Console.WriteLine("THE DECK IS RESET");
        }

        public void Shuffle()
        {
            List<Card> CardsShuffled = new List<Card>();
            Random rand = new Random();
            while (cards.Count > 0)
            {
                Card randCard = cards[rand.Next(0, cards.Count)];
                CardsShuffled.Add(randCard);
                cards.Remove(randCard);
            }
            cards = CardsShuffled;
            System.Console.WriteLine("THE DECK IS SHUFFLED");
        }

    }

    public class Player
    {
        public string name;
        public List<Card> PlyrHand;

        public Player(string nameInput)
        {
            name = nameInput;
            PlyrHand = new List<Card>();
        }

        public Card Draw(Deck deck)
        {
            Card card = deck.Deal();
            this.PlyrHand.Add(card);
            return card;
        }

        public void ShowPlyrHand()
        {
            for (int i = 0; i < PlyrHand.Count; i++)
            {
                Console.WriteLine(PlyrHand[i].val + " of " + PlyrHand[i].suit);
            }
        }

        public Card Discard()
        {
            if (this.PlyrHand != null)
            {
                Random rand = new Random();
                int idx = rand.Next(this.PlyrHand.Count);
                Card cardRemove = PlyrHand[idx];
                this.PlyrHand.Remove(cardRemove);
                System.Console.WriteLine(cardRemove.val + " of " + cardRemove.suit + " has been removed.");
                return cardRemove;
            }
            return null;
        }
    }
}