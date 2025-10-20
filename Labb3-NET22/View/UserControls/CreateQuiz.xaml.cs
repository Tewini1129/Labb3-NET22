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
using Labb3_NET22.DataModels;

namespace Labb3_NET22.View.UserControls
{

    public partial class CreateQuiz : UserControl
    {
        public Quiz NewQuiz = new Quiz();
        public static List<Question> QuizQuestions = new List<Question>();
        public QuestionCreationWindow QCW = new QuestionCreationWindow();

        public void NrOfQuestions()
        {
            CurrentQuestions.Text = $"You currently have {QuizQuestions.Count} questions";
        }
        
        public CreateQuiz()
        {
            InitializeComponent();
        }
        public void AddQuestionClick(object sender, RoutedEventArgs e)
        {
            
            QCW.Show();
            
        }
    }
}
