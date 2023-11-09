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
using ATScompany;

namespace ATScompanySpace
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string buttonText = clickedButton.Content.ToString();

            switch (buttonText)
            {
                case "Список клиентов":
                    displayText.Text = ATScompany.Instance.PrintAllClients();
                    break;
                case "Список счетов":
                    displayText.Text = ATScompany.Instance.PrintAllInvoices();
                    break;
                case "Список звонков":
                    displayText.Text = ATScompany.Instance.PrintAllCalls();
                    break;
                case "Информация о клиенте":
                    ClientInfo_Click(sender, e);
                    break;
                case "Выставить счета":
                    displayText.Text = "Счета выставлены успешно";
                    ATScompany.Instance.SaveAll();
                    break;
                default:
                    displayText.Text = "Другой текст...";
                    break;
            }
        }

        private void ClientInfo_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumberDialog dialog = new PhoneNumberDialog();
            if (dialog.ShowDialog() == true)
            {
                string phoneNumber = dialog.PhoneNumber;
                Client foundClient = ATScompany.Instance.FindClientByPhoneNumber(phoneNumber);

                if (foundClient != null)
                {
                    displayText.Text = foundClient.PrintClientInfo();
                }
                else
                {
                    displayText.Text = "Клиент с указанным номером не найден.";
                }
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close(); // Закрыть текущее окно AdminPanel
        }
    }
}
