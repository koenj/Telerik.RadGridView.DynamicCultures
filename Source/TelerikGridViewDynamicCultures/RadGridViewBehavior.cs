using System;
using System.Windows;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;

namespace TelerikGridViewDynamicCultures
{
    public class RadGridViewBehavior : Behavior<RadGridView>
    {

        protected override void OnAttached()
        {
            base.OnAttached();
            EventAggregator.Instance.ApplicationCultureChanged += OnApplicationCultureChanged;
        }

        /// <summary>
        /// RadGridView has no support for dynamic culture switching.
        /// http://www.telerik.com/community/forums/silverlight/gridview/change-language-of-localization-of-radgridview-at-runtime.aspx#2172457
        /// Providing our own implementation.
        /// </summary>
        private void OnApplicationCultureChanged(object sender, EventArgs eventArgs)
        {
            var gridChildren = this.AssociatedObject.ChildrenOfType<DependencyObject>();
            foreach (var gridChild in gridChildren)
            {
                var resourceKey = LocalizationManager.GetResourceKey(gridChild);
                if (resourceKey != null)
                {
                    LocalizationManager.SetResourceKey(gridChild, null);
                    LocalizationManager.SetResourceKey(gridChild, resourceKey);
                }
            }
        }

    }
}