/*
 Authors: Ryan Ramkalawan, Joseph Maxim, Tyler Nankishore, David Bond
 Creation Date: 2017/02/21
 Revision Date: 2017/02/21
 Description: CardList class, sets up and defines a generic list of card 
 objects. Uses cloning to create a new list of cards. Copy to ultility 
 method for copying card instances into another cards instance.  
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakLibrary
{
    //public cardList class inherits from generic list class, utlizes ICloneable interface
    public class CardList : List<Card>, ICloneable

       

    //clone method
    //returns a clone of a cardlist
    {
        public object Clone()
        {
            CardList newCards = new CardList();
            foreach (Card sourceCard in this)
            {
                newCards.Add((Card)sourceCard.Clone());

            }
            return newCards;
        }

        /// copyto method for copying card instances into another Cards
        /// instance—used in Deck.Shuffle(). This implementation assumes that
        /// source and target collections are the same size.
        public void CopyTo(CardList targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

        //to string shows players cards as string
        public String ToString(CardList cardsDrawn, int playerNumber)
        {
            String cardsDrawnString = "";

            cardsDrawnString += "\n\nDrawnCards Player " + playerNumber.ToString() + "\n";
            for (int i = 0; i < cardsDrawn.Count(); i++)
            {
                Card tempCard = cardsDrawn.GetCard(i, cardsDrawn);
                cardsDrawnString += tempCard.ToString();
                if (i != 51)
                    cardsDrawnString += ", ";

            }

            return cardsDrawnString;
        }

        //gets a card based on int number
        public Card GetCard(int cardNum, CardList cards)
        {
            
            if (cardNum >= 0 && cardNum <= 51)
                return cards[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum,
                       "Value must be between 0 and 51."));
        }


    }
}