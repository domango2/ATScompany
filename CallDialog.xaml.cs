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
    /// Interaction logic for CallDialog.xaml
    /// </summary>
    public partial class CallDialog : Window
    {
        public Client CurrentClient { get; set; }

        public CallDialog(Client client)
        {
            InitializeComponent();
            DataContext = CurrentClient = client;

        }
        private void MakeCallButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(CallDatePicker.Text, out DateTime callDate) &&
                int.TryParse(CallDurationTextBox.Text, out int duration))
            {
                bool isIncoming = IsIncomingCheckBox.IsChecked ?? false;
                string clientId = CurrentClient.Id; // Вам нужно уточнить, откуда получить идентификатор клиента

                CurrentClient.MakeCall(callDate, duration, isIncoming, clientId);

                // Закрываем диалоговое окно после создания звонка
                this.DialogResult = true;
            }
            else
            {
                // Обработка ошибки ввода данных
                MessageBox.Show("Пожалуйста, введите корректные данные для звонка.");
            }
        }

    }

}
