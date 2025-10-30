using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class EditUserControl : UserControl
    {
        public MainWindow Parent { get; set; }
        public int QuestionCount { get; set; }
        public Quiz NewQuiz { get; set; }


        public EditUserControl(Quiz newQuiz, MainWindow parent)
        {
            InitializeComponent();
            Parent = parent;
            NewQuiz = newQuiz;
            EditingTitle.Text = newQuiz.Title;
            QuestionsListBox.ItemsSource = NewQuiz.Questions;
            QuestionCount = newQuiz.Questions.Count();
            AmountOfQuestions.Text = $"All Questions - currently {QuestionCount} Questions";
        }


        public void AddQuestionClick(object sender, RoutedEventArgs e)
        {
            Parent.ShowQuestionCreation(NewQuiz, this);
            QuestionsListBox.ItemsSource = null;
            QuestionsListBox.ItemsSource = NewQuiz.Questions;
            AmountOfQuestions.Text = null;
            QuestionCount = (NewQuiz.Questions.Count());
            AmountOfQuestions.Text = $"All Questions - currently {QuestionCount} Questions";


        }


        public void RenameClick(object sender, RoutedEventArgs e)
        {
            RenameWindow1 Rename = new(NewQuiz);
            Rename.ShowDialog();
            EditingTitle.Text = null;
            EditingTitle.Text = NewQuiz.Title;
        }


        public void EditQuestion_Click(object sender, MouseButtonEventArgs e)
        {
            if(QuestionsListBox.SelectedItem is Question question)
            {
                var questionControl = new QuestionCreationUserControl(NewQuiz, Parent, this);
                Parent.ShowQuestionCreation(NewQuiz,question, this);

            }

        }


        private async void SaveQuizClick(object sender, RoutedEventArgs e)
        {
            try
            {
                await QuizStorage.SaveQuizAsync(NewQuiz);
                MessageBox.Show("Quiz saved successfully!", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                Parent.ShowHome();
            }
            catch
            {
                MessageBox.Show("Failed to save Quiz", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void DeleteQuizClick(object sender, RoutedEventArgs e)
        {
            QuizStorage.DeleteQuiz(NewQuiz);
            Parent.ShowHome();

        }
    }
}
