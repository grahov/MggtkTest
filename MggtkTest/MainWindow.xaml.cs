using MggtkTest.ViewModel;
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

namespace MggtkTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();

            (DataContext as MainWindowViewModel).LoadStudent();
        }

        private void getButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowViewModel).LoadStudent();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowViewModel).DeleteStudent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditStudentWindow addStudentWindow = new AddOrEditStudentWindow(null);
            addStudentWindow.Owner = this;
            addStudentWindow.ShowDialog();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditStudentWindow addStudentWindow = new AddOrEditStudentWindow((DataContext as MainWindowViewModel).SelectedStudent);
            addStudentWindow.Owner = this;
            addStudentWindow.ShowDialog();
        }
    }
}
