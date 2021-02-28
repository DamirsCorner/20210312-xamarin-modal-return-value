using System;
using System.Collections.Generic;
using System.Text;

namespace ShellModalReturnValues.Models
{
    public class ModalClosedEventArgs : EventArgs
    {
        public ModalClosedEventArgs(bool result)
        {
            Result = result;
        }

        public bool Result { get; }
    }
}
