using HighwayCoaster.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HighwayCoaster.Logic
{
    public class GameAreaLogic
    {
        private int areaHeight;
        private int areaWidth;
        private bool gameOver;
        private int score;

        public GameAreaLogic(int areaHeight, int areaWidth)
        {
            this.areaHeight = areaHeight;
            this.areaWidth = areaWidth;
            this.gameOver = false;
            this.score = 0;
        }

        public bool GameOver { get => this.gameOver; }

        public int Score { get => this.score; }

        public void Step(Direction direction)
        {

        }
    }
}
