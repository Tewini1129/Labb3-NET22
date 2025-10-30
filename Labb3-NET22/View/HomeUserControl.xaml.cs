using Labb3_NET22.DataModels;
using Labb3_NET22.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Labb3_NET22.DataModels;
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
using static Labb3_NET22.DataModels.Question;

namespace Labb3_NET22.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HomeUserControl : UserControl
    {
        public MainWindow Parent { get; set; }


        public HomeUserControl(MainWindow parent)
        {
            InitializeComponent();
            Parent = parent;
        }


        public void PlayClick(object sender, RoutedEventArgs e)
        {
            Parent.ShowChooseQuiz(chosenQuiz =>
            {
                Parent.ShowChooseCategory(chosenQuiz);
            });
            
        }

        public void CreateClick(object sender, RoutedEventArgs e)
        {
            Parent.ShowCreateQuiz();
        }


        public void EditClick(object sender, RoutedEventArgs e)
        {
            Parent.ShowChooseQuiz(ChosenQuiz =>
            {
                Parent.ShowEditQuiz(ChosenQuiz);
            });
            
        }
    }
}
