﻿using MggtkTest.Model;
using MggtkTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MggtkTest
{
    /// <summary>
    /// Логика взаимодействия для AddStudentWindow.xaml
    /// </summary>
    public partial class AddOrEditStudentWindow : Window
    {
        public AddOrEditStudentWindow(Student student)
        {
            InitializeComponent();

            if (student != null) {
                DataContext = new MainWindowViewModel(student);
            } else
            {
                DataContext = new MainWindowViewModel();
            }

            
        }

        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            loadTextBox.Visibility = Visibility.Visible;
 
            var result = await (DataContext as MainWindowViewModel).AddOrEditStudent();

            loadTextBox.Visibility = Visibility.Collapsed;

            if (result)
            {
                MessageBox.Show("Объект записан");
                ((this.Owner as MainWindow).DataContext as MainWindowViewModel).LoadStudent();
                this.Close();
            }
        }
    }
}
