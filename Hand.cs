using System;

namespace RockPaperScissors
{
    public enum HandOption
    {
        Rock,
        Paper,
        Scissors
    }

    public class Hand
    {
        public HandOption TheHand { get; set; }

        /// <summary>
        /// Validates the choice.
        /// </summary>
        /// <param name="choice">The user input</param>
        /// <returns>If validated or not</returns>
        public static bool ValidateUserHand(string? choice) =>
            choice?.ToLower() switch
            {
                "rock" or "paper" or "scissors" => true,
                _ => false
            };

        /// <summary>
        /// Sets the users hand and validate it.
        /// </summary>
        /// <param name="choise">The user input</param>
        public HandOption SetUserHand(string choice) =>
            choice.ToLower() switch
            {
                "rock"      => TheHand = HandOption.Rock,
                "paper"     => TheHand = HandOption.Paper,
                "scissors"  => TheHand = HandOption.Scissors,
                _ => throw new ArgumentException("The input was not allowed")
            };

        /// <summary>
        /// Sets a random hand for the computer.
        /// </summary>
        public void SetRandomHand()
        {
            Random random = new ();
            TheHand = (HandOption)random.Next(3);
        }
    }
}
