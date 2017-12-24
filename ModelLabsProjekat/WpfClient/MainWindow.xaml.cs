using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                //// Set NMSTestInterfaceClient console layout
                //Console.SetWindowPosition(0, 0);

                //Console.SetWindowSize((int)(Console.LargestWindowWidth * 0.7), (int)(Console.LargestWindowHeight * 0.8));
                //Console.Title = "Network Model Service Client";

                double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
                double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
                double windowWidth = this.Width;
                double windowHeight = this.Height;
                this.Left = (screenWidth / 2) - (windowWidth / 2);
                this.Top = (screenHeight / 2) - (windowHeight / 2);

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
