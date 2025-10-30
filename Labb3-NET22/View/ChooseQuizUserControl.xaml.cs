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
    /// Interaction logic for ChooseQuizWindow1.xaml
    /// </summary>
    public partial class ChooseQuizUserControl : UserControl
    {
        public MainWindow Parent { get; set; }
        public event Action<Quiz>? ChosenQuiz;

        public ChooseQuizUserControl(MainWindow parent)
        {
            InitializeComponent();
            Parent = parent;
            QuizListBox.ItemsSource = QuizStorage.AllQuizzes;
            
        }

       


        public void QuizListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(QuizListBox.SelectedItem is Quiz quiz)
            {
                ChosenQuiz?.Invoke(quiz);
            }
        }

        public void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Parent.ShowHome();
        }

    }
}
