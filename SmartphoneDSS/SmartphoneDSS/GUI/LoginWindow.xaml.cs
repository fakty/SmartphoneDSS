using SmartphoneDSS.Database.Utilities;
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
using static SmartphoneDSS.Database.Utilities.AccountManager;

namespace SmartphoneDSS.GUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text == AccountManager.ADMIN_LOGIN && passwordTextBox.Password == AccountManager.ADMIN_PASSWORD)
            {
                AccountManager.loginStatus = AccountManager.LoginStatus.LoggedAsAdmin;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Wprowadź poprawne dane logowania!");
            }
        }

        private void enterAsAnonymousButton_Click(object sender, RoutedEventArgs e)
        {
            AccountManager.loginStatus = AccountManager.LoginStatus.LoggedAsAnon;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
