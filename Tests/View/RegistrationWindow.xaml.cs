using Tests.ClassesDB;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Tests.Models;

namespace Tests.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private UsersDB usersDB;
        private User currentUser; // Объявляем переменную currentUser

        public RegistrationWindow(User currentUser = null) // Добавляем параметр currentUser в конструктор
        {
            InitializeComponent();
            usersDB = new UsersDB();
            this.currentUser = currentUser; // Инициализируем переменную currentUser перед использованием
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(tBLoginR.Text) || string.IsNullOrWhiteSpace(passBoxPassword.Password)
                || string.IsNullOrWhiteSpace(tBEmail.Text) || string.IsNullOrWhiteSpace(maskedTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля перед сохранением.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Выходим из метода, чтобы не добавлять пустого пользователя
            }

            if (currentUser == null)
            {
                // Создание нового пользователя
                User newUser = new User
                {
                    Login = tBLoginR.Text,
                    Password = passBoxPassword.Password,
                    Email = tBEmail.Text,
                    PhoneNumber = maskedTextBox.Text // Добавляем значение из maskedTextBox
                };
                usersDB.UserInsert(newUser);

                // Создаем новую запись TestResult для нового пользователя
                TestResult newTestResult = new TestResult
                {
                    UserId = newUser.Id, // Используем Id только что созданного пользователя
                    Score = 0 // Устанавливаем Score в 0
                };

                // Добавляем новую запись TestResult в базу данных
                usersDB.TestResultInsert(newTestResult);
            }

            // Закрыть текущее окно регистрации
            this.Close();
        }
    }
}
