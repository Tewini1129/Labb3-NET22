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
   
    public partial class CreateWindow : Window
    {
        public Quiz NewQuiz = new("");

        public CreateWindow()
        {
            InitializeComponent();
        }
        public void CreateQuizClick(object sender, RoutedEventArgs e)
        {
            string Title = QuizTitel.Text;
            NewQuiz.RenameQuiz(Title);
            EditWindow1 EditNewQuiz = new(NewQuiz);
            EditNewQuiz.Show();
            Close();
        }
        
    }
}
