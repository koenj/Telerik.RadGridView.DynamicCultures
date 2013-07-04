using System;

namespace TelerikGridViewDynamicCultures
{
    /// <summary>
    /// This is NO production code; just used for this example.
    /// You'll need some sort of event to notify the grids of culture changes.
    /// </summary>
    public class EventAggregator
    {
        private static EventAggregator instance;
        public static EventAggregator Instance
        {
            get
            {
                if (instance == null)
                    instance = new EventAggregator();
                return instance;
            }
        }

        public event EventHandler ApplicationCultureChanged = delegate { };

        public void RaiseApplicationCultureChanged()
        {
            this.ApplicationCultureChanged(this, EventArgs.Empty);
        }
    }
}