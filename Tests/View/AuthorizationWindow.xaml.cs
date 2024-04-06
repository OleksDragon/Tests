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
        private bool isMainWindowOpened = false; // Флаг, указывающий, открыто ли основное окно приложения
        private MainWindow mainWindow = null;
        private UsersDB usersDB;

        private string login; // Логин пользователя
        private string password; // Пароль пользователя

        public AuthorizationWindow()
        {
            InitializeComponent();
            _testsDB = new TestsDB();
            usersDB = new UsersDB();

            // Обновление ответов в базе данных перед отображением окна аутентификации
            _testsDB.UpdateAnswersInDatabase();
        }

        // Обработчик события нажатия кнопки "Войти"
        private void Authorization_Button_Click(object sender, RoutedEventArgs e)
        {
            login = tBLogin.Text; // Получение логина из текстового поля
            password = passBoxPassword.Password; // Получение пароля из поля ввода пароля

            // Получаем userId из метода AuthenticateAndGetUserId класса UsersDB
            int userId = usersDB.AuthenticateAndGetUserId(login, password);

            if (userId != -1) // Если аутентификация прошла успешно
            {
                if (!isMainWindowOpened) // Если основное окно еще не открыто
                {
                    isMainWindowOpened = true; // Устанавливаем флаг, что основное окно открыто
                    mainWindow = new MainWindow(userId);
                    mainWindow.Closed += (s, args) => isMainWindowOpened = false; // Устанавливаем обработчик события закрытия окна для сброса флага
                    mainWindow.Show();
                    this.Close(); // Закрываем окно аутентификации
                }
                else
                {
                    MessageBox.Show("Окно уже открыто.");
                    mainWindow.Activate(); // Активируем основное окно
                }
            }
            else // Если аутентификация не удалась
            {
                MessageBoxResult result = MessageBox.Show("Неправильный логин или пароль. Доступ запрещен.\nХотите зарегистрироваться?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes) // Если пользователь хочет зарегистрироваться
                {
                    // Открываем новое окно для регистрации
                    RegistrationWindow registrationWindow = new RegistrationWindow();
                    registrationWindow.Show();
                }
            }
        }

        // Обработчик события нажатия кнопки "Зарегистрироваться"
        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            // Открываем новое окно для регистрации
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }
    }
}
