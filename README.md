# Team Project Requirements (opp-durak-game)
Game of durak built in .NET framework

For this project you and your team will be creating a GUI simulation of the game Durak. Durak is a very popular card game in Russia and Eastern Europe1. The object of Durak is getting rid of all of your cards. The player that cannot is the Durak or Fool. Overviews of Durak and its major variants are easily found [online](https://www.google.ca/search?q=Durak%20card%20game), including at [Wikipedia](https://en.wikipedia.org/wiki/Durak). An excellent video tutorial is available on [YouTube](https://www.youtube.com/watch?v=hQHW_CuGG2A).
 
**Minimal Requirements (40 marks)**
A project that implements ONLY the minimal requirements listed will be graded up to 67% (40/60).

![40 marks](/img/1.png?raw=true "40 Marks")

 - **Game-Play Logic (Two-Player).** Although typically Durak is played with between two and six people, for the purposes of this project you should limit the game to two-player, i.e. one human controlled player and one computer controlled player. You are not required to implement more than two players for this
project. 
 - **Basic Computer Player A.I.** You are required to implement an A.I. logic structure that determines what action the computer-controlled player will make, taking into consideration whether the computer is attacking or defending, which suit is trump, and which cards (if any) in the computer’s hand can be played. 
 - **GUI.** You are required to implement a graphical user interface (GUI) for your project. You are notrequired to design an especially artistic interface, but it should be simple, clean, and functional. You are required to make use of at least one custom control in your GUI. Note that if you are using graphical elements that you did not create from scratch yourself (e.g. playing card images), you MUST source these elements ethically and legally. This includes full and proper attribution to the artist in your project documentation. 
 - **Object-Oriented Concepts.** A major component of how you will be assessed is in the degree to which you are utilizing the object-oriented concepts and techniques presented in the course
. Your design should demonstrate encapsulation, abstraction, polymorphism and inheritance with a goal of ease of maintenance and reusability. Durak is a card game with elements that are common with many other card games (e.g. cards, decks, hands, etc). Any class you create that could be useful in other projects should be coded in one or more class libraries. You are required to include at least one class library.
 - **Internal Documentation.** At a minimum, your source code should be extensively documented with opening comments and in-line commenting. Like graphical elements you did not create from scratch, any code elements that you did not totally write yourself MUST be sourced ethically and legally. This includes full and proper attribution of the original code author in the comments.
 - **User Guide.** You must include some form of user guide or tutorial the player can refer to that explains the functionality of the project. This may be text-based or video-based.

**Recommended Features (20 marks)**
A project that implements ALL of the minimal requirements and two or more of the recommended features listed will be graded up to 100% (60/60).

![20 marks](/img/2.png?raw=true "20 Marks")

 - **Transferring (a.k.a. Perevodnoy or Passing Durak).** In this variation of Durak, if on the initial attack the defending player is able to play a card of the same rank but a different suit (e.g. a six on a six), the attack transfers to that player in a two-player game. The new defending player has the option of transferring the attack again by playing a third card of the same rank. Another transfer is possible if a fourth card of the same suit is played. Transferring is not possible after a defence begins (i.e. the defending player plays a card of the same suit/higher rank or trump).
 - **Advanced Computer Player A.I.** Implement an A.I. logic structure that determines what action the computer-controlled player will make, taking into additional considerations such as whether it is advantageous to pick-up even when a card could be played, how many cards are left in the draw pile, which cards have been played and discarded, and which cards the human player has picked up. If the transferring option is implemented, incorporate A.I. that considers transferring. The computer player should be difficult to beat.
 - **Number of cards.** Durak is normally played with a deck of 36 cards. Give the player the option of playing with 20 (i.e. Ten to Ace in each suit), 36 (i.e. Six to Ace in each suit), or 52 (i.e. a standard deck) cards at the start of the game. 
 - **More than two players.** Give the user the option to play against up to six computer players. Note that this will significantly increase the complexity of the game-play. 
 - **Game-play Log and Statistics**
	 - **Log.** As the game is being played, record the relevant game-play actions to a text-file log. This log should record the date and time the game was started, the initial hands dealt and the trump card at the game start. It should also record the actions of both the human player and the computer player for each round, including which cards they played, picked-up, and/or drew. Once the game is complete, it should record the results.
	 - **Persistent Statistics.** Record and update the human-player’s name and number of games played, wins, ties, and losses. This information should be stored in a text file and loaded every time the application is run. Provide the player the option to reset the name and statistics.
 - **Other features.** If you have ideas for other features, they should be proposed in your milestone reports and consultations and approved by the instructor.
