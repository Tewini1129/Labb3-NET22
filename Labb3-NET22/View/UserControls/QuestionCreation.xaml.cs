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
    /// <summary>
    /// Interaction logic for QuestionCreation.xaml
    /// </summary>
    public partial class QuestionCreation : UserControl
    {
        public Question.Categories Category;
        public string Statement;
        public string[] Answers;
        public int CorrectAnswer;

        public QuestionCreation()
        {
            InitializeComponent();
        }
        public void FirstClick(object sender, RoutedEventArgs e)
        {
            CorrectAnswer = 1;
            FirstAnswerBtn.Background = new SolidColorBrush(Colors.Green);

            SecondAnswerBtn.Background = new SolidColorBrush(Colors.Red);
            ThirdAnswerBtn.Background = new SolidColorBrush(Colors.Red);
        }
        public void SecondClick(object sender, RoutedEventArgs e)
        {
            CorrectAnswer = 2;
            SecondAnswerBtn.Background = new SolidColorBrush(Colors.Green);

            FirstAnswerBtn.Background = new SolidColorBrush(Colors.Red);
            ThirdAnswerBtn.Background = new SolidColorBrush(Colors.Red);

        }


        public void ThirdClick(object sender, RoutedEventArgs e)
        {
            CorrectAnswer = 3;
            ThirdAnswerBtn.Background = new SolidColorBrush(Colors.Green);

            FirstAnswerBtn.Background = new SolidColorBrush(Colors.Red);
            SecondAnswerBtn.Background = new SolidColorBrush(Colors.Red);
        }

        public void SaveQuestionClick(object sender, RoutedEventArgs e)
        {
            Category = (Question.Categories)Enum.Parse(
                typeof(Question.Categories), 
                (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
                );
            Statement = QuestionText.ToString();
            Answers = [FirstAnswer.ToString(), SecondAnswer.ToString(), ThirdAnswer.ToString()];
            Question q = new Question(Category, Statement, Answers, CorrectAnswer);
            CreateQuiz.QuizQuestions.Add(q);
            QuestionCreationWindow QCW = QuestionCreationWindow.GetWindow(this);
            QCW.Close();
        }
    }
}
