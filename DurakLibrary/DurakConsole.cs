/*
 Authors: Ryan Ramkalawan, Joseph Maxim, Tyler Nankishore, David Bond
 Creation Date: 2017/02/21
 Revision Date: 2017/02/21
 Description: Durak Console, used to test Durak Library classes and functionality
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurakLibrary;

namespace DurakLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string menuChoice; // holds the user input menu choice
                string exitChoice = "";//holds the exit choice
                do // begin a loop
                {
                    Console.Clear(); // Clear the Console
                                     // Display the menu options
                    Console.WriteLine("\n\tTesting Durak Class Functionality\n\t  {0}", DateTime.Now.ToLongDateString());

                    Console.WriteLine("\n========================================");
                    Console.WriteLine("1 - Card.");
                    Console.WriteLine("2 - CardList<>.");
                    Console.WriteLine("3 - CardRanksEnum.");
                    Console.WriteLine("4 - CardSuitsEnum.");
                    Console.WriteLine("5 - GameDeck.");
                    Console.WriteLine("6 - GamePlay.");
                    Console.WriteLine("7 - GameRiver<>.");
                    Console.WriteLine("8 - Player.");
                    Console.WriteLine("9 - PlayerAI.");
                    Console.WriteLine("10 - PlayerHand.");
                    Console.WriteLine("11 - Exit Program.");
                    Console.WriteLine("========================================");
                    // Get user choice
                    Console.Write("\nPlease enter your choice: ");
                    menuChoice = Console.ReadLine();

                    Console.WriteLine("\n========================================");
                    // Execute the corresponding method:
                    switch (menuChoice)
                    {
                        case "1":                            
                            CardTest();
                            break;

                        case "2":                          
                            CardList();
                            break;

                        case "3":                           
                            CardRanksEnum();
                            break;

                        case "4":                            
                            CardSuitsEnum();
                            break;

                        case "5":                            
                            GameDeck();
                            break;

                        case "6":                       
                            GamePlay();
                            break;

                        case "7":                           
                            GameRiver();
                            break;

                        case "8":                         
                            Player();
                            break;

                        case "9":
                            PlayerAI();
                            break;

                        case "10":
                            PlayerHand();
                            break;

                        case "11":
                            exitChoice = "exit";
                            break;
                            
                        default: // If user choice is not one of the menu options,
                            menuChoice = "retry"; // set menu choice to "retry"
                            break;
                    }

                } while (menuChoice == "retry" | exitChoice != "exit"); // continue while menu choice is "retry"

            }
            catch (Exception e) // If an exception is thrown:
            {
                // Show the type of exception, and the exception message to the user.
                Console.WriteLine("\n{0}\n{1}", e.GetType(), e.Message);

            }

            finally // Regardless: 
            {
                // Pause before the end of the program 
                Console.WriteLine("\nPress any key to end the program...");
                Console.ReadKey();
            }

        } // End of Main()


        //Beginning of CardTest()
        static void CardTest()
        {
    
            //Card Functionality
            Card.isAceHigh = true;
            Console.WriteLine("\nAces are high.");
            Card.useTrumps = true;
            Card.trump = DurakLibrary.CardSuitsEnum.Club;
            Console.WriteLine("Clubs are trumps.");

            Card card1, card2, card3, card4, card5;
        card1 = new Card(DurakLibrary.CardSuitsEnum.Club, DurakLibrary.CardRanksEnum.Five);
        card2 = new Card(DurakLibrary.CardSuitsEnum.Club, DurakLibrary.CardRanksEnum.Five);
        card3 = new Card(DurakLibrary.CardSuitsEnum.Club, DurakLibrary.CardRanksEnum.Ace);
        card4 = new Card(DurakLibrary.CardSuitsEnum.Heart, DurakLibrary.CardRanksEnum.Ten);
        card5 = new Card(DurakLibrary.CardSuitsEnum.Diamond, DurakLibrary.CardRanksEnum.Ace);
        Console.WriteLine("{0} == {1} ? {2}",
                 card1.ToString(), card2.ToString(), card1 == card2);
            Console.WriteLine("{0} != {1} ? {2}",
                 card1.ToString(), card3.ToString(), card1 != card3);
            Console.WriteLine("{0}.Equals({1}) ? {2}",
                 card1.ToString(), card4.ToString(), card1.Equals(card4));
            Console.WriteLine("Card.Equals({0}, {1}) ? {2}",
                 card3.ToString(), card4.ToString(), Card.Equals(card3, card4));
            Console.WriteLine("{0} > {1} ? {2}",
                 card1.ToString(), card2.ToString(), card1 > card2);
            Console.WriteLine("{0} <= {1} ? {2}",
                 card1.ToString(), card3.ToString(), card1 <= card3);
            Console.WriteLine("{0} > {1} ? {2}",
                 card1.ToString(), card4.ToString(), card1 > card4);
            Console.WriteLine("{0} > {1} ? {2}",
                 card4.ToString(), card1.ToString(), card4 > card1);
            Console.WriteLine("{0} > {1} ? {2}",
                 card5.ToString(), card4.ToString(), card5 > card4);
            Console.WriteLine("{0} > {1} ? {2}",
                 card4.ToString(), card5.ToString(), card4 > card5);
            Console.ReadKey();
            
        } // end of CardTest()


        //Beginning of CardList()
        static void CardList()
        {


        } // end of CardList()

        //Beginning of CardRanksEnum()
        static void CardRanksEnum()
        {


        } // end of CardRanksEnum()


        //Beginning of CardSuitsEnum()
        static void CardSuitsEnum()
        {


        } // end of CardSuitsEnum()


        //Beginning of GameDeck()
        static void GameDeck()
        {
            GameDeck myDeck = new GameDeck();
            myDeck.Shuffle(52);

            //showdeck
            Console.WriteLine(myDeck.ToString(myDeck));

            //player one draws a single card from deck
            Card card1;
            card1=myDeck.DrawCard();
            Console.WriteLine(card1.ToString(1));

            //showdeck
            Console.WriteLine(myDeck.ToString(myDeck));

            //creates two player objects
            PlayerHand playerOneHand = new PlayerHand();
            PlayerHand playerTwoHand = new PlayerHand();

            //player one adds drawn card to hand
            playerOneHand.AddCardToHand(card1);
            Console.WriteLine(playerOneHand.ToString(playerOneHand, 1));


            //player two draws 6 cards
            CardList cardsDrawn1;
            cardsDrawn1 = myDeck.DrawCards(6);
            Console.WriteLine(cardsDrawn1.ToString(cardsDrawn1, 2));

            //playertwo adds cards to hand
            playerTwoHand.AddCardsToHand(cardsDrawn1);
            Console.WriteLine(playerTwoHand.ToString(playerTwoHand, 2));


            //playertwo chooses two cards from hand
            Card choosenCardFromHand1;
            choosenCardFromHand1 = playerTwoHand.ChooseCardFromHand(2);
            Card choosenCardFromHand3;
            choosenCardFromHand3 = playerTwoHand.ChooseCardFromHand(0);
            Console.WriteLine(playerTwoHand.ToString(playerTwoHand, 2));

            //player one draws cards from deck
            CardList cardsDrawn2;
            cardsDrawn2 = myDeck.DrawCards(5);
            Console.WriteLine(cardsDrawn2.ToString(cardsDrawn2, 1));
            playerOneHand.AddCardsToHand(cardsDrawn2);
            Console.WriteLine(playerOneHand.ToString(playerOneHand, 1));

            //playerone chooses two cards from hand
            Card choosenCardFromHand2;
            choosenCardFromHand2 = playerOneHand.ChooseCardFromHand(1);
            Card choosenCardFromHand4;
            choosenCardFromHand4 = playerOneHand.ChooseCardFromHand(2);
            Console.WriteLine(playerOneHand.ToString(playerOneHand, 1));

            //choosen card from playertwo put in gameriver1 list
            GameRiver gameRiver1 = new GameRiver();

            //player two choosen cards added to river
            gameRiver1.AddCardToRiver(choosenCardFromHand1);
            gameRiver1.AddCardToRiver(choosenCardFromHand3);

            //player one choosen cards added to river
            gameRiver1.AddCardToRiver(choosenCardFromHand2);
            gameRiver1.AddCardToRiver(choosenCardFromHand4);
            Console.WriteLine(gameRiver1.ToString(gameRiver1));


            //Console.WriteLine(gameRiver1.cardRiverComparison());




            Console.ReadKey();







            //GameDeck Functionality
            GameDeck deck1 = new GameDeck();
            GameDeck deck2 = (GameDeck)deck1.Clone();
            Console.WriteLine("\nThe first card in the original deck is: {0}",
                              deck1.GetCard(0));
            Console.WriteLine("The first card in the cloned deck is: {0}",
                              deck2.GetCard(0));
            deck1.Shuffle(52);
            Console.WriteLine("Original deck shuffled.");
            Console.WriteLine("The first card in the original deck is: {0}",
                              deck1.GetCard(0));
            Console.WriteLine("The first card in the cloned deck is: {0}",
                              deck2.GetCard(0));

            Console.ReadKey();

        } // end of GameDeck()


        //Beginning of GamePlay()
        static void GamePlay()
        {


        } // end of GamePlay()


        //Beginning of GameRiver()
        static void GameRiver()
        {


        } // end of GameRiver()




        //Beginning of Player()
        static void Player()
        {
            int userInput = 0;
            GameDeck myDeck = new GameDeck();
            GameRiver myRiver = new GameRiver();
            PlayerHand playerOneHand = new PlayerHand();
            PlayerHand playerTwoHand = new PlayerHand();
            Player playerOne = new Player("Timmy", playerOneHand, true, false);
            Player playerTwo = new Player("Teddy", playerTwoHand, false, true);

            myDeck.Shuffle(52);

            //shower player info
            Console.WriteLine(myDeck.ToString(myDeck));
            Console.WriteLine(playerOne.ToStringPlayerInfo());
            Console.WriteLine(playerTwo.ToStringPlayerInfo());

            //refill player cards
            playerOne.RefillHand(myDeck);
            playerTwo.RefillHand(myDeck);
            //Console.WriteLine(playerOne.ToStringPlayerInfo());
            //Console.WriteLine(playerTwo.ToStringPlayerInfo());
            //Console.WriteLine(myDeck.ToString(myDeck));


            //Attacking/defendingPhase   
            while (playerOne.getIsAttacking() == true)
            {
                Console.WriteLine("NEW ATTACKING PHASE");
                Console.WriteLine(playerOne.ToStringPlayerInfo());
                Console.WriteLine(playerTwo.ToStringPlayerInfo());
                Console.WriteLine("\nEnter int number for card you want to play");
                userInput = Convert.ToInt32(Console.ReadLine());
                //playerOne.AttackingPhase(myRiver, userInput);
                while (playerTwo.getIsDefending() == true)
                {
                    userInput = 0;
                    Console.WriteLine("\nEnter int number for card you want to play");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    //playerTwo.DefendingPhase(myRiver, userInput);
                }
                Console.WriteLine(playerOne.ToStringPlayerInfo());
                Console.WriteLine(playerTwo.ToStringPlayerInfo());
                Console.WriteLine(myRiver.ToString(myRiver));

                //will set defending back to true for player two for new attacking phase
                playerTwo.setIsDefending(true);
            }


            Console.ReadKey();




        } // end of Player()





        //Beginning of PlayerAI()
        static void PlayerAI()
        {


        } // end of PlayerAI()

        //Beginning of PlayerHand()
        static void PlayerHand()
        {


        } // end of PlayerHand()



    }
}
