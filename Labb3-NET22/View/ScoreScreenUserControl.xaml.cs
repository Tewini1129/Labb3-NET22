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


namespace Labb3_NET22.View
{
    public partial class ScoreScreenUserControl : UserControl
    {
        public MainWindow Parent { get; set; }
        PlayQuizViewModel Vm { get; set; }


        //public ScoreScreenUserControl()
        //{
        //    InitializeComponent();
        //    Parent = Window.GetWindow(this) as MainWindow;
        //}


        public ScoreScreenUserControl(PlayQuizViewModel vm,MainWindow parent)
        {
            InitializeComponent();
            Vm = vm;
            Parent = parent;
            LoadViewModel(vm);
        }

        public void LoadViewModel(PlayQuizViewModel viewModel)
        {
            DataContext = viewModel;
            viewModel.Judgement();

        }


        public void CloseQuiz_Click(object sender, RoutedEventArgs e)
        {
            Parent.ShowHome();
        }


        
    }
}
