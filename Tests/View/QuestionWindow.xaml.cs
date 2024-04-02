using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Tests.ClassesDB;
using Tests.Models;

namespace Tests.View
{
    /// <summary>
    /// Логика взаимодействия для QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        private TestsContext _testsContext;
        private int _currentQuestionIndex = 0;
        private List<Question> _originalQuestions; // Для хранения исходного порядка вопросов

        // Свойство для списка вопросов
        public ObservableCollection<Question> Questions { get; private set; }

        // Свойство для списка перемешанных ответов текущего вопроса
        public ObservableCollection<Answer> ShuffledCurrentQuestionAnswers { get; set; }

        // Свойство для ID текущего теста
        public int TestId { get; set; }

        // Свойство для текста текущего вопроса
        public string CurrentQuestionText
        {
            get { return Questions.ElementAtOrDefault(_currentQuestionIndex)?.Text; }
        }

        // Свойство для получения общего количества вопросов
        public int TotalQuestionsCount
        {
            get { return Questions.Count; }
        }

        // Свойство для номера текущего вопроса
        public int CurrentQuestionNumber
        {
            get { return _currentQuestionIndex + 1; }
        }

        public QuestionWindow(int testId)
        {
            InitializeComponent();
            _testsContext = new TestsContext();

            // Получаем вопросы с указанным TestId
            _originalQuestions = _testsContext.Questions.Where(q => q.TestId == testId).ToList();
            ShuffleQuestionsAndAnswers(); // Перемешиваем вопросы и ответы

            // Инициализируем ObservableCollection для вопросов
            Questions = new ObservableCollection<Question>(_originalQuestions);

            // Инициализируем ObservableCollection для перемешанных ответов текущего вопроса
            ShuffledCurrentQuestionAnswers = new ObservableCollection<Answer>();

            // Первоначальное обновление текущего вопроса и списка ответов
            UpdateCurrentQuestion();

            // Устанавливаем контекст данных окна на само окно
            DataContext = this;
        }

        // Метод для обновления текущего вопроса и списка ответов
        private void UpdateCurrentQuestion()
        {
            if (_currentQuestionIndex >= 0 && _currentQuestionIndex < Questions.Count)
            {
                // Получаем текст текущего вопроса и номер текущего вопроса
                tblQuestion.Text = Questions[_currentQuestionIndex].Text;
                currentQuestion.Text = CurrentQuestionNumber.ToString();

                // Получаем Id текущего вопроса
                int questionId = Questions[_currentQuestionIndex].Id;

                // Запрос к базе данных для получения ответов по QuestionId
                var answers = _testsContext.Answers
                    .Where(a => a.QuestionId == questionId)
                    .ToList();

                // Перемешиваем ответы текущего вопроса
                ShuffleAnswers(answers);

                // Инициализируем ObservableCollection для перемешанных ответов текущего вопроса
                ShuffledCurrentQuestionAnswers = new ObservableCollection<Answer>(answers);

                // Обновляем DataContext, чтобы отразить изменения в XAML
                DataContext = null;
                DataContext = this;
            }
        }

        // Метод для перемешивания ответов внутри вопроса
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

                // Перемешиваем ответы внутри текущего вопроса
                ShuffleAnswers(value.Answers.ToList());
            }
        }

        // Обработчик нажатия кнопки "Следующий вопрос"
        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (_currentQuestionIndex < Questions.Count - 1)
                _currentQuestionIndex++;
            UpdateCurrentQuestion();
        }

        // Обработчик нажатия кнопки "Предыдущий вопрос"
        private void PreviousQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (_currentQuestionIndex > 0)
                _currentQuestionIndex--;
            UpdateCurrentQuestion();
        }
    }
}
