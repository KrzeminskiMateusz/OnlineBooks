using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBooksDesktopApp.View.Events
{
    public static class HamMenuEvents
    {
        public static event EventHandler<HamMenuArgs> OnHameMenuClick;
    }

    public struct HamMenuArgs
    {
        public string HeaderText { get; set; }
    }
}
