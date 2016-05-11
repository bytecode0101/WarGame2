using System;

namespace Curs18.Models.Events
{
    public delegate void PercentageBuilt(object sender, PercentageBuiltEventArgs e);

    public class PercentageBuiltEventArgs : EventArgs
    {
        public int Percentage { get; set; }
    }
}
