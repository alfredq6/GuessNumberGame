﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    abstract class GameVersusComputer : Game
    {

        public override void Play()
        {
            GuessingPlayerActions();

            EndGameActions();
        }

        protected int GetRandomNumber(int _min, int _max)
        {
            Random rand = new Random();
            var randomNumber = rand.Next(_min, _max);

            if (randomNumber == _min)
                randomNumber++;

            if (randomNumber == _max)
                randomNumber--;
            return randomNumber;
        }
    }
}