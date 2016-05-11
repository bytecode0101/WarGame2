using Curs18.Common;
using System;


namespace Curs18.Models.Events
{
    public delegate void BuildingStarted(object sender, BuildingStartedEventArgs e);

    public class BuildingStartedEventArgs : EventArgs
    {
        public AbstractBuildable Component { get; set; }
    }
}
