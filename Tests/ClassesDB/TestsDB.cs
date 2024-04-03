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
            Test historyTest = new Test { Name = "История" };
            Test literatureTest = new Test { Name = "Литература" };

            // Добавляем тесты в базу данных
            AddTest(geographyTest);
            AddTest(musicTest);
            AddTest(sportsTest);
            AddTest(historyTest);
            AddTest(literatureTest);

            // Создаем вопросы для каждого теста
            Question geographyQuestion1 = new Question { Text = "Столица Франции?", Points = 10, TestId = geographyTest.Id };
            Question geographyQuestion2 = new Question { Text = "Крупнейшее озеро в мире?", Points = 10, TestId = geographyTest.Id };
            Question geographyQuestion3 = new Question { Text = "Какая из перечисленных стран имеет самую большую площадь?", Points = 10, TestId = geographyTest.Id };
            Question geographyQuestion4 = new Question { Text = "В каком из перечисленных городов находится часовая башня Биг-Бен?", Points = 10, TestId = geographyTest.Id };
            Question geographyQuestion5 = new Question { Text = "Которое из перечисленных государств не имеет выхода к морю?", Points = 10, TestId = geographyTest.Id };
            Question geographyQuestion6 = new Question { Text = "В каких из перечисленных стран расположены Альпы?", Points = 10, TestId = geographyTest.Id };
            Question geographyQuestion7 = new Question { Text = "Какие из перечисленных стран имеют побережье на Черном море?", Points = 10, TestId = geographyTest.Id };
            Question geographyQuestion8 = new Question
            {
                Text = "Какая страна представлена на рисунке?",
                Points = 10,
                TestId = geographyTest.Id,
                ImagePath = "/Images/Questions images/bflag.png"
            };
            Question geographyQuestion9 = new Question
            {
                Text = "Какая страна представлена на рисунке?",
                Points = 10,
                TestId = geographyTest.Id,
                ImagePath = "/Images/Questions images/uflag.png"
            };


            Question musicQuestion1 = new Question { Text = "Кто написал симфонию 'Лунная соната'?", Points = 10, TestId = musicTest.Id };
            Question musicQuestion2 = new Question { Text = "Кто исполнял 'Bohemian Rhapsody'?", Points = 10, TestId = musicTest.Id };
            Question sportsQuestion1 = new Question { Text = "Какая команда выиграла Чемпионат мира по футболу в 2018 году?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion2 = new Question { Text = "Кто является рекордсменом по количеству золотых медалей на Олимпийских играх?", Points = 10, TestId = sportsTest.Id };

            // Добавляем вопросы в базу данных
            AddQuestion(geographyQuestion1);
            AddQuestion(geographyQuestion2);
            AddQuestion(geographyQuestion3);
            AddQuestion(geographyQuestion4);
            AddQuestion(geographyQuestion5);
            AddQuestion(geographyQuestion6);
            AddQuestion(geographyQuestion7);
            AddQuestion(geographyQuestion8);
            AddQuestion(geographyQuestion9);
            AddQuestion(musicQuestion1);
            AddQuestion(musicQuestion2);
            AddQuestion(sportsQuestion1);
            AddQuestion(sportsQuestion2);

            // Создаем ответы для каждого вопроса
            // Варианты ответов на вопросы по географии
            Answer geographyAnswer1_1 = new Answer { Text = "Париж", IsCorrect = true, QuestionId = geographyQuestion1.Id };
            Answer geographyAnswer1_2 = new Answer { Text = "Бордо", IsCorrect = false, QuestionId = geographyQuestion1.Id };
            Answer geographyAnswer1_3 = new Answer { Text = "Тулуза", IsCorrect = false, QuestionId = geographyQuestion1.Id };
            Answer geographyAnswer1_4 = new Answer { Text = "Марсель", IsCorrect = false, QuestionId = geographyQuestion1.Id };
            Answer geographyAnswer1_5 = new Answer { Text = "Лиль", IsCorrect = false, QuestionId = geographyQuestion1.Id };

            Answer geographyAnswer2_1 = new Answer { Text = "Каспийское море", IsCorrect = true, QuestionId = geographyQuestion2.Id };
            Answer geographyAnswer2_2 = new Answer { Text = "Байкал", IsCorrect = false, QuestionId = geographyQuestion2.Id };
            Answer geographyAnswer2_3 = new Answer { Text = "Онтарио", IsCorrect = false, QuestionId = geographyQuestion2.Id };
            Answer geographyAnswer2_4 = new Answer { Text = "Виктория", IsCorrect = false, QuestionId = geographyQuestion2.Id };
            Answer geographyAnswer2_5 = new Answer { Text = "Мичиган", IsCorrect = false, QuestionId = geographyQuestion2.Id };

            Answer geographyAnswer3_1 = new Answer { Text = "Индия", IsCorrect = false, QuestionId = geographyQuestion3.Id };
            Answer geographyAnswer3_2 = new Answer { Text = "Канада", IsCorrect = true, QuestionId = geographyQuestion3.Id };
            Answer geographyAnswer3_3 = new Answer { Text = "Китай", IsCorrect = false, QuestionId = geographyQuestion3.Id };
            Answer geographyAnswer3_4 = new Answer { Text = "США", IsCorrect = false, QuestionId = geographyQuestion3.Id };
            Answer geographyAnswer3_5 = new Answer { Text = "Бразилия", IsCorrect = false, QuestionId = geographyQuestion3.Id };

            Answer geographyAnswer4_1 = new Answer { Text = "Берлин", IsCorrect = false, QuestionId = geographyQuestion4.Id };
            Answer geographyAnswer4_2 = new Answer { Text = "Лондон", IsCorrect = true, QuestionId = geographyQuestion4.Id };
            Answer geographyAnswer4_3 = new Answer { Text = "Париж", IsCorrect = false, QuestionId = geographyQuestion4.Id };
            Answer geographyAnswer4_4 = new Answer { Text = "Брюсель", IsCorrect = false, QuestionId = geographyQuestion4.Id };
            Answer geographyAnswer4_5 = new Answer { Text = "Рим", IsCorrect = false, QuestionId = geographyQuestion4.Id };

            Answer geographyAnswer5_1 = new Answer { Text = "Бельгия", IsCorrect = false, QuestionId = geographyQuestion5.Id };
            Answer geographyAnswer5_2 = new Answer { Text = "Албания", IsCorrect = false, QuestionId = geographyQuestion5.Id };
            Answer geographyAnswer5_3 = new Answer { Text = "Германия", IsCorrect = false, QuestionId = geographyQuestion5.Id };
            Answer geographyAnswer5_4 = new Answer { Text = "Литва", IsCorrect = false, QuestionId = geographyQuestion5.Id };
            Answer geographyAnswer5_5 = new Answer { Text = "Швейцария", IsCorrect = true, QuestionId = geographyQuestion5.Id };

            Answer geographyAnswer6_1 = new Answer { Text = "Франция", IsCorrect = true, QuestionId = geographyQuestion6.Id };
            Answer geographyAnswer6_2 = new Answer { Text = "Италия", IsCorrect = true, QuestionId = geographyQuestion6.Id };
            Answer geographyAnswer6_3 = new Answer { Text = "Германия", IsCorrect = true, QuestionId = geographyQuestion6.Id };
            Answer geographyAnswer6_4 = new Answer { Text = "Польша", IsCorrect = false, QuestionId = geographyQuestion6.Id };
            Answer geographyAnswer6_5 = new Answer { Text = "Швейцария", IsCorrect = true, QuestionId = geographyQuestion6.Id };

            Answer geographyAnswer7_1 = new Answer { Text = "Румыния", IsCorrect = true, QuestionId = geographyQuestion7.Id };
            Answer geographyAnswer7_2 = new Answer { Text = "Италия", IsCorrect = false, QuestionId = geographyQuestion7.Id };
            Answer geographyAnswer7_3 = new Answer { Text = "Турция", IsCorrect = true, QuestionId = geographyQuestion7.Id };
            Answer geographyAnswer7_4 = new Answer { Text = "Греция", IsCorrect = false, QuestionId = geographyQuestion7.Id };
            Answer geographyAnswer7_5 = new Answer { Text = "Украина", IsCorrect = true, QuestionId = geographyQuestion7.Id };

            Answer geographyAnswer8_1 = new Answer { Text = "Эстония", IsCorrect = false, QuestionId = geographyQuestion8.Id };
            Answer geographyAnswer8_2 = new Answer { Text = "Албания", IsCorrect = false, QuestionId = geographyQuestion8.Id };
            Answer geographyAnswer8_3 = new Answer { Text = "Германия", IsCorrect = false, QuestionId = geographyQuestion8.Id };
            Answer geographyAnswer8_4 = new Answer { Text = "Литва", IsCorrect = false, QuestionId = geographyQuestion8.Id };
            Answer geographyAnswer8_5 = new Answer { Text = "Бельгия", IsCorrect = true, QuestionId = geographyQuestion8.Id };

            Answer geographyAnswer9_1 = new Answer { Text = "Румыния", IsCorrect = false, QuestionId = geographyQuestion9.Id };
            Answer geographyAnswer9_2 = new Answer { Text = "Италия", IsCorrect = false, QuestionId = geographyQuestion9.Id };
            Answer geographyAnswer9_3 = new Answer { Text = "Украина", IsCorrect = true, QuestionId = geographyQuestion9.Id };
            Answer geographyAnswer9_4 = new Answer { Text = "Греция", IsCorrect = false, QuestionId = geographyQuestion9.Id };
            Answer geographyAnswer9_5 = new Answer { Text = "Швеция", IsCorrect = false, QuestionId = geographyQuestion9.Id };


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
            AddAnswer(geographyAnswer1_4);
            AddAnswer(geographyAnswer1_5);

            AddAnswer(geographyAnswer2_1);
            AddAnswer(geographyAnswer2_2);
            AddAnswer(geographyAnswer2_3);
            AddAnswer(geographyAnswer2_4);
            AddAnswer(geographyAnswer2_5);

            AddAnswer(geographyAnswer3_1);
            AddAnswer(geographyAnswer3_2);
            AddAnswer(geographyAnswer3_3);
            AddAnswer(geographyAnswer3_4);
            AddAnswer(geographyAnswer3_5);

            AddAnswer(geographyAnswer4_1);
            AddAnswer(geographyAnswer4_2);
            AddAnswer(geographyAnswer4_3);
            AddAnswer(geographyAnswer4_4);
            AddAnswer(geographyAnswer4_5);

            AddAnswer(geographyAnswer5_1);
            AddAnswer(geographyAnswer5_2);
            AddAnswer(geographyAnswer5_3);
            AddAnswer(geographyAnswer5_4);
            AddAnswer(geographyAnswer5_5);

            AddAnswer(geographyAnswer6_1);
            AddAnswer(geographyAnswer6_2);
            AddAnswer(geographyAnswer6_3);
            AddAnswer(geographyAnswer6_4);
            AddAnswer(geographyAnswer6_5);

            AddAnswer(geographyAnswer7_1);
            AddAnswer(geographyAnswer7_2);
            AddAnswer(geographyAnswer7_3);
            AddAnswer(geographyAnswer7_4);
            AddAnswer(geographyAnswer7_5);

            AddAnswer(geographyAnswer8_1);
            AddAnswer(geographyAnswer8_2);
            AddAnswer(geographyAnswer8_3);
            AddAnswer(geographyAnswer8_4);
            AddAnswer(geographyAnswer8_5);

            AddAnswer(geographyAnswer9_1);
            AddAnswer(geographyAnswer9_2);
            AddAnswer(geographyAnswer9_3);
            AddAnswer(geographyAnswer9_4);
            AddAnswer(geographyAnswer9_5);

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

