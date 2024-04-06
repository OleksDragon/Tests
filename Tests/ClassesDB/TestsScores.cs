using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tests.Models;

namespace Tests.ClassesDB
{
    internal class TestsScores
    {
        private TestsContext context = new TestsContext();

        // Метод для получения общего количества баллов пользователя
        public string GetTotalScoreForUser(int userId)
        {
            // Получение суммы баллов из результатов тестов для указанного пользователя
            int? totalScore = context.TestResults
                                  .Where(tr => tr.UserId == userId)
                                  .Sum(tr => (int?)tr.Score);

            // Возвращение общего количества баллов
            return totalScore.HasValue ? totalScore.ToString() : "0";
        }

        // Метод для отображения максимального балла и окрашивания текста в соответствии с процентом прохождения теста
        public void DisplayMaxScoreAndColorize(string testName, TextBlock textBlock, int userId)
        {
            // Получение максимального балла пользователя в указанном тесте
            int? maxScore = GetMaxScoreForUserInTest(userId, testName);

            if (maxScore.HasValue)
            {
                textBlock.Text = maxScore.ToString();

                // Получение информации о тесте из базы данных
                var test = context.Tests.FirstOrDefault(t => t.Name == testName);

                if (test != null)
                {
                    // Получение количества вопросов в тесте
                    int questionsCount = test.Questions.Count;

                    // Расчет максимально возможного количества баллов
                    int maxScorePossible = questionsCount * test.Questions.FirstOrDefault()?.Points ?? 0;
                             
                    // Расчет процента прохождения теста
                    double percentage = (double)maxScore / maxScorePossible;

                    // Окрашивание текста в зависимости от процента прохождения
                    textBlock.Foreground = percentage >= 0.7 ? Brushes.Green : Brushes.Red;
                }
                else
                {
                    MessageBox.Show($"Тест \"{testName}\" не найден в базе данных.");
                }
            }
            else
            {
                textBlock.Text = "0";
            }
        }

        // Метод для получения максимального балла пользователя в указанном тесте
        public int? GetMaxScoreForUserInTest(int userId, string testName)
        {
            // Находим все результаты указанного теста для данного пользователя
            var testResults = context.TestResults
                .Where(tr => tr.UserId == userId && tr.Test.Name == testName)
                .ToList();

            // Если результатов нет, возвращаем null
            if (!testResults.Any())
                return null;

            // Находим максимальное количество баллов
            int maxScore = testResults.Max(tr => tr.Score);

            return maxScore;
        }

    }
}
