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
            var numberOfTimesToPlay = ConsoleUtils.PromptForValue<int>("How many games do you want to play?");
            WarGame game = new WarGame(
                new WarPlayer() { Name = "Player 1" },
                new WarPlayer() { Name = "Player 2" });

            Debug.Listeners.Add(new ConsoleTraceListener());
            try
            {
                for (int i = 1; i <= numberOfTimesToPlay; i++)
                {
                    do
                    {
                        game.AdvancePlay();
                        Debug.WriteLine(string.Empty);
                        if (game.GameState == WarGameState.GameOver)
                        {
                            Debug.WriteLine("Winner: " + game.Winner.Name);
                        }
                    } while (game.GameState != WarGameState.GameOver);

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
