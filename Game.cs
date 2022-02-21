using System;

namespace RockPaperScissors
{
    public enum VictoryType
    {
        Draw,
        Victory,
        Defeat
    }

    public class Game
    {
        public Hand HumanHand { get; set; } = new();
        public Hand ComputerHand { get; set; } = new();
        public VictoryType Result { get; set; }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        /// <returns>If the game will loop again</returns>
        public bool NewGame()
        {
            while (SetUpUserHand() is false);
            ComputerHand.SetRandomHand();

            Result = Winner();

            WriteResult();

            return PlayAgain();
        }

        /// <summary>
        /// Takes the choice of the player and validates it and then saves the choice.
        /// </summary>
        /// <returns>If the input was successfully saved in the Hand</returns>
        private bool SetUpUserHand()
        {
            Console.Clear();
            Console.WriteLine("Possible choices: Rock, Paper, Scissors");
            Console.Write("Choose your hand:\t");
            string choice = Console.ReadLine();

            if (Hand.ValidateUserHand(choice) is false)
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return false;
            }

            HumanHand.SetUserHand(choice);
            return true;
        }

        /// <summary>
        /// Asks the player if he/she wants to play again.
        /// </summary>
        /// <returns></returns>
        private static bool PlayAgain()
        {
            Console.Write("Press 'Q' to exit or any other key to play again. ");
            return Console.ReadKey().Key is not ConsoleKey.Q;
        }

        /// <summary>
        /// Write out the result to screen.
        /// </summary>
        private void WriteResult()
        {
            Console.WriteLine($"{HumanHand.TheHand} vs {ComputerHand.TheHand}");

            Console.WriteLine(Result switch
            {
                VictoryType.Victory => "You won!",
                VictoryType.Defeat => "You lost!",
                _ => "It was a draw!"
            });
        }

        /// <summary>
        /// Checks for the winner or if it's a draw.
        /// </summary>
        /// <returns>The victory type for the human player</returns>
        private VictoryType Winner()
        {
            if(HumanHand.TheHand == ComputerHand.TheHand)
            {
                return VictoryType.Draw;
            }
            else if (HumanHand.TheHand == HandOption.Rock     && ComputerHand.TheHand == HandOption.Scissors)
            {
                return VictoryType.Victory;
            }
            else if (HumanHand.TheHand == HandOption.Paper    && ComputerHand.TheHand == HandOption.Rock)
            {
                return VictoryType.Victory;
            }
            else if (HumanHand.TheHand == HandOption.Scissors && ComputerHand.TheHand == HandOption.Paper)
            {
                return VictoryType.Victory;
            }

            return VictoryType.Defeat;
        }
    }
}
