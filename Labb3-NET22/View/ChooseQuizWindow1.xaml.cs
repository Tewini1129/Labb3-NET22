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
    public partial class ChooseQuizWindow1 : Window
    {
        public Quiz selectedQuiz { get; set; }

        public ChooseQuizWindow1()
        {
            InitializeComponent();
            LoadQuizList();
        }

        public void LoadQuizList()
        {
            var quizFiles = QuizStorage.GetAllSavedQuizzes();
            var quizNames = quizFiles.Select(f => System.IO.Path.GetFileNameWithoutExtension(f));

            QuizListBox.ItemsSource = quizNames.ToList();
        }

        private async void QuizListBox_Click(object sender, MouseButtonEventArgs e)
        {
            if(QuizListBox.SelectedItem is string quizFileName)
            {
                string fileName = quizFileName.EndsWith(".json") ? quizFileName : quizFileName + ".json";
                var loadedQuiz = await QuizStorage.LoadQuizAsync(fileName);
                selectedQuiz = loadedQuiz;
                Close();
            }
                      
        }
    }
}
