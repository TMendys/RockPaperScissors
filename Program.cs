using System;

namespace RockPaperScissors
{
    enum VictoryTypes
    {
        Draw,
        Victory,
        Defeat
    }

    enum Hands
    {
        Rock,
        Paper,
        Scissors
    }

    class Hand
    {
        public Hands TheHand { get; set; }

        /// <summary>
        /// Sets the users hand and validate. Returns the validation as a boolean.
        /// </summary>
        /// <param name="choise"></param>
        public bool SetUserHand(string choise)
        {
            switch (choise)
            {
                case "rock":
                    TheHand = Hands.Rock;
                    return true;
                case "paper":
                    TheHand = Hands.Paper;
                    return true;
                case "scissors":
                    TheHand = Hands.Scissors;
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
            TheHand = (Hands)random.Next(3);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            bool validated = true;
            Hand computerHand = new Hand();
            Hand humanHand = new Hand();

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

                var winner = Winner(humanHand.TheHand, computerHand.TheHand);

                if (winner == VictoryTypes.Victory)
                {
                    Console.WriteLine($"{humanHand.TheHand} vs {computerHand.TheHand}");
                    Console.WriteLine("You won!");
                }
                else if (winner == VictoryTypes.Draw)
                {
                    Console.WriteLine($"{humanHand.TheHand} vs {computerHand.TheHand}");
                    Console.WriteLine("It was a draw!");
                }
                else
                {
                    Console.WriteLine($"{humanHand.TheHand} vs {computerHand.TheHand}");
                    Console.WriteLine("You Lost!");
                }

                Console.WriteLine("Press any key to play again or write 'Q' to exit");
                string playAgain = Console.ReadLine().ToLower();
                if (playAgain == "q") play = false;
            } while (play);
        }
        /// <summary>
        /// This method checks who won or if it's a draw.
        /// </summary>
        /// <param name="humanHand">The hand from the player.</param>
        /// <param name="computerHand">The random hand for the computer.</param>
        /// <returns>Returns the VictoryTyp.</returns>
        static VictoryTypes Winner(Hands humanHand, Hands computerHand)
        {
            if (humanHand == Hands.Rock)
            {
                if (computerHand == Hands.Rock)
                {
                    return VictoryTypes.Draw;
                }
                else if (computerHand == Hands.Paper)
                {
                    return VictoryTypes.Defeat;
                }
                else if (computerHand == Hands.Scissors)
                {
                    return VictoryTypes.Victory;
                }
                else
                    return 0;
            }
            else if (humanHand == Hands.Paper)
            {
                if (computerHand == Hands.Rock)
                {
                    return VictoryTypes.Victory;
                }
                else if (computerHand == Hands.Paper)
                {
                    return VictoryTypes.Draw;
                }
                else if (computerHand == Hands.Scissors)
                {
                    return VictoryTypes.Defeat;
                }
                else
                    return 0;
            }
            else if (humanHand == Hands.Scissors)
            {
                if (computerHand == Hands.Rock)
                {
                    return VictoryTypes.Defeat;
                }
                else if (computerHand == Hands.Paper)
                {
                    return VictoryTypes.Victory;
                }
                else if (computerHand == Hands.Scissors)
                {
                    return VictoryTypes.Draw;
                }
                else
                    return 0;
            }
            else
                return 0;
        }
    }
}
