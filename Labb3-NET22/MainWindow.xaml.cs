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
        }
        public void PlayClick(object sender, RoutedEventArgs e)
        {
            ChooseQuizWindow1 ChooseQuiz = new();
            ChooseQuiz.ShowDialog();
            if (ChooseQuiz.selectedQuiz != null)
            {
                Quiz ChosenQuiz = ChooseQuiz.selectedQuiz;
                PlayQuizWindow Play = new PlayQuizWindow(ChosenQuiz);
                Play.ShowDialog();
            }
        }

        public void CreateClick(object sender, RoutedEventArgs e)
        {
            CreateWindow CreateQuiz = new CreateWindow();
            CreateQuiz.Show();
        }

        public void EditClick(object sender, RoutedEventArgs e)
        {
            ChooseQuizWindow1 Choose = new();
            Choose.ShowDialog();
            if(Choose.selectedQuiz != null)
            {
                Quiz ChosenQuiz = Choose.selectedQuiz;
                EditWindow1 edit = new EditWindow1(ChosenQuiz);
                edit.ShowDialog();
            }
        }
    }
}
