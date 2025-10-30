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
   
    public partial class CreateUserControl : UserControl
    {
        public MainWindow Parent { get; set; }
        public Quiz NewQuiz = new("");

        public CreateUserControl(MainWindow parent)
        {
            InitializeComponent();
            Parent = parent;
        }


        public void CreateQuizClick(object sender, RoutedEventArgs e)
        {
            string Title = QuizTitel.Text;
            NewQuiz.RenameQuiz(Title);
            Parent.ShowEditQuiz(NewQuiz);
        }
        
    }
}
