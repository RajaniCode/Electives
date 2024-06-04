using System;

namespace WebApplication2
{
    public class CustomArgs : EventArgs
    {
        public bool Cancel { get; set; }
        public string Message { get; set; }
        public string NavigateTo { get; set; }
    }
}
