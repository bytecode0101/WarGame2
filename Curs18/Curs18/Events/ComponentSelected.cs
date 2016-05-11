using System;

namespace Curs18.Models.Events
{
    public delegate void ComponentSelected(object sender, ComponentSelectedEventArgs e);
   
    public class ComponentSelectedEventArgs : EventArgs
    {
        public ComponentViewModel ComponentVM { get; set; }
    }
}
