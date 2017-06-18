using System.Windows;
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text == ADMIN_LOGIN && passwordTextBox.Password == ADMIN_PASSWORD)
            {
                loginStatus = LoginStatus.LoggedAsAdmin;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            } else
            {
                MessageBox.Show("Wprowadź poprawne dane logowania!");
            }
        }

        private void EnterAsAnonymousButton_Click(object sender, RoutedEventArgs e)
        {
            loginStatus = LoginStatus.LoggedAsAnon;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
