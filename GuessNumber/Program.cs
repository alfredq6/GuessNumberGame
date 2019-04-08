using Dal.Model;
using Dal.Repository;
using GuessNumber.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    class Program
    {
        enum UserMenuChoice
        {
            Exit = 0,
            PlayWithAnotherPlayer = 1,
            PlayWithComputer = 2
        }

        enum UserLevelChoice
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }

        static void Main(string[] args)
        {
            var gamerRepos = new GamerRepository();
            var gamer = gamerRepos.Get(1);

            if (gamer == null)
            {
                gamer = new Gamer
                {
                    Id = 1,
                    Name = "Nobody",
                    Score = 0
                };
            }

            Game game = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Play with another player");
                Console.WriteLine("2 - Play with computer");
                Console.WriteLine("0 - Exit");
                UserMenuChoice choice = (UserMenuChoice)NumberValidator.ConvertStringToNumber();

                switch (choice)
                {
                    case UserMenuChoice.PlayWithAnotherPlayer:
                        {
                            Console.Clear();
                            game = new GameVersusPlayer();
                            break;
                        }
                    case UserMenuChoice.PlayWithComputer:
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
                            break;
                        }
                    case UserMenuChoice.Exit: return;
                    default: break;
                }
                if (game != null)
                {
                    game.Gamer = gamer;
                    game.Play();
                    gamerRepos.Save(gamer);
                }
            } while (true);
        }
    }
}
