using GuessNumber.GameTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public class MediumLevelGame : GameVersusComputer
    {
        public MediumLevelGame()
        {
            Min = 0;
            Max = 1000;
            GuessingNumber = GetRandomNumber(Min, Max);
            MaxAttempt = GetMaxAttempt(Min, Max);
        }
    }
}
