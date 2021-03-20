using System;
using System.ComponentModel.DataAnnotations;

namespace RockPaperScissors
{
    class Program
    {
        static void Main()
        {
            SetUpGame(new Game());
        }

        private static void SetUpGame(Game game)
        {
            while(game.NewGame());
        }
    }
}
