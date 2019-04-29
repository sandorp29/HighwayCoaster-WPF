using HighwayCoaster.Logic;
using HighwayCoaster.ViewModels.ViewModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HighwayCoaster.ViewModels
{
    public class PlayViewModel
    {
        public PlayViewModel()
        {
            this.GA = new GameArea();
        }

        public GameArea GA { get; set; }

        public IGameLogic GameLogic { get; set; }

        public MainWindowViewModel MainWindowViewModel { get; set; }
    }
}
