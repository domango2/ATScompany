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
using System.Text.Json.Serialization;
using System.Net;

namespace ATScompany
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void Login(object sender, TextCompositionEventArgs e)
        {
            string login = e.Text;
        }
        private void Password(object sender, TextCompositionEventArgs e)
        {
            string password = e.Text;
        }
        public MainWindow()
        {
            InitializeComponent();
            StartLogic.logic.Authorization(ref login, ref password);
            Enter.Click += StartLogic.logic.Enter_Click;
            Registration.Click += StartLogic.logic.Registration_Click;
            
        }
    }
}
