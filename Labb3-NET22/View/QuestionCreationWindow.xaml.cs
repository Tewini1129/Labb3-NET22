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
        public Question.Categories Category { get; set; }
        public string Statement { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }
        Quiz NewQuiz { get; set; }
        public string? imageUrl { get; set; }


        public QuestionCreationWindow(Quiz newQuiz)
        {
            InitializeComponent();
            NewQuiz = newQuiz;

        }

        public QuestionCreationWindow(Quiz newQuiz, Question q)
        {
            InitializeComponent();
            NewQuiz = newQuiz;
            QuestionText.Text = q.Statement;
            if(q.ImageUrl != null)
            {
                ImageUrlBox.Text = q.ImageUrl;
            }
            CategoryComboBox.SelectedItem = q.Category;
            FirstAnswer.Text = q.Answers[0];
            SecondAnswer.Text = q.Answers[1];
            ThirdAnswer.Text = q.Answers[2];
            CorrectAnswer = q.CorrectAnswer;



        }



        public void CorrectAnswer_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = sender as Button;
            CorrectAnswer = int.Parse(ClickedButton.Tag.ToString());

            var Buttons = new List<Button>() { FirstAnswerBtn, SecondAnswerBtn, ThirdAnswerBtn };

            foreach(Button b in Buttons)
            {
                b.Background = b == ClickedButton
                    ? new SolidColorBrush(Colors.LightGreen)
                    : new SolidColorBrush(Colors.Red);
            }
            
        }
        


        private void PreviewImage(object sender, TextChangedEventArgs e)
        {
            if(Uri.TryCreate(ImageUrlBox.Text, UriKind.Absolute, out Uri? uri))
            {
                try
                {
                    ImagePreviewBox.Source = new BitmapImage(uri);
                }
                catch
                {
                    ImagePreviewBox.Source = null;
                }
            }
            else
            {
                ImagePreviewBox.Source = null;
            }
        }




        public void SaveQuestionClick(object sender, RoutedEventArgs e)
        {
            if ((Category.ToString() == "Select category") ||
                (QuestionText.Text == "")||
                (FirstAnswer.Text == "")||
                (SecondAnswer.Text == "")||
                (ThirdAnswer.Text == "")||
                (CorrectAnswer < 0))
            {
                var result = MessageBox.Show(
                    "You must fill in Everything",
                    "Something is Empty",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
            else
            {
                if(ImageUrlBox.Text != "")
                {
                    imageUrl = ImageUrlBox.Text;
                }
                Category = (Question.Categories)Enum.Parse(
                typeof(Question.Categories),
                (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
                );
                Statement = QuestionText.Text;
                Answers = [FirstAnswer.Text, SecondAnswer.Text, ThirdAnswer.Text];
                Question q = new Question(Category, Statement, Answers, CorrectAnswer);
                q.ImageUrl = imageUrl;
                NewQuiz.AddQuestion(q);
                Close();

            }
        
        }


        public void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is EditWindow1 parentWindow)
            {

                if (parentWindow.QuestionsListBox.SelectedItem is Question selectedQuestion)
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete this question:\n\n\"{selectedQuestion.Statement}\"?",
                        "Delete Question",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        int i = NewQuiz.Questions
                            .ToList()
                            .IndexOf(selectedQuestion);
                        NewQuiz.RemoveQuestion(i);
                        parentWindow.QuestionsListBox.ItemsSource = null;
                        parentWindow.QuestionsListBox.ItemsSource = NewQuiz.updatedList;
                        int questionsCount = NewQuiz.Questions.Count();
                        parentWindow.AmountOfQuestions.Text = $"All Questions - currently {questionsCount} Questions";
                    }
                }
                Close();
            }

        }
    }
}
