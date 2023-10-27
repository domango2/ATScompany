using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ATScompany
{
    public class StartLogic
    {
        public static StartLogic logic = new StartLogic();
        private TextBox login;
        private TextBox password;

        public void Authorization(ref TextBox login1, ref TextBox pass1)
        {
            login = login1;
            password = pass1;
        }
        public void Enter_Click(object sender, EventArgs e)
        {
            if (login.Text == "admin" && password.Text == "admin")
            {
                (sender as Button).Content = "Админ";

            }
            else
            {
                (sender as Button).Content = "Чорт";
            }

        }

        public void Registration_Click(object sender, EventArgs e)
        {
            (sender as Button).Content = "не привет";
        }
    }
}
