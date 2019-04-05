using Dal.Model;
using Dal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    class Program
    {
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
                int choice;
                var line = Console.ReadLine();
                if (!int.TryParse(line, out choice))
                    choice = -1;

                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            game = new GameVersusPlayer();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("1 - Easy level");
                            Console.WriteLine("2 - Medium level");
                            Console.WriteLine("3 - Hard level");

                            line = Console.ReadLine();
                            if (!int.TryParse(line, out choice))
                                choice = -1;

                            switch (choice)
                            {
                                case 1:
                                    {
                                        game = new EasyLevelGame();
                                        break;
                                    }
                                case 2:
                                    {
                                        game = new MediumLevelGame();
                                        break;
                                    }
                                case 3:
                                    {
                                        game = new HardLevelGame();
                                        break;
                                    }
                                default: break;
                            }
                            break;
                        }
                    case 0: return;
                    default: break;
                }
                if (game != null)
                {
                    game.SetGamer = (Gamer)gamer;
                    game.Play();
                    gamerRepos.Save(gamer);
                }
            } while (true);
        }
    }
}
