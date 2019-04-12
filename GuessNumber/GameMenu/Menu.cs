using Dal.Model;
using Dal.Repository;
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
            Console.WriteLine("1 - Easy level");
            Console.WriteLine("2 - Medium level");
            Console.WriteLine("3 - Hard level");
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
            Console.WriteLine("1 - Play with another player");
            Console.WriteLine("2 - Play with computer");
            Console.WriteLine("0 - Exit");
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
