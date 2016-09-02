using MissionPlanner.Comms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MissionPlanner.GCSViews
{
    public class PortFoundEventArgs : EventArgs
    {        
        private string _message;

        public PortFoundEventArgs(string message)
        {
            _message = message;
        }

        public string Message
        {
            get
            {
                return _message;
            }
        }        
    }
}
