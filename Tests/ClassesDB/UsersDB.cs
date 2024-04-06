using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using Tests.Models;

namespace Tests.ClassesDB
{    
    internal class UsersDB
    {
        private TestsContext _usersContext;
       
        public UsersDB()
        {
            _usersContext = new TestsContext();
        }

        // Метод для проверки логина и пароля при аутентификации пользователя
        public bool Authenticate(string login, string password)
        {
            try
            {
                // Проверяем, существует ли пользователь с указанным логином и паролем в базе данных
                return _usersContext.Users.Any(u => u.Login == login && u.Password == password);
            }
            catch (Exception ex)
            {
                // В случае возникновения ошибки выводим сообщение об ошибке
                MessageBox.Show("Произошла ошибка при аутентификации: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        // Метод для добавления нового пользователя в базу данных
        public void UserInsert(User user)
        {
            try
            {
                // Проверяем, существует ли пользователь с указанным логином
                if (_usersContext.Users.Any(s => s.Login == user.Login))
                {
                    MessageBox.Show("Такой логин существует!");
                }
                else
                {
                    _usersContext.Users.Add(user); // Добавляем нового пользователя
                    _usersContext.SaveChanges(); // Сохраняем изменения в базе данных
                    MessageBox.Show("Пользователь успешно добавлен!");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Ошибка при добавлении пользователя: " + ex.Message);
                throw;
            }
        }

        // Метод для аутентификации пользователя и получения его ID
        public int AuthenticateAndGetUserId(string login, string password)
        {
            // Находим пользователя с указанным логином и паролем в базе данных
            User user = _usersContext.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                return user.Id; // Возвращаем ID пользователя в случае успешной аутентификации
            }
            return -1;
        }

        // Метод для добавления результата теста в базу данных
        public void TestResultInsert(TestResult newTestResult)
        {
            // Создаем новый контекст базы данных для операции добавления результата теста
            using (var context = new TestsContext())
            {
                context.TestResults.Add(newTestResult);
                context.SaveChanges(); // Сохраняем изменения в базе данных
            }
        }
    }
}
