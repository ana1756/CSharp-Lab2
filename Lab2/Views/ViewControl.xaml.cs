using Lab2.ViewModels;
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

namespace Lab2.Views
{
    public partial class ViewControl : UserControl
    {
        private PersonViewModel _viewModel;

        public ViewControl()
        {
            InitializeComponent();
            DataContext = _viewModel = new PersonViewModel();
        }

        private void datePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate != null)
                _viewModel.BirthDate = datePicker.SelectedDate.Value;
        }


    }
}
