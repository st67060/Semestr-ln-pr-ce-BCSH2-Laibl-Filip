using SemPrace.Dialog;
using SemPrace.Model;
using SemPrace.Utility;
using SemPrace.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SemPrace.View
{
    /// <summary>
    /// Interakční logika pro Main.xaml
    /// </summary>
    public partial class Main : Window
    {


        public Main()
        {
            MainViewModel mainViewModel = new MainViewModel();
            InitializeComponent();
            DataContext = mainViewModel;
            mainViewModel.RequestClose += (s, e) => this.Close();
            mainViewModel.RequestMinimize += (s, e) => this.WindowState = WindowState.Minimized; 
        }
    }
        
}

