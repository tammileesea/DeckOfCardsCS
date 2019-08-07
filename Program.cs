using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Card
    {
        public string stringVal {get;set;}
        // public string stringVal { get => stringVal1; set => stringVal1 = value; }
        public string suit {get;set;}
        public int val {get;set;}
        public Card (string StringVal, string Suit, int Val)
        {
            stringVal = StringVal;
            suit = Suit;
            val = Val;
            // Console.WriteLine($"Card Value: {StringVal}, Suit: {Suit}, Value: {Val}");
        }
    }

    class Deck
    {
        public List<Card> NewDeck;

        public Deck()
        {
            Reset();
        }
        public List<Card> Reset()
        {
            string[] stringVals = new string[] {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};

            string[] suits = new string[] {"Hearts", "Diamonds", "Spades", "Clubs"};

            int[] values = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};

            NewDeck = new List<Card>();
            {
                for (int i=0; i<suits.Length; i++)
                {
                    for (int j=0; j<values.Length; j++)
                    {
                        NewDeck.Add(new Card(suits[i], stringVals[j], values[j]));
                        // Console.WriteLine($"suit: {suits[i]}, face: {stringVals[j]}, value: {values[j]} ");
                    }
                }
                // Console.WriteLine("DECK SIZE: " + NewDeck.Count);
                return NewDeck;
            }
        }
        public Card TopMost()
        {
            Console.WriteLine($"CARD COUNT {NewDeck.Count}");
            Card lastCard = NewDeck[NewDeck.Count - 1];
            int lastCardPosition = NewDeck.Count - 1;
            NewDeck.RemoveAt(lastCardPosition);
            Console.WriteLine($"CARD COUNT AFTER REMOVE {NewDeck.Count}");
            return lastCard;
        }

        public void Shuffle()
        {
            Random oneCard = new Random();
            for (int i = 0; i < NewDeck.Count; i++)
            {
                int c = oneCard.Next(0, NewDeck.Count-1);
                int d = oneCard.Next(0, NewDeck.Count-1);
                Card temp = NewDeck[c];
                NewDeck[c] = NewDeck[d];
                NewDeck[d] = temp;
            }
            // foreach (Card OneCard in NewDeck)
            // {
            //     Console.WriteLine($"FACE: {OneCard.stringVal}");
            //     Console.WriteLine($"SUIT: {OneCard.suit}");
            //     Console.WriteLine($"VALUE: {OneCard.val}");
            //     Console.WriteLine("*************************");
            // }
        }
    }

    class Player
    {
        public string name {get;set;}
        public List<Card> hand;

        public Player(string nameInput)
        {
            name = nameInput;
            hand = new List<Card>(){};
        }
        public Card draw(Deck playerDeck)
        {
            Card addHand = playerDeck.TopMost();
            hand.Add(addHand);
            Console.WriteLine("++++++++++++++++++++++++++++");
            foreach (Card singleCard in hand)
            {
                Console.WriteLine($"FACE: {singleCard.stringVal}");
                Console.WriteLine($"SUIT: {singleCard.suit}");
                Console.WriteLine($"VALUE: {singleCard.val}");
                Console.WriteLine("*************************");
            }
            return addHand;
        }
        public Card discard(int index)
        {
            if (index >= hand.Count || index < 0)
            {
                return null;
            }
            Card removeCard = hand[index];
            hand.RemoveAt(index);
            Console.WriteLine(removeCard.stringVal);
            Console.WriteLine(removeCard.suit);
            Console.WriteLine(removeCard.val);
            return removeCard; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Deck tammiDeck = new Deck();
            // Console.WriteLine(newDeck.TopMost());
            tammiDeck.Shuffle();
            // Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            // Console.WriteLine("NEW SHUFFLE");
            // newDeck.Shuffle();
            Player tammi = new Player("Tammi");
            Console.WriteLine(tammi.draw(tammiDeck));
            Console.WriteLine(tammi.draw(tammiDeck));
            Console.WriteLine(tammi.draw(tammiDeck));
            Console.WriteLine(tammi.draw(tammiDeck));
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(tammi.discard(2));
            Console.WriteLine(tammi.discard(-17));
            foreach (Card tammiCard in tammi.hand){
                Console.WriteLine($"{tammiCard.stringVal} {tammiCard.suit} {tammiCard.val}");
            }
            // Console.WriteLine(tammi.name);
        }
    }
}
