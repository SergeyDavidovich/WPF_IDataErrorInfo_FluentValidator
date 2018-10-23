using System.Windows;
using WPF_IDataErrorInfo_Sample.ViewModels;

namespace WPF_IDataErrorInfo_Sample.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView()
        {
            InitializeComponent();
            DataContext = new UserViewModel();
        }
    }
}
