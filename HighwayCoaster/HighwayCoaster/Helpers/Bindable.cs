using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFZH.Helpers
{
    public class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChange([CallerMemberName] string s = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
    }
}
