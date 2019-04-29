using HighwayCoaster.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace HighwayCoaster.ViewModels.ViewModelHelpers
{
    public class GameArea : FrameworkElement
    {
        private IGameLogic gameLogic;

        public void Setup(IGameLogic gameLogic)
        {
            this.gameLogic = gameLogic;

        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
        }
    }
}
