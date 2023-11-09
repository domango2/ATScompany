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

namespace ATScompanySpace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private void login_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OpenSecondWindow_Click(sender, e);
            }
        }
        private void OpenSecondWindow_Click(object sender, RoutedEventArgs e)
        {
            double currentLeft = this.Left;
            double currentTop = this.Top;
            double currentWidth = this.Width;
            double currentHeight = this.Height;

            if (login.Text == "admin" && password.Password == "admin")
            {

                AdminPanel adminPanel = new AdminPanel();
                if (this.WindowState == WindowState.Maximized)
                {
                    adminPanel.WindowState = WindowState.Maximized;
                }
                else
                {
                    adminPanel.Left = currentLeft;
                    adminPanel.Top = currentTop;
                    adminPanel.Width = currentWidth;
                    adminPanel.Height = currentHeight;
                }
                adminPanel.Show();
                this.Close();

            }
            else
            {
                Client client1 = ATScompany.Instance.Authorization(login.Text, password.Password);
                if (client1 != null)
                {
                    UserPanel userPanel = new UserPanel(client1);
                    if (this.WindowState == WindowState.Maximized)
                    {
                        userPanel.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        userPanel.Left = currentLeft;
                        userPanel.Top = currentTop;
                        userPanel.Width = currentWidth;
                        userPanel.Height = currentHeight;
                    }
                    userPanel.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Некорректный ввод. Пожалуйста, проверьте логин и пароль.");
                    login.Clear();
                    password.Clear();

                }
            }
        }

        private void Login(object sender, TextCompositionEventArgs e)
        {
            string login = e.Text;
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = e.ToString();
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Owner = this; // Установите главное окно владельцем окна регистрации.
            registrationWindow.ShowDialog(); // Отобразите окно регистрации как диалог.
        }
        public MainWindow()
        {
            InitializeComponent();
            ATScompany.Instance.LoadAll();
        }
    }
}
