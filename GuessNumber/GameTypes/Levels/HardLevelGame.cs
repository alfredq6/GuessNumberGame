using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    class HardLevelGame : GameVersusComputer
    {
        public HardLevelGame()
        {
            Min = 0;
            Max = 10000;
            GuessingNumber = GetRandomNumber(Min, Max);
            MaxAttempt = GetMaxAttempt(Min, Max);
        }
    }
}
