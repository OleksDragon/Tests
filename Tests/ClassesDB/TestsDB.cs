using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.ClassesDB
{
    public class TestsDB
    {
        private TestsContext _context;
        private bool disposedValue;
        public TestsDB()
        {
            try
            {
                _context = new TestsContext();

                if (!_context.Database.Exists())
                {
                    // Создание базы данных, если она не существует
                    _context.Database.Create();
                }

                if (_context.Database.Exists())
                {
                    SeedData();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Добавление теста
        public void AddTest(Test test)
        {
            _context.Tests.Add(test);
            _context.SaveChanges();
        }

        // Добавление вопроса
        public void AddQuestion(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        // Добавление ответа
        public void AddAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        // Заполнения базы данных тестами, вопросами и ответами
        public void SeedData()
        {
            // Создаем тесты
            Test geographyTest = new Test { Name = "География" };
            Test musicTest = new Test { Name = "Музыка" };
            Test sportsTest = new Test { Name = "Спорт" };

            // Добавляем тесты в базу данных
            AddTest(geographyTest);
            AddTest(musicTest);
            AddTest(sportsTest);

            // Создаем вопросы для каждого теста
            Question geographyQuestion1 = new Question { Text = "Столица Франции?", Points = 10, TestId = geographyTest.Id };
            Question geographyQuestion2 = new Question { Text = "Крупнейшее озеро в мире?", Points = 10, TestId = geographyTest.Id };
            Question musicQuestion1 = new Question { Text = "Кто написал симфонию 'Лунная соната'?", Points = 10, TestId = musicTest.Id };
            Question musicQuestion2 = new Question { Text = "Кто исполнял 'Bohemian Rhapsody'?", Points = 10, TestId = musicTest.Id };
            Question sportsQuestion1 = new Question { Text = "Какая команда выиграла Чемпионат мира по футболу в 2018 году?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion2 = new Question { Text = "Кто является рекордсменом по количеству золотых медалей на Олимпийских играх?", Points = 10, TestId = sportsTest.Id };

            // Добавляем вопросы в базу данных
            AddQuestion(geographyQuestion1);
            AddQuestion(geographyQuestion2);
            AddQuestion(musicQuestion1);
            AddQuestion(musicQuestion2);
            AddQuestion(sportsQuestion1);
            AddQuestion(sportsQuestion2);

            // Создаем ответы для каждого вопроса
            // Варианты ответов на вопросы по географии
            Answer geographyAnswer1_1 = new Answer { Text = "Париж", IsCorrect = true, QuestionId = geographyQuestion1.Id };
            Answer geographyAnswer1_2 = new Answer { Text = "Лондон", IsCorrect = false, QuestionId = geographyQuestion1.Id };
            Answer geographyAnswer1_3 = new Answer { Text = "Берлин", IsCorrect = false, QuestionId = geographyQuestion1.Id };

            Answer geographyAnswer2_1 = new Answer { Text = "Каспийское море", IsCorrect = true, QuestionId = geographyQuestion2.Id };
            Answer geographyAnswer2_2 = new Answer { Text = "Байкал", IsCorrect = false, QuestionId = geographyQuestion2.Id };
            Answer geographyAnswer2_3 = new Answer { Text = "Онтарио", IsCorrect = false, QuestionId = geographyQuestion2.Id };

            // Варианты ответов на вопросы по музыке
            Answer musicAnswer1_1 = new Answer { Text = "Людвиг ван Бетховен", IsCorrect = true, QuestionId = musicQuestion1.Id };
            Answer musicAnswer1_2 = new Answer { Text = "Иоганн Себастьян Бах", IsCorrect = false, QuestionId = musicQuestion1.Id };
            Answer musicAnswer1_3 = new Answer { Text = "Вольфганг Амадей Моцарт", IsCorrect = false, QuestionId = musicQuestion1.Id };

            Answer musicAnswer2_1 = new Answer { Text = "Queen", IsCorrect = true, QuestionId = musicQuestion2.Id };
            Answer musicAnswer2_2 = new Answer { Text = "The Beatles", IsCorrect = false, QuestionId = musicQuestion2.Id };
            Answer musicAnswer2_3 = new Answer { Text = "Led Zeppelin", IsCorrect = false, QuestionId = musicQuestion2.Id };

            // Варианты ответов на вопросы по спорту
            Answer sportsAnswer1_1 = new Answer { Text = "Франция", IsCorrect = false, QuestionId = sportsQuestion1.Id };
            Answer sportsAnswer1_2 = new Answer { Text = "Аргентина", IsCorrect = false, QuestionId = sportsQuestion1.Id };
            Answer sportsAnswer1_3 = new Answer { Text = "Бразилия", IsCorrect = true, QuestionId = sportsQuestion1.Id };

            Answer sportsAnswer2_1 = new Answer { Text = "Майкл Фелпс", IsCorrect = true, QuestionId = sportsQuestion2.Id };
            Answer sportsAnswer2_2 = new Answer { Text = "Усэйн Болт", IsCorrect = false, QuestionId = sportsQuestion2.Id };
            Answer sportsAnswer2_3 = new Answer { Text = "Серена Уильямс", IsCorrect = false, QuestionId = sportsQuestion2.Id };

            // Добавляем ответы в базу данных
            AddAnswer(geographyAnswer1_1);
            AddAnswer(geographyAnswer1_2);
            AddAnswer(geographyAnswer1_3);
            AddAnswer(geographyAnswer2_1);
            AddAnswer(geographyAnswer2_2);
            AddAnswer(geographyAnswer2_3);

            // Добавляем ответы в базу данных
            AddAnswer(musicAnswer1_1);
            AddAnswer(musicAnswer1_2);
            AddAnswer(musicAnswer1_3);
            AddAnswer(musicAnswer2_1);
            AddAnswer(musicAnswer2_2);
            AddAnswer(musicAnswer2_3);

            // Добавляем ответы в базу данных
            AddAnswer(sportsAnswer1_1);
            AddAnswer(sportsAnswer1_2);
            AddAnswer(sportsAnswer1_3);
            AddAnswer(sportsAnswer2_1);
            AddAnswer(sportsAnswer2_2);
            AddAnswer(sportsAnswer2_3);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

