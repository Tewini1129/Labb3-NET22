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
        public MainWindow Parent { get; set; }
        public Quiz quiz { get; set; }


        public ChooseCategoryUserControl()
        {
            InitializeComponent();
        }

        public ChooseCategoryUserControl(MainWindow parent, Quiz newQuiz)
        {
            InitializeComponent();
            Parent = parent;
            quiz = newQuiz;
            LoadCategories();

        }
        public void LoadCategories()
        {
            if(quiz == null)
            {
                return;
            }
            var quizCategories = quiz.Questions
                .GroupBy(q => q.Category)
                .Select(g => g.Key)
                .ToList();
            

            CategoriesListBox.ItemsSource = quizCategories;
        }


        public void CategoriesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CategoriesListBox.SelectedItem is Categories selectedCategory)
            {
                quiz.ChosenCategory = selectedCategory;
                Parent.ShowPlayQuiz(quiz);
            }
        }

        private void MixedCategoriesBtn_Click(object sender, RoutedEventArgs e)
        {
            quiz.ChosenCategory = null;
            Parent.ShowPlayQuiz(quiz);

        }
    }
}
