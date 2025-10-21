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
using System.Windows.Shapes;

namespace Labb3_NET22.View
{
    /// <summary>
    /// Interaction logic for QuestionCreationWindow.xaml
    /// </summary>
    public partial class QuestionCreationWindow : Window
    {
        public Question.Categories Category;
        public string Statement;
        public string[] Answers;
        public int CorrectAnswer;
        Quiz NewQuiz;
        public QuestionCreationWindow(Quiz newQuiz)
        {
            InitializeComponent();
            NewQuiz = newQuiz;

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

            if(QuestionText.Text != "")
            { 
                Category = (Question.Categories)Enum.Parse(
                    typeof(Question.Categories),
                    (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
                    );
                Statement = QuestionText.Text;
                Answers = [FirstAnswer.Text, SecondAnswer.Text, ThirdAnswer.Text];
                Question q = new Question(Category, Statement, Answers, CorrectAnswer);
                NewQuiz.AddQuestion(q);
                Close();
            }
            else
            {
                Close();
            }
        }
    }
}
