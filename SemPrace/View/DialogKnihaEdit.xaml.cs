using SemPrace.ViewModel;
using System.Windows;

namespace SemPrace.View
{
    /// <summary>
    /// Interakční logika pro DialogKnihaEdit.xaml
    /// </summary>
    public partial class DialogKnihaEdit : Window
    {
        public DialogKnihaEdit(DialogKnihaEditViewModel viewModel)
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

