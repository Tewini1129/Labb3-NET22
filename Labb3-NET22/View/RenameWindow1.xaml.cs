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
using System.Windows.Shapes;
using Labb3_NET22.DataModels;

namespace Labb3_NET22.View
{
    /// <summary>
    /// Interaction logic for RenameWindow1.xaml
    /// </summary>
    public partial class RenameWindow1 : Window
    {
        public Quiz NewQuiz;
        public RenameWindow1(Quiz newQuiz)
        {
            InitializeComponent();
            NewQuiz = newQuiz;
        }

        public void GotFocus(object sender, RoutedEventArgs e)
        {
            var box = sender as TextBox;
            if(box.Text == "Enter new title...")
            {
                box.Text = "";
                box.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        public void LostFocus(object sender, RoutedEventArgs e)
        {
            var box = sender as TextBox;
            if(string.IsNullOrWhiteSpace(box.Text))
            {
                box.Text = "Enter new title...";
                box.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }


        public void SaveNewTitleClick(object sender, RoutedEventArgs e)
        {
            NewQuiz.RenameQuiz(NewTitle.Text);
            Close();
        }

    }
}
