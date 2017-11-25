/*
 Authors: Ryan Ramkalawan, Joseph Maxim, Tyler Nankishore, David Bond
 Creation Date: 2017/02/21
 Revision Date: 2017/02/21
 Description: CardDeck class, creates a deck of playing cards through 
 the cardlist class functionality. Shuffle method to randomize the
 cards in the deck. Get card method to pick a card from the deck.
 Ace high and trump card checks.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DurakLibrary
{
    //public GameDeck class, utlizes ICloneable interface
    public class GameDeck : ICloneable
    {
        //instance attributes
        private CardList cards = new CardList();
        private int cardsRemaining = 0;
        private Card trumpCard = new Card();

        //default constructor, loops through all possible suits and ranks, then adds them to private cardslist
        public GameDeck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((CardSuitsEnum)suitVal, (CardRanksEnum)rankVal));
                    
                }
            }
        }

        //Parameterized Constructor (deck size 52,36 or 20)
        public GameDeck(int deckSize)
        {
            int rankStartingPoint = 0;

           if (deckSize == 52)
            {
                rankStartingPoint = 1;
            }
            else if (deckSize == 36)
            {
                rankStartingPoint = 6;

                //add aces
                cards.Add(new Card((CardSuitsEnum)0, (CardRanksEnum)1));
                cards.Add(new Card((CardSuitsEnum)1, (CardRanksEnum)1));
                cards.Add(new Card((CardSuitsEnum)2, (CardRanksEnum)1));
                cards.Add(new Card((CardSuitsEnum)3, (CardRanksEnum)1));
            }

            else if (deckSize == 20)
            {
                rankStartingPoint = 10;

                //add aces
                cards.Add(new Card((CardSuitsEnum)0, (CardRanksEnum)1));
                cards.Add(new Card((CardSuitsEnum)1, (CardRanksEnum)1));
                cards.Add(new Card((CardSuitsEnum)2, (CardRanksEnum)1));
                cards.Add(new Card((CardSuitsEnum)3, (CardRanksEnum)1));
            }


            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = rankStartingPoint; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((CardSuitsEnum)suitVal, (CardRanksEnum)rankVal));

                }
            }

            

        }


        //Parameterized Constructor (CardList), sets private attribute cardlist to new carlist.
        private GameDeck(CardList newCards)
        {
            cards = newCards;
        }

        //

        //Parameterized constructor, Allows aces to be set high.
        public GameDeck(bool isAceHigh) : this()
        {
            Card.isAceHigh = isAceHigh;
        }

        // Parameterized constructor, Allows a trump suit to be used.        
        public GameDeck(bool useTrumps, CardSuitsEnum trump) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        // Parameterized constructor, Allows aces to be set high and a trump suit
        // to be used.
        public GameDeck(bool isAceHigh, bool useTrumps, CardSuitsEnum trump) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        //clone method
        //returns a new GameDeck object after cloning the cardlist
        public object Clone()
        {
            GameDeck newDeck = new GameDeck(cards.Clone() as CardList);
            return newDeck;
        }

        //shuffle method, randomizes the order of the cardlist, 
        //then uses the copy to method in cardlist to copy over the cards to a new cardlist deck. 
        public void Shuffle(int deckSize)
        {
            if (deckSize == 52)
            {
                CardList newDeck = new CardList();
                bool[] assigned = new bool[52];
                Random sourceGen = new Random();
                for (int i = 0; i < 52; i++)
                {
                    int sourceCard = 0;
                    bool foundCard = false;
                    while (foundCard == false)
                    {
                        sourceCard = sourceGen.Next(52);
                        if (assigned[sourceCard] == false)
                            foundCard = true;
                    }
                    assigned[sourceCard] = true;
                    newDeck.Add(cards[sourceCard]);
                }
                newDeck.CopyTo(cards);
            }
            else if (deckSize == 36)
            {
                CardList newDeck = new CardList();
                bool[] assigned = new bool[36];
                Random sourceGen = new Random();
                for (int i = 0; i < 36; i++)
                {
                    int sourceCard = 0;
                    bool foundCard = false;
                    while (foundCard == false)
                    {
                        sourceCard = sourceGen.Next(36);
                        if (assigned[sourceCard] == false)
                            foundCard = true;
                    }
                    assigned[sourceCard] = true;
                    newDeck.Add(cards[sourceCard]);
                }
                newDeck.CopyTo(cards);
            }
            else if (deckSize == 20)
            {
                CardList newDeck = new CardList();
                bool[] assigned = new bool[20];
                Random sourceGen = new Random();
                for (int i = 0; i < 20; i++)
                {
                    int sourceCard = 0;
                    bool foundCard = false;
                    while (foundCard == false)
                    {
                        sourceCard = sourceGen.Next(20);
                        if (assigned[sourceCard] == false)
                            foundCard = true;
                    }
                    assigned[sourceCard] = true;
                    newDeck.Add(cards[sourceCard]);
                }
                newDeck.CopyTo(cards);
            }

        }

        //getter card method will get card based on int number provided 
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
                return cards[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum,
                       "Value must be between 0 and 51."));
        }


        //draw card from deck
        public Card DrawCard()
        {
            Card card;

            card = cards.First();
            cards.RemoveAt(0);
            return card;
        }


        //draw cards based on int value provided
        public CardList DrawCards(int numberOfCards)
        {
            CardList cardsdrawn = new CardList();

            for (int i = 0; i < numberOfCards; i++)
            {
                cardsdrawn.Add(cards.ElementAt(0));
                cards.RemoveAt(0);
            }

            return cardsdrawn;

        }

        //length of deck
        public int length()
        {
            return cards.Count();
            
        }

        //to string method shows cards in deck as a string
        public String ToString(GameDeck gameDeck1)
        {
            String gameDeckString = "";

            gameDeckString += "\n\nDeckCards\n";
            for (int i = 0; i < gameDeck1.length(); i++)
            {
                Card tempCard = gameDeck1.GetCard(i);
                gameDeckString += tempCard.ToString();
                if (i != 51)
                    gameDeckString += ", ";

            }

            return gameDeckString;
        }

        //get remaining cards in deck
        public int getCardsRemaining()
        {
            return cardsRemaining = cards.Count;
        }

        //get the trump card of the deck
        public Card getTrumpCard()
        {
            return trumpCard;
        }
        //sets the trump card
        public void setTrumpCard(GameDeck deck)
        {

            Card trumpCard;

            trumpCard = deck.DrawCard();
            
            this.trumpCard = trumpCard;
        }


    }
}
