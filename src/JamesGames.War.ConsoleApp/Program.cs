using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rolcore;
using Rolcore.Diagnostics;
using System.Diagnostics;

namespace JamesGames.War.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WarGame game = new WarGame(
                new WarPlayer() { Name = "Player 1" },
                new WarPlayer() { Name = "Player 2" });

            Debug.Listeners.Add(new ConsoleTraceListener());
            try
            {
                for (int i = 0; i < 10000; i++)
                {
                    //while (game.GameState != WarGameState.GameOver)
                    {
                        game.AdvancePlay();
                        Debug.WriteLine(string.Empty);
                    }    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                Debug.WriteLine("Done");
                Console.ReadLine();    
            }
            
        }
    }
}
