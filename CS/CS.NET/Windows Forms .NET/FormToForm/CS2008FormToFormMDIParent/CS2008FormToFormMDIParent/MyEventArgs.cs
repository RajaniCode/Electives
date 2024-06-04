using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS2008FormToFormMDIParent
{
    class MyEventArgs
    {
        private object userState;

        public object UserState
        {
            get
            {
                return userState;
            }
            set
            {
                userState = value;
            }
        }

        public MyEventArgs(object state)
        {
            this.userState = state;
        }
    }
}
