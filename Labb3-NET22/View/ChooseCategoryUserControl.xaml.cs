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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Labb3_NET22.DataModels.Question;

namespace Labb3_NET22.View
{
    public partial class ChooseCategoryUserControl : UserControl
    {
        public Quiz quiz { get; set; }
        public ChooseCategoryUserControl()
        {
            InitializeComponent();
        }
        public void LoadCategories()
        {
            var quizCategories = quiz.Questions.GroupBy(q => q.Category)
                .Select(g => g.Key)
                .ToList();
            

            CategoriesListBox.ItemsSource = quizCategories;
        }


        private void CategoriesListBox_Click(object sender, MouseButtonEventArgs e)
        {
            quiz.ChosenCategory = (Categories)CategoriesListBox.SelectedItem;
            var parentWindow = Window.GetWindow(this) as PlayQuizWindow;
            parentWindow.RemoveOverlay();
            Visibility = Visibility.Collapsed;
            parentWindow.ViewModel.SetNewQuestion(quiz.GetRandomQuestion());
        }


        private void MixedCategoriesBtn_Click(object sender, RoutedEventArgs e)
        {
            quiz.ChosenCategory = null;
            var parentWindow = Window.GetWindow(this) as PlayQuizWindow;
            parentWindow.RemoveOverlay();
            Visibility = Visibility.Collapsed;
        }
    }
}
