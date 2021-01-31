using System;

namespace RockPaperScissors
{
    enum VictoryType
    {
        Draw,
        Victory,
        Defeat
    }

    enum HandOption
    {
        Rock,
        Paper,
        Scissors
    }

    class Hand
    {
        public HandOption TheHand { get; set; }

        /// <summary>
        /// Sets the users hand and validate it. Returns the validation as a boolean. 
        /// If false then the program ask for a new input.
        /// </summary>
        /// <param name="choise">The user input</param>
        public bool SetUserHand(string choise)
        {
            switch (choise)
            {
                case "rock":
                    TheHand = HandOption.Rock;
                    return true;
                case "paper":
                    TheHand = HandOption.Paper;
                    return true;
                case "scissors":
                    TheHand = HandOption.Scissors;
                    return true;
                default:
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    return false;
            }
        }

        /// <summary>
        /// Sets a random hand for the computer.
        /// </summary>
        public void SetRandomHand()
        {
            Random random = new Random();
            TheHand = (HandOption)random.Next(3);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool gameOver = false;
            bool validated = true;
            Hand computerHand = new Hand();
            Hand humanHand = new Hand();

            //The game will loop until gameOver is true.
            do
            {
                do
                {
                    Console.Clear();
                    Console.Write("Choose your hand:\t");
                    string choise = Console.ReadLine().ToLower();

                    validated = humanHand.SetUserHand(choise);
                } while (!validated);

                computerHand.SetRandomHand();

                var result = Winner(humanHand.TheHand, computerHand.TheHand);

                //This part will write out the result.
                if (result == VictoryType.Victory)
                {
                    Console.WriteLine($"{humanHand.TheHand} vs {computerHand.TheHand}");
                    Console.WriteLine("You won!");
                }
                else if (result == VictoryType.Draw)
                {
                    Console.WriteLine($"{humanHand.TheHand} vs {computerHand.TheHand}");
                    Console.WriteLine("It was a draw!");
                }
                else
                {
                    Console.WriteLine($"{humanHand.TheHand} vs {computerHand.TheHand}");
                    Console.WriteLine("You Lost!");
                }

                Console.WriteLine("Press enter to play again or write 'Q' to exit");
                string playAgain = Console.ReadLine().ToUpper();
                if (playAgain == "Q") gameOver = true;
            } while (!gameOver);
        }

        /// <summary>
        /// This method checks who won or if it's a draw.
        /// </summary>
        /// <param name="humanHand">The hand from the player.</param>
        /// <param name="computerHand">The random hand for the computer.</param>
        /// <returns>Returns the VictoryType.</returns>
        static VictoryType Winner(HandOption humanHand, HandOption computerHand)
        {
            if (humanHand == HandOption.Rock)
            {
                if (computerHand == HandOption.Rock)
                {
                    return VictoryType.Draw;
                }
                else if (computerHand == HandOption.Paper)
                {
                    return VictoryType.Defeat;
                }
                else if (computerHand == HandOption.Scissors)
                {
                    return VictoryType.Victory;
                }
                else
                    return 0;
            }
            else if (humanHand == HandOption.Paper)
            {
                if (computerHand == HandOption.Rock)
                {
                    return VictoryType.Victory;
                }
                else if (computerHand == HandOption.Paper)
                {
                    return VictoryType.Draw;
                }
                else if (computerHand == HandOption.Scissors)
                {
                    return VictoryType.Defeat;
                }
                else
                    return 0;
            }
            else if (humanHand == HandOption.Scissors)
            {
                if (computerHand == HandOption.Rock)
                {
                    return VictoryType.Defeat;
                }
                else if (computerHand == HandOption.Paper)
                {
                    return VictoryType.Victory;
                }
                else if (computerHand == HandOption.Scissors)
                {
                    return VictoryType.Draw;
                }
                else
                    return 0;
            }
            else
                return 0;
        }
    }
}
