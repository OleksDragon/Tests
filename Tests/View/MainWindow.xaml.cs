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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tests.ClassesDB;

namespace Tests.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestsContext _testsContext;
        public int testId;
        public MainWindow()
        {
            InitializeComponent();
            _testsContext = new TestsContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что отправитель (sender) является кнопкой
            if (sender is Button clickedButton)
            {
                // Получаем контент нажатой кнопки (имя теста)
                var testName = clickedButton.Content as string;

                // Ищем тест в базе данных по имени
                var test = _testsContext.Tests.FirstOrDefault(t => t.Name == testName);

                // Проверяем, что тест найден
                if (test != null)
                {
                    // Присваиваем Id найденного теста переменной testId
                    testId = test.Id;

                    // Создаем окно для вопросов и показываем его
                    QuestionWindow questionWindow = new QuestionWindow(testId);
                    questionWindow.Show();
                }
                else
                {
                    MessageBox.Show("Тест не найден в базе данных.");
                }
            }
        }
    }
}
