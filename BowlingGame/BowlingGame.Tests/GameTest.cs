using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace BowlingGame.Tests
{
    public class GameTest
    {
        [Fact]
        public void Score_ShouldReturn0IfRollNeverCalled()
        {
            var game = new Game();
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void Score_ShouldReturn0IfRolledCalledWith0Pins()
        {
            var game = new Game();
            game.Roll(0);
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void Score_ShouldReturn1IfRolledCalledWith1Pins()
        {
            var game = new Game();
            game.Roll(1);
            Assert.Equal(1, game.Score());
        }
    }
}
