using Labb3_NET22.DataModels;
using Labb3_NET22.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadSavedQuizzes();
            ShowHome();
        }


        public async void LoadSavedQuizzes()
        {
            var files = QuizStorage.GetAllSavedQuizzes();
            foreach(var file in files)
            {
                await QuizStorage.LoadQuizAsync(file);
            }
        }


        public void ShowHome()
        {
            MainContent.Content = new HomeUserControl(this);
        }

        public void ShowCreateQuiz()
        {
            MainContent.Content = new CreateUserControl(this);
        }

        public void ShowQuestionCreation(Quiz quiz, EditUserControl edit)
        {
            MainContent.Content = new QuestionCreationUserControl(quiz, this, edit);
        }


        public void ShowQuestionCreation(Quiz quiz,Question q, EditUserControl edit)
        {
            MainContent.Content = new QuestionCreationUserControl(quiz, q, this, edit);
        }


        public void ShowChooseQuiz(Action<Quiz> onChosenQuiz)
        {
            var chooseControl = new ChooseQuizUserControl(this);
            chooseControl.ChosenQuiz += quiz =>
            {
                onChosenQuiz(quiz);
            };

            MainContent.Content = chooseControl;
        }


        public void ShowChooseCategory(Quiz quiz)
        {
            MainContent.Content = new ChooseCategoryUserControl(this, quiz);
        }


        public void ShowEditQuiz(Quiz ChosenQuiz)
        {
            MainContent.Content = new EditUserControl(ChosenQuiz, this);
        }


        public void ShowPlayQuiz(Quiz ChosenQuiz)
        {
            MainContent.Content = new PlayQuizUserControl(ChosenQuiz,this);
        }
       

        public void ShowScoreScreen(PlayQuizViewModel vm, PlayQuizUserControl source)
        {

            MainContent.Content = new ScoreScreenUserControl(vm,this);
        }
    }
}
