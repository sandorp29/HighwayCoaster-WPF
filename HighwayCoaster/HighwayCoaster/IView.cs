using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayCoaster
{
    public interface IView
    {
        event EventHandler OnMoveAction;
    }
}
