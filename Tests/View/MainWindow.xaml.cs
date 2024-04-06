using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tests.ClassesDB;

namespace Tests.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestsContext _testsContext;
        private TestsScores _testsScores;

        public int testId; // Идентификатор текущего теста
        private int _userId; // Идентификатор текущего пользователя
       
        public MainWindow(int userId)
        {
            InitializeComponent();
            _testsContext = new TestsContext();
            _testsScores = new TestsScores();

            _userId = userId;

            // Получаем сумму очков пользователя и отображаем ее
            TotalScoreUser.Text = _testsScores.GetTotalScoreForUser(_userId);

            // Отображаем максимальный балл для каждого теста и окрашиваем соответствующий текст
            _testsScores.DisplayMaxScoreAndColorize("География", GeografymMaxBall, _userId);
            _testsScores.DisplayMaxScoreAndColorize("Музыка", MusicMaxBall, _userId);
            _testsScores.DisplayMaxScoreAndColorize("Спорт", SportMaxBall, _userId);
            _testsScores.DisplayMaxScoreAndColorize("Животные", AnimalMaxBall, _userId);
            _testsScores.DisplayMaxScoreAndColorize("История", HistoryMaxBall, _userId);
        }

        // Обработчик события нажатия кнопки "Начать тест"
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что отправитель (sender) является кнопкой
            if (sender is Button clickedButton)
            {
                // Получаем содержимое Label, которое является дочерним элементом Grid кнопки
                var label = FindVisualChild<Label>(clickedButton);

                // Проверяем, что label не равен null и получаем его содержимое (имя теста)
                var testName = (label?.Content as string) ?? string.Empty;

                // Ищем тест в базе данных по имени
                var test = _testsContext.Tests.FirstOrDefault(t => t.Name == testName);

                // Проверяем, что тест найден
                if (test != null)
                {
                    // Присваиваем Id найденного теста переменной testId
                    testId = test.Id;

                    // Создаем окно для вопросов и показываем его
                    QuestionWindow questionWindow = new QuestionWindow(testId, _userId);

                    // Закрываем текущее окно
                    this.Close();

                    questionWindow.Show();
                }
                else
                {
                    MessageBox.Show("Тест не найден в базе данных."); // Выводим сообщение о том, что тест не найден
                }
            }
        }

        // Метод для поиска дочерних элементов заданного типа
        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        // Обработчик события нажатия кнопки "Сбросить результаты"
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            // Получаем все результаты тестов для данного пользователя
            var userResults = _testsContext.TestResults.Where(tr => tr.UserId == _userId);

            // Перебираем каждый результат и обновляем значение очков на ноль
            foreach (var result in userResults)
            {
                result.Score = 0;
            }

            // Сохраняем изменения в базе данных
            _testsContext.SaveChanges();

            // Обновляем значение TotalScoreUser
            TotalScoreUser.Text = _testsScores.GetTotalScoreForUser(_userId).ToString();
            GeografymMaxBall.Text = _testsScores.GetTotalScoreForUser(_userId).ToString();
            MusicMaxBall.Text = _testsScores.GetTotalScoreForUser(_userId).ToString();
            SportMaxBall.Text = _testsScores.GetTotalScoreForUser(_userId).ToString();
            AnimalMaxBall.Text = _testsScores.GetTotalScoreForUser(_userId).ToString();
            HistoryMaxBall.Text = _testsScores.GetTotalScoreForUser(_userId).ToString();

            // Возвращаем Foreground кнопок на первоначальный
            GeografymMaxBall.Foreground = Brushes.Red;
            MusicMaxBall.Foreground = Brushes.Red;
            SportMaxBall.Foreground = Brushes.Red;
            AnimalMaxBall.Foreground = Brushes.Red;
            HistoryMaxBall.Foreground = Brushes.Red;
        }
    }
}
