using System;
using System.Collections.Generic;
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

        // Метод для проверки логина и пароля
        public bool Authenticate(string login, string password)
        {
            try
            {
                // Проверяем, существует ли пользователь с указанным логином и паролем
                return _usersContext.Users.Any(u => u.Login == login && u.Password == password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при аутентификации: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }     

        public void UserInsert(User user)
        {
            try
            {
                if (_usersContext.Users.Any(s => s.Login == user.Login))
                {
                    MessageBox.Show("Такой логин существует!");
                }
                else
                {
                    _usersContext.Users.Add(user);
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
        public void SaveChanges()
        {
            try
            {
                _usersContext.SaveChanges(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
                throw;
            }
        }        
    }
}
