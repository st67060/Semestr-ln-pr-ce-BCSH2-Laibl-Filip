using SemPrace.ViewModel;
using System.Windows;

namespace SemPrace.View
{
    /// <summary>
    /// Interakční logika pro DialogConfirm.xaml
    /// </summary>
    public partial class DialogConfirm : Window
    {
        public DialogConfirm()
        {
            InitializeComponent();
            DataContext = new DialogConfirmViewModel();

            var viewModel = DataContext as DialogConfirmViewModel;
            if (viewModel != null)
            {
                viewModel.RequestClose += (s, e) => this.Close();
                viewModel.RequestDialogResult += (s, result) =>
                {
                        DialogResult = result;                    
                };
            }

        }
    }
}
