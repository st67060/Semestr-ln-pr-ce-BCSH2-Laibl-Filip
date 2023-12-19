using SemPrace.ViewModel;
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

namespace SemPrace.View
{
    /// <summary>
    /// Interakční logika pro DialogKnihaAdd.xaml
    /// </summary>
    public partial class DialogKnihaAdd : Window
    {
        public DialogKnihaAdd(DialogKnihaAddViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            viewModel.RequestClose += (s, e) => this.Close();
            viewModel.RequestDialogResult += (s, result) =>
            {
                DialogResult = result;
            };
        }
    }
}
