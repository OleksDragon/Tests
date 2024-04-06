using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Tests.ClassesDB;
using Tests.Models;

namespace Tests.View
{
    public partial class QuestionWindow : Window, INotifyPropertyChanged
    {
        private TestsContext _testsContext;
        private TestsDB _testsDB;
        private int _currentQuestionIndex = 0;
        private List<Question> _originalQuestions; // Исходный список вопросов
        private List<Question> _incorrectQuestions = new List<Question>(); // Список неправильных ответов
        private int _maxScore; // Максимальный возможный балл за тест
        private int _testId; // Идентификатор теста
        private int _userId; // Идентификатор пользователя


        // Таймер
        private DispatcherTimer _timer;
        private TimeSpan _timeLeft;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsMultipleCorrectAnswers { get; set; } // Флаг, указывающий наличие нескольких правильных ответов

        public int MaxScore // Свойство для максимального балла
        {
            get { return _maxScore; }
            set
            {
                _maxScore = value;
                OnPropertyChanged(nameof(MaxScore));
            }
        }

        private int _totalScore;// Общий балл за тест

        public int TotalScore // Свойство для общего балла
        {
            get { return _totalScore; }
            set
            {
                _totalScore = value;
                OnPropertyChanged(nameof(TotalScore));
            }
        }

        public ObservableCollection<Question> Questions { get; private set; } // Коллекция вопросов
        public ObservableCollection<Answer> ShuffledCurrentQuestionAnswers { get; set; } // Перемешанные ответы для текущего вопроса

        //public int TestId { get; set; }

        // Текущий текст вопроса
        public string CurrentQuestionText => Questions.ElementAtOrDefault(_currentQuestionIndex)?.Text;
        public int TotalQuestionsCount => Questions.Count;  // Общее количество вопросов
        public int CurrentQuestionNumber => _currentQuestionIndex + 1; // Номер текущего вопроса

        public QuestionWindow(int testId, int userId)
        {
            InitializeComponent();
            _testsContext = new TestsContext();
            _testsDB = new TestsDB();

            _testId = testId;
            _userId = userId;

            // Получаем исходный список вопросов для данного теста
            _originalQuestions = _testsContext.Questions.Where(q => q.TestId == testId).ToList();

            // Перемешиваем вопросы и ответы
            ShuffleQuestionsAndAnswers();

            Questions = new ObservableCollection<Question>(_originalQuestions);
            ShuffledCurrentQuestionAnswers = new ObservableCollection<Answer>();

            // Рассчитываем MaxScore
            MaxScore = _originalQuestions.Sum(q => q.Points);

            // Обновляем текущий вопрос
            UpdateCurrentQuestion();

            DataContext = this;

            // Устанавливаем начальное время
            _timeLeft = TimeSpan.FromMinutes(3);

            // Создаем и настраиваем таймер
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        // Метод для обновления текущего вопроса
        private void UpdateCurrentQuestion()
        {
            if (_currentQuestionIndex >= 0 && _currentQuestionIndex < TotalQuestionsCount)
            {
                tblQuestion.Text = CurrentQuestionText; // Устанавливаем текст текущего вопроса
                currentQuestion.Text = CurrentQuestionNumber.ToString(); // Устанавливаем номер текущего вопроса
                
                int questionId = Questions[_currentQuestionIndex].Id; // Получаем ID текущего вопроса

                // Получаем ответы на текущий вопрос из базы данных
                var answers = _testsContext.Answers
                    .Where(a => a.QuestionId == questionId)
                    .ToList();

                // Подсчитываем количество правильных ответов
                int correctAnswersCount = answers.Count(a => a.IsCorrect);

                // Устанавливаем флаг наличия нескольких правильных ответов
                IsMultipleCorrectAnswers = correctAnswersCount > 1;

                // Получаем путь к изображению, если есть
                string imagePath = Questions[_currentQuestionIndex].ImagePath;

                // Устанавливаем изображение, если оно есть
                currentQuestionImage.Source = !string.IsNullOrEmpty(imagePath)
                    ? new BitmapImage(new Uri(imagePath, UriKind.Relative))
                    : null;

                // Перемешиваем ответы
                ShuffleAnswers(answers);

                // Записываем перемешанные ответы в коллекцию
                ShuffledCurrentQuestionAnswers = new ObservableCollection<Answer>(answers);

                DataContext = null;
                DataContext = this;
            }
        }

        // Метод для перемешивания ответов
        private void ShuffleAnswers(List<Answer> answers)
        {
            Random rng = new Random();
            int n = answers.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Answer value = answers[k];
                answers[k] = answers[n];
                answers[n] = value;
            }
        }

        // Метод для перемешивания вопросов и ответов
        private void ShuffleQuestionsAndAnswers()
        {
            Random rng = new Random();
            int n = _originalQuestions.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Question value = _originalQuestions[k];
                _originalQuestions[k] = _originalQuestions[n];
                _originalQuestions[n] = value;

                ShuffleAnswers(value.Answers.ToList());
            }
        }

        // Обработчик нажатия кнопки ответа на вопрос
        private void AnswerQuestion_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранные пользователем ответы
            var selectedAnswers = answersListBox.SelectedItems.Cast<Answer>().ToList();
            var userAnswers = new List<UserAnswer>();

            foreach (var answer in selectedAnswers)
            {
                var userAnswer = new UserAnswer
                {
                    UserId = _userId,
                    AnswerId = answer.Id,
                    IsSelected = true
                };

                userAnswers.Add(userAnswer);
            }

            SaveUserAnswersToDatabase(userAnswers); // Сохраняем ответы пользователя в базу данных
            CheckAnswers(); // Проверяем ответы

            // Переходим к следующему вопросу
            if (_currentQuestionIndex < Questions.Count - 1)
            {
                _currentQuestionIndex++;
                UpdateCurrentQuestion();
            }
            else
            {
                // Если это был последний вопрос, показываем результаты теста
                ShowTestResults();
                _testsDB.UpdateAnswersInDatabase(); // Обновление значений в базе данных
            }
        }

        // Метод для проверки ответов пользователя
        private void CheckAnswers()
        {
            var question = Questions[_currentQuestionIndex];

            // Получаем список правильных ответов на текущий вопрос
            var correctAnswers = question.Answers.Where(a => a.IsCorrect).ToList();
            // Получаем список выбранных пользователем правильных ответов
            var userSelectedCorrectAnswers = question.Answers.Where(sa => sa.IsSelected).ToList();

            // Проверяем, все ли правильные ответы были выбраны пользователем
            if (correctAnswers.Count == userSelectedCorrectAnswers.Count &&
                correctAnswers.All(correct => userSelectedCorrectAnswers.Any(selected => selected.Id == correct.Id)))
            {
                // Если все правильные ответы выбраны
                TotalScore += question.Points;
            }
            else
            {
                // Добавляем текущий вопрос в список неправильных ответов
                _incorrectQuestions.Add(question);
            }
        }

         // Метод для отображения результатов теста
        private void ShowTestResults()
        {
            string message = $"Тест завершен. Ваш результат: {TotalScore} очков.";

            if (_incorrectQuestions.Any())
            {
                message += "\n\nНеправильные ответы на вопросы:\n";
                foreach (var question in _incorrectQuestions)
                {
                    message += $"{question.Text}\n";
                }
            }

            message += "\n\nХотите попробовать ешё?\n";

            MessageBoxResult result = MessageBox.Show(message, "Результаты теста", MessageBoxButton.YesNo);

            _testsDB.UpdateAnswersInDatabase();

            if (result == MessageBoxResult.Yes)
            {
                _timer.Stop();
                // Пользователь нажал "Да", закрываем текущее окно QuestionWindow
                Close();

                // Создаем и открываем новое окно QuestionWindow
                QuestionWindow newQuestionWindow = new QuestionWindow(_testId, _userId);
                newQuestionWindow.Show();
            }
            else // Пользователь завершил тест, сохраняем результаты в базе данных
            {
                // Создаем объект TestResult
                TestResult testResult = new TestResult
                {
                    UserId = _userId,
                    TestId = _testId,
                    Score = TotalScore
                };

                // Добавляем объект TestResult в контекст базы данных и сохраняем изменения
                try
                {
                    _testsContext.TestResults.Add(testResult);
                    _testsContext.SaveChanges();
                    MessageBox.Show("Результаты теста успешно сохранены.");

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении результатов теста в базу данных: {ex.Message}");
                }
            }
        }

        // Метод для сохранения ответов пользователя в базу данных
        private void SaveUserAnswersToDatabase(List<UserAnswer> userAnswers)
        {
            try
            {
                _testsContext.UserAnswers.AddRange(userAnswers);
                _testsContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении результатов ответов пользователя: {ex.Message}");
            }
        }

        // Обработчик события ошибки загрузки изображения
        private void currentQuestionImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Изображение не удалось загрузить!");
        }

        // Метод для генерации события изменения свойств
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Метод, вызываемый при каждом тике таймера
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Уменьшаем время на одну секунду
            _timeLeft = _timeLeft.Subtract(TimeSpan.FromSeconds(1));

            // Обновляем отображаемое время
            UpdateTimerDisplay();

            // Проверяем, закончился ли отсчет времени
            if (_timeLeft <= TimeSpan.Zero)
            {
                _timer.Stop();
                MessageBox.Show("Время вышло!");
                ShowTestResults();
            }
        }

        // Метод для обновления отображаемого времени на экране
        private void UpdateTimerDisplay()
        {
            // Форматируем оставшееся время в формат "мм:сс"
            string timeString = $"{_timeLeft:mm\\:ss}";
            // Обновляем TextBlock с отображаемым временем
            timerTextBlock.Text = timeString;
        }

        // Обработчик закрытия окна
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_userId);
            mainWindow.Show();
            _timer.Stop();
        }
    }
}