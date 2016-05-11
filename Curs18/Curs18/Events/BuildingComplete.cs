using System;
using Curs18.Common;

namespace Curs18.Models.Events
{
    public delegate void BuildingComplete(object sender, BuildingCompleteEventArgs e);
   
    public class BuildingCompleteEventArgs : EventArgs
    {
        public AbstractBuildable Component { get; set; }
    }
}
