using System.Windows;
using Tests.ClassesDB;

namespace Tests.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private TestsDB _testsDB;
        private bool isMainWindowOpened = false;
        private MainWindow mainWindow = null;
        private UsersDB usersDB; // Исправлено на UsersDB
        private string login;
        private string password;
        public AuthorizationWindow()
        {
            InitializeComponent();
            _testsDB = new TestsDB();
            usersDB = new UsersDB(); // Создание экземпляра UsersDB
        }

        private void Authorization_Button_Click(object sender, RoutedEventArgs e)
        {
            login = tBLogin.Text;
            password = passBoxPassword.Password;

            if (usersDB.Authenticate(login, password))
            {
                if (!isMainWindowOpened)
                {
                    isMainWindowOpened = true;
                    mainWindow = new MainWindow();
                    mainWindow.Closed += (s, args) => isMainWindowOpened = false;
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Окно уже открыто.");
                    mainWindow.Activate();
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Неправильный логин или пароль. Доступ запрещен.\nХотите зарегистрироваться?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    // Открыть новое окно для регистрации

                    RegistrationWindow registrationWindow = new RegistrationWindow(); 
                    registrationWindow.Show();                    
                }
            }
        }

        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }
    }
}
