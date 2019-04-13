using GuessNumber.GameTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class EasyLevelGame : GameVersusComputer
    {
        public EasyLevelGame()
        {
            Min = 0;
            Max = 100;
            GuessingNumber = GetRandomNumber(Min, Max);
            MaxAttempt = GetMaxAttempt(Min, Max);
        }
    }
}
