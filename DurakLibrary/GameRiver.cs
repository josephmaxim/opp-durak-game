/*
 Authors: Ryan Ramkalawan, Joseph Maxim, Tyler Nankishore, David Bond
 Creation Date: 2017/02/21
 Revision Date: 2017/02/21
 Description: GameRiver class, this class will hold a list of the cards
 that are at the center of the gameplay. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakLibrary
{
    public class GameRiver: ICloneable 
    {
        //instance attributes
        CardList gameRiver = new CardList();
        private int riverCardsRemaning = 0;




        //addcardtoriver method, will add a card to river
        public void AddCardToRiver(Card card)
        {
            gameRiver.Add(card);
            riverCardsRemaning = gameRiver.Count();
        }

        //removecardfromriver method, will remove a card from the river
        public void RemoveCardFromRiver(Card card)
        {
            gameRiver.Remove(card);
            riverCardsRemaning = gameRiver.Count();
        }

        //shows the length of the river
        public int length()
        {
            return gameRiver.Count();

        }


        //will get the card based on int value
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
                return gameRiver[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum,
                       "Value must be between 0 and 51."));
        }

        //clones the river cards
        public object Clone()
        {
            GameRiver newGameRiver = new GameRiver(gameRiver.Clone() as CardList);
            return newGameRiver;
        }

        //parameriterized constructor sets new gameriver
        private GameRiver(CardList newGameRiver)
        {
            gameRiver = newGameRiver;
        }

        //default constructor
        public GameRiver()
        {

        }

        //clears the river
        public void ClearRiver()
        {
            gameRiver.Clear();
        }




        //will compare the cards enetered into the river 
        public bool cardRiverComparison(Card trumpCard)
        {

            
            String defendedString = "";
            bool defended = false;

            switch(gameRiver.Count)
            {

                case 2:
                    if (gameRiver[1].suit == gameRiver[0].suit | gameRiver[1].suit == trumpCard.getCardSuit())
                    {
                        if (gameRiver[1] > gameRiver[0] | gameRiver[1].suit == trumpCard.getCardSuit())
                        {
                            defendedString += "\nThis Card defended: " + gameRiver[1].ToString();
                            defended = true;
                        }
                        else
                        {
                            defendedString += "\nThis Card DIDNOT defend: " + gameRiver[1].ToString();
                        }
                    }
                    else
                    {
                        defendedString += "Not the same suit";
                    }          
                    break;

                case 4:
                    if (gameRiver[3].suit == gameRiver[2].suit | gameRiver[1].suit == trumpCard.getCardSuit())
                    {
                        if (gameRiver[3] > gameRiver[2] | gameRiver[1].suit == trumpCard.getCardSuit())
                        {
                            defendedString += "\nThis Card defended: " + gameRiver[3].ToString();
                            defended = true;
                        }
                        else
                        {
                            defendedString += "\nThis Card DIDNOT defend: " + gameRiver[3].ToString();
                        }
                    }
                    else
                    {
                        defendedString += "Not the same suit";
                    }
                    break;

                case 6:
                    if (gameRiver[5].suit == gameRiver[4].suit | gameRiver[1].suit == trumpCard.getCardSuit())
                    {
                        if (gameRiver[5] > gameRiver[4] | gameRiver[1].suit == trumpCard.getCardSuit())
                        {
                            defendedString += "\nThis Card defended: " + gameRiver[5].ToString();
                            defended = true;
                        }
                        else
                        {
                            defendedString += "\nThis Card DIDNOT defend: " + gameRiver[5].ToString();
                        }
                    }
                    else
                    {
                        defendedString += "Not the same suit";
                    }
                    break;

                case 8:
                    if (gameRiver[7].suit == gameRiver[6].suit | gameRiver[1].suit == trumpCard.getCardSuit())
                    {
                        if (gameRiver[7] > gameRiver[6] | gameRiver[1].suit == trumpCard.getCardSuit())
                        {
                            defendedString += "\nThis Card defended: " + gameRiver[7].ToString();
                            defended = true;
                        }
                        else
                        {
                            defendedString += "\nThis Card DIDNOT defend: " + gameRiver[7].ToString();
                        }
                    }
                    else
                    {
                        defendedString += "Not the same suit";
                    }
                    break;

            }

            return defended;



        }


        //to string will output as a string game river cards
        public String ToString(GameRiver gameRiver1)
        {
            String gameRiverString = "";

            gameRiverString += "\n\n\tRiverCards\n\t";
            for (int i = 0; i < gameRiver1.length(); i++)
            {
                Card tempCard = gameRiver1.GetCard(i);
                gameRiverString+=tempCard.ToString();
                if (i != 51)
                    gameRiverString +=", ";

            }

            return gameRiverString;
        }

        //gets river card count
        public int getCardsRemaining()
        {
            return riverCardsRemaning = gameRiver.Count;
        }


    }
}
