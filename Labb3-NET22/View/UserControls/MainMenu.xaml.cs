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

namespace Labb3_NET22.View
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            
            InitializeComponent();
        }

        public void PlayClick(object sender, RoutedEventArgs e)
        {

        }

        public void CreateClick(object sender, RoutedEventArgs e)
        {
            CreateWindow Quiz = new CreateWindow();
            Quiz.Show();
        }

        public void EditClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
