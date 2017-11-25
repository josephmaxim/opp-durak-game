using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace DurakLibrary
{

    public class GameLog 
    {
        //the log can be found in DurakClient Folder as gamelog.txt
        public string filepath = @"../../gamelog.txt";
        
        //method that takes in a string then appends/writes the string to an outputfile
        public void Log(string message)
        {

            StreamWriter streamWriter = File.AppendText(filepath);

             streamWriter.WriteLine(message);
                    streamWriter.Close();
                
            
        }

        //method clears the log file
        public void ClearLog(string message)
        {
            StreamWriter streamWriter = new StreamWriter(filepath);
            streamWriter.WriteLine(message);
            streamWriter.Close();

            
        }

        //logs the round stats
        public void LogRound(GameLog gameLog, int roundNumber, Player playerOne, Player playerTwo, GameRiver gameRiver)
        {
            gameLog.Log("\nROUND: " + roundNumber.ToString()
            + "\n\t" + playerOne.getHand().ToString(playerOne.getHand(), playerOne.getName())
            + "\n\n\t" + playerTwo.getHand().ToString(playerTwo.getHand(), playerTwo.getName())
            + gameRiver.ToString(gameRiver));
        }
       
    }
}
