using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeadLockSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            int result = MethodAsyncDefault().Result;
        }

        private async Task<int> MethodAsyncDefault()
        {
            await Task.Delay(1000); //This does not use the thread
            return 1;
        }

        private async Task<int> MethodAsyncFalse()
        {
            await Task.Delay(1000).ConfigureAwait(false); //This does not use the thread
            return 1;
        }

        private int HeavyComputation()
        {
            Thread.Sleep(1000); //Simulate heavy CPU work using the thread
            return 1;
        }
    }
}
