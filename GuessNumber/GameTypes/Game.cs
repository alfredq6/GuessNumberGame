using Dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public abstract class Game
    {
        protected int Min { get; set; }
        protected int Max { get; set; }
        protected int Attempt { get; set; }
        protected int MaxAttempt { get; set; }
        protected int GuessingNumber { get; set; }
        protected int GuessingPlayerNumber { get; set; }
        protected bool IsWin { get; set; } = false;
        protected Validator validator { get; set; }
        public Gamer gamer { get; set; }

        public abstract void Play();

        public Gamer SetGamer
        {
            get
            {
                return gamer;
            }
            set
            {
                gamer = value;
            }
        }

        protected void EndGameActions()
        {
            if (IsWin)
            {
                gamer.Score += MaxAttempt - Attempt + 1;
                Console.WriteLine($"Congratulation {gamer.Name}! Your score is {gamer.Score}");
                
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
            validator = new Validator(Min, Max);

            MaxAttempt = GetMaxAttempt(Min, Max);
            do
            {
                Console.WriteLine($"Min value is {Min} and max is {Max}");
                GuessingPlayerNumber = GetNumber();

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


        protected int GetMaxAttempt(int _min, int _max)
        {
            return (int)Math.Round(Math.Log(_max - _min, 2), 0) + 1;
        }

        protected int GetNumber(Validator validator = null)
        {
            var line = Console.ReadLine();
            int num;
            do
            {
                if (!string.IsNullOrEmpty(validator?.Error))
                {
                    Console.WriteLine(validator.Error);
                    line = Console.ReadLine();
                }

                while (!int.TryParse(line, out num))
                {
                    Console.WriteLine("Please, enter an INTEGER NUMBER");
                    line = Console.ReadLine();
                }
            } while (!validator?.IsValid(num) ?? false);
            return num;
        }

    }
}
