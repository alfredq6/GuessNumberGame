using Dal.Model;
using Dal.Repository;
using GuessNumber.Validators;
using GuessNumber.GameMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.GameTypes
{
    public abstract class Game
    {
        public int Min { get; set; }
        public int Max { get; set; }
        protected int Attempt { get; set; }
        protected int? MaxAttempt { get; set; }
        protected int? GuessingNumber { get; set; }
        protected int GuessingPlayerNumber { get; set; }
        protected bool IsWin { get; set; } = false;
        protected MinMaxValidator validator { get; set; }
        public static GamerRepository gamerRepos;
        public static Gamer gamer;
        private static Game game;
        private static bool exit;
        public Gamer Gamer { get; set; }

        public static void Setup()
        {
            gamerRepos = new GamerRepository();
            gamer = gamerRepos.Get(1);

            if (gamer == null)
            {
                gamer = new Gamer
                {
                    Id = 2,
                    Name = "Nobody",
                    Score = 0
                };
            }

            game = null;
            exit = false;
        }

        public static void Start()
        {
            Setup();
            do
            {
                Menu.StartMainMenu(ref game, ref exit);

                if (game != null && !exit)
                {
                    game.Gamer = gamer;
                    game.Play();
                    gamerRepos.Save(game.Gamer);
                }
            } while (!exit);
        }

        public abstract void Play();

        protected void EndGameActions()
        {
            if (IsWin)
            {
                Gamer.Score += (int)MaxAttempt - Attempt + 1;
                Console.WriteLine($"Congratulation {Gamer.Name}! Your score is {Gamer.Score}");
                
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("LOOOOOOSSEEEER");
                Console.WriteLine($"It was {GuessingNumber}");
            }
        }

        protected void GuessingPlayerActions()
        {
            Console.Clear();
            Console.WriteLine("Guessing player, press any key to start...");
            Console.ReadKey();
            Console.WriteLine("Try guess a number!");

            MaxAttempt = GetMaxAttempt(Min, Max);
            do
            {
                validator = new MinMaxValidator(Min, Max);
                Console.WriteLine($"Min value is {Min} and max is {Max}");
                GuessingPlayerNumber = NumberValidator.ConvertStringToNumber(validator);

                if (GuessingPlayerNumber > GuessingNumber)
                {
                    validator.maxValue = validator.IsValid(GuessingPlayerNumber) ? GuessingPlayerNumber : validator.maxValue;
                    Max = (int)validator.maxValue;
                }

                if (GuessingPlayerNumber < GuessingNumber)
                {
                    validator.minValue = validator.IsValid(GuessingPlayerNumber) ? GuessingPlayerNumber : validator.minValue;
                    Min = (int)validator.minValue;
                }

                if (GuessingPlayerNumber == GuessingNumber)
                    IsWin = true;

                Console.WriteLine($"It was your {++Attempt}/{MaxAttempt} attempt");

            } while (!IsWin && Attempt != MaxAttempt);
        }


        public int? GetMaxAttempt(int _min, int _max)
        {
            return _min < _max ? ((int?)Math.Round(Math.Log(_max - _min, 2), 0) + 1) : null;
        }

    }
}
