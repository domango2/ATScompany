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

namespace ATScompanySpace
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = NameTextBox.Text;
            string password = PasswordBox.Password;
            DateTime birthDate = BirthDatePicker.SelectedDate ?? DateTime.MinValue;
            string address = AddressTextBox.Text;
            Client client = new Client(username, address, birthDate, password);
            ATScompany.Instance.AddClient(client);
            ATScompany.Instance.SaveAll();
            MessageBox.Show($"Регистрация прошла успешно\n" +
                $"Вам присвоен номер телефона {client.PhoneNumber}\n" +
                $"Он же будет являться вашим логином для входа в учётную запись");
            this.Hide();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

    }
}
