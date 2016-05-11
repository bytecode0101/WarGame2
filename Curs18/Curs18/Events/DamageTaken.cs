using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs18.Events
{
    public delegate void DamageTaken(object sender, DamageTakenEventArgs e);
    public class DamageTakenEventArgs : EventArgs
    {
        public int Damage { get; set; }
    }
}
