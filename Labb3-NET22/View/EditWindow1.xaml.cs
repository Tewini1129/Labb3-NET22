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
    /// Interaction logic for EditWindow1.xaml
    /// </summary>
    public partial class EditWindow1 : Window
    {
        public Quiz NewQuiz;
        public EditWindow1(Quiz newQuiz)
        {
            InitializeComponent();
            NewQuiz = newQuiz;
            EditingTitle.Text = newQuiz.Title;
            QuestionsListBox.ItemsSource = NewQuiz.Questions;
        }
        public void AddQuestionClick(object sender, RoutedEventArgs e)
        {
            var QCW = new QuestionCreationWindow(NewQuiz);
            QCW.ShowDialog();
            QuestionsListBox.ItemsSource = null;
            QuestionsListBox.ItemsSource = NewQuiz.Questions;
            AmountOfQuestions.Text = null;
            string QuestionCount = (NewQuiz.Questions.Count().ToString());
            AmountOfQuestions.Text = $"All Questions - currently {QuestionCount} Questions";


        }
        public void RenameClick(object sender, RoutedEventArgs e)
        {
            RenameWindow1 Rename = new(NewQuiz);
            Rename.ShowDialog();
            EditingTitle.Text = null;
            EditingTitle.Text = NewQuiz.Title;
        }

        public void SaveQuizClick(object sender, RoutedEventArgs e)
        {

        }
        public void DeleteQuizClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
