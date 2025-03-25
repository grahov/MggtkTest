﻿using MggtkTest.ViewModel;
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

namespace MggtkTest
{
    /// <summary>
    /// Логика взаимодействия для AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var result = (DataContext as MainWindowViewModel).AddNewStudent();

            if (result)
            {
                MessageBox.Show("Объект записан");
                ((this.Owner as MainWindow).DataContext as MainWindowViewModel).LoadStudent();
                this.Close();
            }
        }
    }
}
