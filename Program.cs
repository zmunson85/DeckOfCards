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
            Player Bill = new Player("Bill");
            Player Tom = new Player("Tom");
            Player Dave = new Player("Dave");
            Player Chris = new Player("Chris");
            Player Izac = new Player("Izac");
            Player Collin = new Player("Collin");
            TheDeck.Shuffle();
            TheDeck.Deal();
            Zach.Draw(TheDeck);
            Bill.Draw(TheDeck);
            Tom.Draw(TheDeck);
            Dave.Draw(TheDeck);
            Chris.Draw(TheDeck);
            Izac.Draw(TheDeck);
            Collin.Draw(TheDeck);
            // Zach.Discard();
            // Bill.Discard();
            // Tom.Discard();
            // Dave.Discard();
            // Chris.Discard();
            // Izac.Discard();
            // Collin.Discard();
            Zach.ShowPlyrHand();
            // Bill.ShowPlyrHand();
            // Tom.ShowPlyrHand();
            // Chris.ShowPlyrHand();
            // Dave.ShowPlyrHand();
            // Izac.ShowPlyrHand();
            // Collin.ShowPlyrHand();
        }
    }


    /*______________________________Step 1 CLASS CALLED CARD____________________________________________ */
    /* Give the Card class a property "stringVal" which will hold the value of the card ex. (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King). 
    This "val" should be a string.
    Give the Card a property "suit" which will hold the suit of the card (Clubs, Spades, Hearts, Diamonds).
    Give the Card a property "val" which will hold the numerical value of the card 1-13 as integers. */

    public class Card
    {
        //Class Properties

        public string stringVal; //card property, value of a card in list so its string type.
        public string suit;  //suit value that is a parent to the card properties. cards are chlideren of suits. there are 4 suits.
        public int val; // in order to have a list of 52 cards we use num vals for the cards 1-13,  13 cards each suit, 4suits,  4x13=52.

        public Card(string stringValInput, string suitInput, int valInput)
        {
            stringVal = stringValInput;
            suit = suitInput;
            val = valInput;
        }
    }

    /*______________________________Step 2 CLASS CALLED DECK____________________________________________ */
    /* Give the Deck class a property called "cards" which is a list of Card objects.
When initializing the deck, make sure that it has a list of 52 unique cards as its "cards" property.
Give the Deck a deal method that selects the "top-most" card, removes it from the list of cards, and returns the Card.
Give the Deck a reset method that resets the cards property to contain the original 52 cards.
Give the Deck a shuffle method that randomly reorders the deck's cards. */

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
            System.Console.WriteLine("Cards Ready, Dealing Now...");
        }

        public void Reset()
        {
            cards.Clear();
            DeckReady();
            System.Console.WriteLine("Cards In TheDeck Are Reset");
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


    /*______________________________Step 3 CLASS CALLED Player____________________________________________ */
    /* Give the Player class a name property. {DONE}
    Give the Player a hand property that is a List of type Card. {DONE}{PlyrHand}
    Give the Player a draw method of which draws a card from a deck, adds it to the player's hand and returns the Card.
    Note this method will require reference to a deck object
    Give the Player a discard method which discards the Card at the specified index from the player's hand
    and returns this Card or null if the index does not exist. */


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
            if (this.PlyrHand != null)
            {
                for (int i = 0; i < this.PlyrHand.Count; i++)

                {
                    Console.WriteLine(" showing my hand " + this.PlyrHand[i].stringVal + " of " + this.PlyrHand[i].suit);
                }

            }
            else
            {
                Console.WriteLine("No more cards in The Deck");
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