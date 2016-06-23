using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MissionPlanner.GCSViews.Modification
{
    public class ChangeValueEventArgs<T> : EventArgs
    {
        private T value;

        public ChangeValueEventArgs(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get { return value; }
        }
    }
}
