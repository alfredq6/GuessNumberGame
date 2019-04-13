using Dal.Model;
using Dal.Repository;
using GuessNumber.GameTypes;
using GuessNumber.UserChoices;
using GuessNumber.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.GameMenu
{
    public class Menu
    {

        public static void StartLevelMenu(ref Game game)
        {
            Console.Clear();
            Console.WriteLine($"{(int)UserLevelChoice.Easy} - Easy level");
            Console.WriteLine($"{(int)UserLevelChoice.Medium} - Medium level");
            Console.WriteLine($"{(int)UserLevelChoice.Hard} - Hard level");
            UserLevelChoice choiceLevel = (UserLevelChoice)NumberValidator.ConvertStringToNumber();

            switch (choiceLevel)
            {
                case UserLevelChoice.Easy:
                    {
                        game = new EasyLevelGame();
                        break;
                    }
                case UserLevelChoice.Medium:
                    {
                        game = new MediumLevelGame();
                        break;
                    }
                case UserLevelChoice.Hard:
                    {
                        game = new HardLevelGame();
                        break;
                    }
                default: break;
            }
        }

        public static void StartMainMenu(ref Game game, ref bool exit)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine($"{(int)UserGameTypeChoice.PlayWithAnotherPlayer} - Play with another player");
            Console.WriteLine($"{(int)UserGameTypeChoice.PlayWithComputer} - Play with computer");
            Console.WriteLine($"{(int)UserGameTypeChoice.Exit} - Exit");

            UserGameTypeChoice choice = (UserGameTypeChoice)NumberValidator.ConvertStringToNumber();

            switch (choice)
            {
                case UserGameTypeChoice.PlayWithAnotherPlayer:
                    {
                        Console.Clear();
                        game = new GameVersusPlayer();
                        break;
                    }
                case UserGameTypeChoice.PlayWithComputer:
                    {
                        StartLevelMenu(ref game);
                        break;
                    }
                case UserGameTypeChoice.Exit:
                    {
                        exit = true;
                        break;
                    }
                default: break;
            }
        }
    }
}
