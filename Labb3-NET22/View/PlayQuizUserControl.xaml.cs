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
    public partial class PlayQuizUserControl : UserControl
    {
        public MainWindow Parent { get; set; }
        public int SelectedAnswer;
        public Quiz newQuiz;
        public Question CurrentQuestion { get; set; }
        public PlayQuizViewModel ViewModel { get; set; }
        
        


        public PlayQuizUserControl(Quiz quiz, MainWindow parent)
        {
            InitializeComponent();
            Parent = parent;
            newQuiz = quiz;
            ViewModel = new(quiz);
            DataContext = ViewModel;
            CurrentQuestion = ViewModel.CurrentQuestion;

        }


        

        public void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentQuestion = ViewModel.CurrentQuestion;
            newQuiz.AnsweredQuestions.Add(CurrentQuestion);
            Button button = sender as Button;
            SelectedAnswer = int.Parse(button.Tag.ToString());
            ViewModel.NextQuestion(SelectedAnswer);
            
            if(newQuiz.Finished == true)
            {
                ShowScoreScreen();
            }
        }



        private void DisplayQuestionImage(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CurrentQuestion.ImageUrl) &&
                Uri.TryCreate(CurrentQuestion.ImageUrl, UriKind.Absolute, out Uri? uri))
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = uri;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    ImageBox.Source = bitmap;
                }
                catch
                {
                    ImageBox.Source = null;
                }
            }
            else
            {
                ImageBox.Source = null;
            }
        }

        public void ShowScoreScreen()
        {
            
            ViewModel.FeedBack = ViewModel.Judgement();
            Parent.ShowScoreScreen(ViewModel,this);
            Answer1Btn.IsEnabled = false;
            Answer2Btn.IsEnabled = false;
            Answer3Btn.IsEnabled = false;
        }

    }
}
