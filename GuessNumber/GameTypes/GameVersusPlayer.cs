using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class GameVersusPlayer : Game
    {

        public override void Play()
        {
            FirstPlayerActions();

            GuessingPlayerActions();

            EndGameActions();
        }
        
        private void FirstPlayerActions()
        {
            validator = new Validator();

            Console.WriteLine("First player, Enter min value");
            validator.minValue = GetNumber(validator);
            Min = (int)validator.minValue;

            Console.WriteLine("Enter max value");
            validator.maxValue = GetNumber(validator);
            Max = (int)validator.maxValue;

            Console.WriteLine("Enter the guessing number");
            GuessingNumber = GetNumber(validator);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
