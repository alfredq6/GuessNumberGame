using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.GameTypes
{
    public abstract class GameVersusComputer : Game
    {
        public override void Play()
        {
            GuessingPlayerActions();

            EndGameActions();
        }

        public int? GetRandomNumber(int _min, int _max)
        {
            if (_min >= _max)
            {
                return null;
            }
            Random rand = new Random();
            var randomNumber = rand.Next(_min + 1, _max - 1);

            return randomNumber;
        }
    }
}
