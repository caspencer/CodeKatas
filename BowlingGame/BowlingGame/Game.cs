using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
    public class Game
    {
        private int lastPins;

        public void Roll(int pins)
        {
            lastPins = pins;
        }

        public int Score()
        {
            return lastPins;
        }
    }
}
