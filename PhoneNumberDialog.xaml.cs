﻿using System;
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

namespace ATScompany
{
    /// <summary>
    /// Interaction logic for PhoneNumberDialog.xaml
    /// </summary>
    public partial class PhoneNumberDialog : Window
    {
        private void login_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmButton_Click(sender, e);
            }
        }
        public string PhoneNumber { get; private set; }
        public PhoneNumberDialog()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumber = PhoneNumberTextBox.Text;
            this.DialogResult = true;
        }
    }
}
