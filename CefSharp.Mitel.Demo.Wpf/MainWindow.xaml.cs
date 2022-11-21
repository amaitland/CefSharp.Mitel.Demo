using System.Windows;
using System.Windows.Interop;

namespace CefSharp.Mitel.Demo.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PresentationSource.AddSourceChangedHandler(BrowserHwndHost, new SourceChangedEventHandler(OnHwndHostPresentationSourceChanged));
        }

        private void OnHwndHostPresentationSourceChanged(object sender, SourceChangedEventArgs e)
        {
            if(e.Source == null)
            {
                return;
            }

            // Unregister KeyboardInputSite toi remove the WPF keyboard handling from our HwndHost
            // TAB should now work correctly
            var keyboardInputSite = ((IKeyboardInputSink)e.Source).KeyboardInputSite;
            if (keyboardInputSite != null)
            {
                ((IKeyboardInputSink)e.Source).KeyboardInputSite = null;

                keyboardInputSite.Unregister();
            }
        }
    }
}
