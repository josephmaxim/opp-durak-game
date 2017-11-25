/*
 Authors: Ryan Ramkalawan, Joseph Maxim, Tyler Nankishore, David Bond
 Creation Date: 2017/02/21
 Revision Date: 2017/02/21
 Description: Card class, sets up and defines a single playing card for 
 any instances of rank and suit. This class also overloads relational
 operators for card objects 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DurakLibrary
{
    //public card class utilizes ICloneable interface
    public class Card : ICloneable
    {
        //instance attributes
        //was readonly
       public readonly CardRanksEnum rank;
       public readonly CardSuitsEnum suit;
      

        //class attributes
        public static bool isAceHigh = true;
        public static bool useTrumps = false;
        public static CardSuitsEnum trump = CardSuitsEnum.Club;

        public EventHandler CardClicked { get; set; }

        //default constructor
        public Card()
        {

        }

        //parameterized constructor(CardSuitsEnum, CardRanksEnum)
        public Card(CardSuitsEnum newSuit, CardRanksEnum newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        public CardSuitsEnum getCardSuit()
        {
                    
            return suit;
        }

        public CardRanksEnum getCardRank()
        {

            return rank;
        }

        //clone method supports ICloneable interface 
        //returns memberwiseclone
        public object Clone()
        {
            return MemberwiseClone();
        }


        //tostring method
        //returns rank and suit as a string
        public override String ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }

        public String ToString(int playerNumber)
        {
            return "\nCard Drawn Player " + playerNumber + "\nThe " + rank + " of " + suit + "s";
        }

        //gethashcode method
        //returns a unique hashcode number
        public override int GetHashCode()
        {
            return 13 * (int)suit + (int)rank;
        }

        //operator overloading methods
        //returns a boolean 
        public static bool operator ==(Card card1, Card card2)
        {
  
                return (card1.suit == card2.suit) && (card1.rank == card2.rank);
            
        }

        public static bool operator !=(Card card1, Card card2)
        {
        
                return !(card1 == card2);
      
        }

        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        public static bool operator >(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == CardRanksEnum.Ace)
                    {
                        if (card2.rank == CardRanksEnum.Ace)
                            return false;
                        else
                            return true;
                    }
                    else
                    {
                        if (card2.rank == CardRanksEnum.Ace)
                            return false;
                        else
                            return (card1.rank > card2.rank);
                    }
                }
                else
                {
                    return (card1.rank > card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }

        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }

        public static bool operator >=(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == CardRanksEnum.Ace)
                    {
                        return true;
                    }
                    else
                    {
                        if (card2.rank == CardRanksEnum.Ace)
                            return false;
                        else
                            return (card1.rank >= card2.rank);
                    }
                }
                else
                {
                    return (card1.rank >= card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }

        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }



    }
}