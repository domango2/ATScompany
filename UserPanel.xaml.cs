using ATScompany;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        public Client CurrentClient { get; set; }

        public UserPanel(Client client)
        {
            InitializeComponent();
            DataContext = CurrentClient = client;
            //userName.Text = CurrentClient.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string buttonText = clickedButton.Content.ToString();

            switch (buttonText)
            {
                case "Мои данные":
                    displayText.Text = CurrentClient.ToString();
                    break;
                case "Выставленные счета":
                    displayText.Text = CurrentClient.ReceiveInvoice();
                    break;
                case "Оплатить счета":
                    decimal amount = Payment_Click(sender, e);
                    displayText.Text = CurrentClient.PayInvoice(amount);
                    ATScompany.Instance.SaveAll();
                    break;
                case "Пополнить счет":
                    decimal overpayment = Payment_Click(sender, e);
                    displayText.Text = CurrentClient.AddOverpayment(overpayment);
                    ATScompany.Instance.SaveAll();
                    break;
                case "Сделать звонок":
                    MakeCallButton_Click(sender, e);
                    ATScompany.Instance.SaveAll();
                    break;
                default:
                    displayText.Text = "Другой текст...";
                    break;
            }
        }

        private decimal Payment_Click(object sender, RoutedEventArgs e)
        {
            Payment dialog = new Payment();
            if (dialog.ShowDialog() == true)
            {
                string amount = dialog.PaymentAmount;

                if (amount != null)
                {
                    return Convert.ToDecimal(amount);
                }
                else
                {
                    displayText.Text = "Неверный ввод";
                    return 0;
                }
            }
            return 0;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close(); // Закрыть текущее окно AdminPanel
        }
        private void MakeCallButton_Click(object sender, RoutedEventArgs e)
        {
            CallDialog dialog = new CallDialog(CurrentClient);
            if (dialog.ShowDialog() == true)
            {
                // Вывести информацию о звонке
                displayText.Text = "Звонок создан: Дата: " + dialog.CallDatePicker.Text +
                                    ", Продолжительность: " + dialog.CallDurationTextBox.Text +
                                    ", Входящий: " + (dialog.IsIncomingCheckBox.IsChecked ?? false);
            }
        }
    }
}
