using System.Windows;
using System;
using Microsoft.Xaml.Behaviors;

namespace CefSharp.Mitel.Demo.Wpf.Behaviours
{
    public class HoverLinkBehaviour : Behavior<FrameworkElement>
    {
        // Using a DependencyProperty as the backing store for HoverLink. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoverLinkProperty = DependencyProperty.Register("HoverLink", typeof(string), typeof(HoverLinkBehaviour), new PropertyMetadata(string.Empty));

        public string HoverLink
        {
            get { return (string)GetValue(HoverLinkProperty); }
            set { SetValue(HoverLinkProperty, value); }
        }

        protected override void OnAttached()
        {
            ((IWebBrowser)AssociatedObject).StatusMessage += OnStatusMessageChanged;
        }

        protected override void OnDetaching()
        {
            ((IWebBrowser)AssociatedObject).StatusMessage -= OnStatusMessageChanged;
        }
        
        private void OnStatusMessageChanged(object sender, StatusMessageEventArgs e)
        {
            var browser = (FrameworkElement)sender;
            browser.Dispatcher.BeginInvoke((Action)(() => HoverLink = e.Value));
        }
    }
}
