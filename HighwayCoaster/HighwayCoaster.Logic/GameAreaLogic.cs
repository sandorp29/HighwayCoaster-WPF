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

        public GameAreaLogic(int areaHeight, int areaWidth)
        {
            this.areaHeight = areaHeight;
            this.areaWidth = areaWidth;
            this.gameOver = false;
        }

        public bool GameOver { get => this.gameOver; }

        public void Step(Direction direction)
        {

        }
    }
}
