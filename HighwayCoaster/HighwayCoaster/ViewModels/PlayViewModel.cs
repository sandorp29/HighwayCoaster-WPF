using HighwayCoaster.Logic;
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
            GameArea = new FrameworkElement();
        }

        public FrameworkElement GameArea { get; set; }

        public IGameLogic GameLogic { get; set; }

        public MainWindowViewModel MainWindowViewModel { get; set; }
    }
}
