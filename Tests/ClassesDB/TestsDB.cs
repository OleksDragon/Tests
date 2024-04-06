using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            Test animalTest = new Test { Name = "Животные" };
            Test historyTest = new Test { Name = "История" };

            // Добавляем тесты в базу данных
            AddTest(geographyTest);
            AddTest(musicTest);
            AddTest(sportsTest);
            AddTest(animalTest);
            AddTest(historyTest);
            

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
            Question geographyQuestion10 = new Question { Text = "Какие из перечисленных городов являются столицами европейских стран?", Points = 10, TestId = geographyTest.Id };


            Question musicQuestion1 = new Question { Text = "Кто написал симфонию 'Лунная соната'?", Points = 10, TestId = musicTest.Id };
            Question musicQuestion2 = new Question { Text = "Кто исполнял 'Bohemian Rhapsody'?", Points = 10, TestId = musicTest.Id };

            Question sportsQuestion1 = new Question { Text = "В каком виде спорта выигравшая команда может быть награждена Кубком Стэнли?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion2 = new Question { Text = "Кто является рекордсменом по количеству золотых медалей на Олимпийских играх?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion3 = new Question { Text = "Какие из перечисленных видов спорта включаются в зимние Олимпийские игры?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion4 = new Question { Text = "Сколько игроков составляют команду в волейболе?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion5 = new Question { Text = "Какой вид спорта является национальным спортом Японии?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion6 = new Question { Text = "Какая из перечисленных дисциплин не входит в соревнования летних Олимпийских игр?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion7 = new Question { Text = "В какой из перечисленных дисциплин спортивная арена имеет форму кольца?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion8 = new Question { Text = "Какие из перечисленных видов спорта относятся к водным?", Points = 10, TestId = sportsTest.Id };            
            Question sportsQuestion9 = new Question
            {
                Text = "Какой вид спорта представлен на рисунке?",
                Points = 10,
                TestId = sportsTest.Id,
                ImagePath = "/Images/Questions images/Rowing.jpg"
            };
            Question sportsQuestion10 = new Question
            {
                Text = "Какой вид спорта представлен на рисунке?",
                Points = 10,
                TestId = sportsTest.Id,
                ImagePath = "/Images/Questions images/Fencing.jpg"
            };
            Question sportsQuestion11 = new Question
            {
                Text = "Какой вид спорта представлен на рисунке?",
                Points = 10,
                TestId = sportsTest.Id,
                ImagePath = "/Images/Questions images/Bobsled.jpg"
            };
            Question sportsQuestion12 = new Question
            {
                Text = "Какой вид спорта представлен на рисунке?",
                Points = 10,
                TestId = sportsTest.Id,
                ImagePath = "/Images/Questions images/Golf.jpg"
            };
            Question sportsQuestion13 = new Question { Text = "Какие из перечисленных видов спорта относятся к альтернативным или экстремальным видам?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion14 = new Question { Text = "Какие из перечисленных видов спорта являются олимпийскими дисциплинами в плавании?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion15 = new Question { Text = "Какие из перечисленных видов спорта включаются в состав олимпийских соревнований по гимнастике?", Points = 10, TestId = sportsTest.Id };


            Question animalsQuestion1 = new Question { Text = "Какие из перечисленных животных являются хищниками?", Points = 10, TestId = animalTest.Id };

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
            AddQuestion(geographyQuestion10);

            AddQuestion(musicQuestion1);
            AddQuestion(musicQuestion2);

            AddQuestion(sportsQuestion1);
            AddQuestion(sportsQuestion2);
            AddQuestion(sportsQuestion3);
            AddQuestion(sportsQuestion4);
            AddQuestion(sportsQuestion5);
            AddQuestion(sportsQuestion6);
            AddQuestion(sportsQuestion7);
            AddQuestion(sportsQuestion8);
            AddQuestion(sportsQuestion9);
            AddQuestion(sportsQuestion10);
            AddQuestion(sportsQuestion11);
            AddQuestion(sportsQuestion12);
            AddQuestion(sportsQuestion13);
            AddQuestion(sportsQuestion14);
            AddQuestion(sportsQuestion15);

            AddQuestion(animalsQuestion1);

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

            Answer geographyAnswer10_1 = new Answer { Text = "Мадрид", IsCorrect = true, QuestionId = geographyQuestion10.Id };
            Answer geographyAnswer10_2 = new Answer { Text = "Краков", IsCorrect = false, QuestionId = geographyQuestion10.Id };
            Answer geographyAnswer10_3 = new Answer { Text = "Вена", IsCorrect = true, QuestionId = geographyQuestion10.Id };
            Answer geographyAnswer10_4 = new Answer { Text = "Ганновер", IsCorrect = false, QuestionId = geographyQuestion10.Id };
            Answer geographyAnswer10_5 = new Answer { Text = "Стокгольм", IsCorrect = true, QuestionId = geographyQuestion10.Id };


            // Варианты ответов на вопросы по музыке
            Answer musicAnswer1_1 = new Answer { Text = "Людвиг ван Бетховен", IsCorrect = true, QuestionId = musicQuestion1.Id };
            Answer musicAnswer1_2 = new Answer { Text = "Иоганн Себастьян Бах", IsCorrect = false, QuestionId = musicQuestion1.Id };
            Answer musicAnswer1_3 = new Answer { Text = "Вольфганг Амадей Моцарт", IsCorrect = false, QuestionId = musicQuestion1.Id };
            Answer musicAnswer1_4 = new Answer { Text = "Франц Шуберт", IsCorrect = false, QuestionId = musicQuestion1.Id };

            Answer musicAnswer2_1 = new Answer { Text = "Queen", IsCorrect = true, QuestionId = musicQuestion2.Id };
            Answer musicAnswer2_2 = new Answer { Text = "The Beatles", IsCorrect = false, QuestionId = musicQuestion2.Id };
            Answer musicAnswer2_3 = new Answer { Text = "Led Zeppelin", IsCorrect = false, QuestionId = musicQuestion2.Id };
            Answer musicAnswer2_4 = new Answer { Text = "The Rolling Stones", IsCorrect = false, QuestionId = musicQuestion2.Id };

            // Варианты ответов на вопросы по спорту
            Answer sportsAnswer1_1 = new Answer { Text = "Футбол", IsCorrect = false, QuestionId = sportsQuestion1.Id };
            Answer sportsAnswer1_2 = new Answer { Text = "Баскетбол", IsCorrect = false, QuestionId = sportsQuestion1.Id };
            Answer sportsAnswer1_3 = new Answer { Text = "Хоккей", IsCorrect = true, QuestionId = sportsQuestion1.Id };
            Answer sportsAnswer1_4 = new Answer { Text = "Теннис", IsCorrect = false, QuestionId = sportsQuestion1.Id };
            Answer sportsAnswer1_5 = new Answer { Text = "Формула 1", IsCorrect = false, QuestionId = sportsQuestion1.Id };

            Answer sportsAnswer2_1 = new Answer { Text = "Майкл Фелпс", IsCorrect = true, QuestionId = sportsQuestion2.Id };
            Answer sportsAnswer2_2 = new Answer { Text = "Усэйн Болт", IsCorrect = false, QuestionId = sportsQuestion2.Id };
            Answer sportsAnswer2_3 = new Answer { Text = "Серена Уильямс", IsCorrect = false, QuestionId = sportsQuestion2.Id };
            Answer sportsAnswer2_4 = new Answer { Text = "Уле-Эйнар Бьёрндален", IsCorrect = false, QuestionId = sportsQuestion2.Id };
            Answer sportsAnswer2_5 = new Answer { Text = "Криштиану Роналду", IsCorrect = false, QuestionId = sportsQuestion2.Id };

            Answer sportsAnswer3_1 = new Answer { Text = "Футбол", IsCorrect = false, QuestionId = sportsQuestion3.Id };
            Answer sportsAnswer3_2 = new Answer { Text = "Фигурное катание", IsCorrect = true, QuestionId = sportsQuestion3.Id };
            Answer sportsAnswer3_3 = new Answer { Text = "Биатлон", IsCorrect = true, QuestionId = sportsQuestion3.Id };
            Answer sportsAnswer3_4 = new Answer { Text = "Плавание", IsCorrect = false, QuestionId = sportsQuestion3.Id };
            Answer sportsAnswer3_5 = new Answer { Text = "Сноуборд", IsCorrect = true, QuestionId = sportsQuestion3.Id };

            Answer sportsAnswer4_1 = new Answer { Text = "7", IsCorrect = false, QuestionId = sportsQuestion4.Id };
            Answer sportsAnswer4_2 = new Answer { Text = "8", IsCorrect = false, QuestionId = sportsQuestion4.Id };
            Answer sportsAnswer4_3 = new Answer { Text = "6", IsCorrect = true, QuestionId = sportsQuestion4.Id };
            Answer sportsAnswer4_4 = new Answer { Text = "5", IsCorrect = false, QuestionId = sportsQuestion4.Id };

            Answer sportsAnswer5_1 = new Answer { Text = "Каратэ", IsCorrect = false, QuestionId = sportsQuestion5.Id };
            Answer sportsAnswer5_2 = new Answer { Text = "Кёрлинг", IsCorrect = false, QuestionId = sportsQuestion5.Id };
            Answer sportsAnswer5_3 = new Answer { Text = "Сумо", IsCorrect = true, QuestionId = sportsQuestion5.Id };
            Answer sportsAnswer5_4 = new Answer { Text = "Регби", IsCorrect = false, QuestionId = sportsQuestion5.Id };
            Answer sportsAnswer5_5 = new Answer { Text = "Бадминтон", IsCorrect = false, QuestionId = sportsQuestion5.Id };

            Answer sportsAnswer6_1 = new Answer { Text = "Плавание", IsCorrect = false, QuestionId = sportsQuestion6.Id };
            Answer sportsAnswer6_2 = new Answer { Text = "Прыжки в воду", IsCorrect = false, QuestionId = sportsQuestion6.Id };
            Answer sportsAnswer6_3 = new Answer { Text = "Каратэ", IsCorrect = true, QuestionId = sportsQuestion6.Id };
            Answer sportsAnswer6_4 = new Answer { Text = "Гребля", IsCorrect = false, QuestionId = sportsQuestion6.Id };
            Answer sportsAnswer6_5 = new Answer { Text = "Фехтование", IsCorrect = false, QuestionId = sportsQuestion6.Id };

            Answer sportsAnswer7_1 = new Answer { Text = "Хоккей", IsCorrect = false, QuestionId = sportsQuestion7.Id };
            Answer sportsAnswer7_2 = new Answer { Text = "Бокс", IsCorrect = false, QuestionId = sportsQuestion7.Id };
            Answer sportsAnswer7_3 = new Answer { Text = "Борьба", IsCorrect = true, QuestionId = sportsQuestion7.Id };
            Answer sportsAnswer7_4 = new Answer { Text = "Баскетбол", IsCorrect = false, QuestionId = sportsQuestion7.Id };

            Answer sportsAnswer8_1 = new Answer { Text = "Гребля", IsCorrect = true, QuestionId = sportsQuestion8.Id };
            Answer sportsAnswer8_2 = new Answer { Text = "Фигурное катание", IsCorrect = false, QuestionId = sportsQuestion8.Id };
            Answer sportsAnswer8_3 = new Answer { Text = "Биатлон", IsCorrect = false, QuestionId = sportsQuestion8.Id };
            Answer sportsAnswer8_4 = new Answer { Text = "Плавание", IsCorrect = true, QuestionId = sportsQuestion8.Id };
            Answer sportsAnswer8_5 = new Answer { Text = "Вейкборд", IsCorrect = true, QuestionId = sportsQuestion8.Id };

            Answer sportsAnswer9_1 = new Answer { Text = "Гребля на байдарках и каноэ", IsCorrect = false, QuestionId = sportsQuestion9.Id };
            Answer sportsAnswer9_2 = new Answer { Text = "Серфинг", IsCorrect = false, QuestionId = sportsQuestion9.Id };
            Answer sportsAnswer9_3 = new Answer { Text = "Яхтинг", IsCorrect = false, QuestionId = sportsQuestion9.Id };
            Answer sportsAnswer9_4 = new Answer { Text = "Плавание", IsCorrect = false, QuestionId = sportsQuestion9.Id };
            Answer sportsAnswer9_5 = new Answer { Text = "Академическа гребля", IsCorrect = true, QuestionId = sportsQuestion9.Id };

            Answer sportsAnswer10_1 = new Answer { Text = "Стрельба из лука", IsCorrect = false, QuestionId = sportsQuestion10.Id };
            Answer sportsAnswer10_2 = new Answer { Text = "Бокс", IsCorrect = false, QuestionId = sportsQuestion10.Id };
            Answer sportsAnswer10_3 = new Answer { Text = "Каратэ", IsCorrect = false, QuestionId = sportsQuestion10.Id };
            Answer sportsAnswer10_4 = new Answer { Text = "Борьба", IsCorrect = false, QuestionId = sportsQuestion10.Id };
            Answer sportsAnswer10_5 = new Answer { Text = "Фехтование", IsCorrect = true, QuestionId = sportsQuestion10.Id };

            Answer sportsAnswer11_1 = new Answer { Text = "Прыжки с траплина", IsCorrect = false, QuestionId = sportsQuestion11.Id };
            Answer sportsAnswer11_2 = new Answer { Text = "Санный спорт", IsCorrect = false, QuestionId = sportsQuestion11.Id };
            Answer sportsAnswer11_3 = new Answer { Text = "Биатлон", IsCorrect = false, QuestionId = sportsQuestion11.Id };
            Answer sportsAnswer11_4 = new Answer { Text = "Бобслей", IsCorrect = true, QuestionId = sportsQuestion11.Id };
            Answer sportsAnswer11_5 = new Answer { Text = "Сноуборд", IsCorrect = false, QuestionId = sportsQuestion11.Id };

            Answer sportsAnswer12_1 = new Answer { Text = "Хоккей на траве", IsCorrect = false, QuestionId = sportsQuestion12.Id };
            Answer sportsAnswer12_2 = new Answer { Text = "Теннис", IsCorrect = false, QuestionId = sportsQuestion12.Id };
            Answer sportsAnswer12_3 = new Answer { Text = "Бейсбол", IsCorrect = false, QuestionId = sportsQuestion12.Id };
            Answer sportsAnswer12_4 = new Answer { Text = "Гольф", IsCorrect = true, QuestionId = sportsQuestion12.Id };
            Answer sportsAnswer12_5 = new Answer { Text = "Крокет", IsCorrect = false, QuestionId = sportsQuestion12.Id };

            Answer sportsAnswer13_1 = new Answer { Text = "Хоккей", IsCorrect = false, QuestionId = sportsQuestion13.Id };
            Answer sportsAnswer13_2 = new Answer { Text = "Бокс", IsCorrect = false, QuestionId = sportsQuestion13.Id };
            Answer sportsAnswer13_3 = new Answer { Text = "Гольф", IsCorrect = false, QuestionId = sportsQuestion13.Id };
            Answer sportsAnswer13_4 = new Answer { Text = "Серфинг", IsCorrect = true, QuestionId = sportsQuestion13.Id };
            Answer sportsAnswer13_5 = new Answer { Text = "Футбол", IsCorrect = false, QuestionId = sportsQuestion13.Id };

            Answer sportsAnswer14_1 = new Answer { Text = "Кроль", IsCorrect = true, QuestionId = sportsQuestion14.Id };
            Answer sportsAnswer14_2 = new Answer { Text = "Брасс", IsCorrect = true, QuestionId = sportsQuestion14.Id };
            Answer sportsAnswer14_3 = new Answer { Text = "Прыжки в воду", IsCorrect = false, QuestionId = sportsQuestion14.Id };
            Answer sportsAnswer14_4 = new Answer { Text = "Баттерфляй", IsCorrect = true, QuestionId = sportsQuestion14.Id };
            Answer sportsAnswer14_5 = new Answer { Text = "Синхронное плавание", IsCorrect = false, QuestionId = sportsQuestion14.Id };

            Answer sportsAnswer15_1 = new Answer { Text = "Художественная гимнастика", IsCorrect = true, QuestionId = sportsQuestion15.Id };
            Answer sportsAnswer15_2 = new Answer { Text = "Аэробика спортивная", IsCorrect = false, QuestionId = sportsQuestion15.Id };
            Answer sportsAnswer15_3 = new Answer { Text = "Прыжки на акробатической дорожке", IsCorrect = false, QuestionId = sportsQuestion15.Id };
            Answer sportsAnswer15_4 = new Answer { Text = "Прыжки на батуте", IsCorrect = true, QuestionId = sportsQuestion15.Id };
            Answer sportsAnswer15_5 = new Answer { Text = "Спортивная гимнастика", IsCorrect = true, QuestionId = sportsQuestion15.Id };

            Answer animalsAnswer1_1 = new Answer { Text = "Гепард", IsCorrect = true, QuestionId = animalsQuestion1.Id };
            Answer animalsAnswer1_2 = new Answer { Text = "Слон", IsCorrect = false, QuestionId = animalsQuestion1.Id };
            Answer animalsAnswer1_3 = new Answer { Text = "Лев", IsCorrect = true, QuestionId = animalsQuestion1.Id };
            Answer animalsAnswer1_4 = new Answer { Text = "Кенгуру", IsCorrect = false, QuestionId = animalsQuestion1.Id };
            Answer animalsAnswer1_5 = new Answer { Text = " Гиппопотам", IsCorrect = false, QuestionId = animalsQuestion1.Id };

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

            AddAnswer(geographyAnswer10_1);
            AddAnswer(geographyAnswer10_2);
            AddAnswer(geographyAnswer10_3);
            AddAnswer(geographyAnswer10_4);
            AddAnswer(geographyAnswer10_5);

            // Добавляем ответы в базу данных
            AddAnswer(musicAnswer1_1);
            AddAnswer(musicAnswer1_2);
            AddAnswer(musicAnswer1_3);
            AddAnswer(musicAnswer1_4);

            AddAnswer(musicAnswer2_1);
            AddAnswer(musicAnswer2_2);
            AddAnswer(musicAnswer2_3);
            AddAnswer(musicAnswer2_4);

            // Добавляем ответы в базу данных
            AddAnswer(sportsAnswer1_1);
            AddAnswer(sportsAnswer1_2);
            AddAnswer(sportsAnswer1_3);
            AddAnswer(sportsAnswer1_4);
            AddAnswer(sportsAnswer1_5);

            AddAnswer(sportsAnswer2_1);
            AddAnswer(sportsAnswer2_2);
            AddAnswer(sportsAnswer2_3);
            AddAnswer(sportsAnswer2_4);
            AddAnswer(sportsAnswer2_5);

            AddAnswer(sportsAnswer3_1);
            AddAnswer(sportsAnswer3_2);
            AddAnswer(sportsAnswer3_3);
            AddAnswer(sportsAnswer3_4);
            AddAnswer(sportsAnswer3_5);

            AddAnswer(sportsAnswer4_1);
            AddAnswer(sportsAnswer4_2);
            AddAnswer(sportsAnswer4_3);
            AddAnswer(sportsAnswer4_4);

            AddAnswer(sportsAnswer5_1);
            AddAnswer(sportsAnswer5_2);
            AddAnswer(sportsAnswer5_3);
            AddAnswer(sportsAnswer5_4);
            AddAnswer(sportsAnswer5_5);

            AddAnswer(sportsAnswer6_1);
            AddAnswer(sportsAnswer6_2);
            AddAnswer(sportsAnswer6_3);
            AddAnswer(sportsAnswer6_4);
            AddAnswer(sportsAnswer6_5);

            AddAnswer(sportsAnswer7_1);
            AddAnswer(sportsAnswer7_2);
            AddAnswer(sportsAnswer7_3);
            AddAnswer(sportsAnswer7_4);

            AddAnswer(sportsAnswer8_1);
            AddAnswer(sportsAnswer8_2);
            AddAnswer(sportsAnswer8_3);
            AddAnswer(sportsAnswer8_4);
            AddAnswer(sportsAnswer8_5);

            AddAnswer(sportsAnswer9_1);
            AddAnswer(sportsAnswer9_2);
            AddAnswer(sportsAnswer9_3);
            AddAnswer(sportsAnswer9_4);
            AddAnswer(sportsAnswer9_5);

            AddAnswer(sportsAnswer10_1);
            AddAnswer(sportsAnswer10_2);
            AddAnswer(sportsAnswer10_3);
            AddAnswer(sportsAnswer10_4);
            AddAnswer(sportsAnswer10_5);

            AddAnswer(sportsAnswer11_1);
            AddAnswer(sportsAnswer11_2);
            AddAnswer(sportsAnswer11_3);
            AddAnswer(sportsAnswer11_4);
            AddAnswer(sportsAnswer11_5);

            AddAnswer(sportsAnswer12_1);
            AddAnswer(sportsAnswer12_2);
            AddAnswer(sportsAnswer12_3);
            AddAnswer(sportsAnswer12_4);
            AddAnswer(sportsAnswer12_5);

            AddAnswer(sportsAnswer13_1);
            AddAnswer(sportsAnswer13_2);
            AddAnswer(sportsAnswer13_3);
            AddAnswer(sportsAnswer13_4);
            AddAnswer(sportsAnswer13_5);

            AddAnswer(sportsAnswer14_1);
            AddAnswer(sportsAnswer14_2);
            AddAnswer(sportsAnswer14_3);
            AddAnswer(sportsAnswer14_4);
            AddAnswer(sportsAnswer14_5);

            AddAnswer(sportsAnswer15_1);
            AddAnswer(sportsAnswer15_2);
            AddAnswer(sportsAnswer15_3);
            AddAnswer(sportsAnswer15_4);
            AddAnswer(sportsAnswer15_5);

            // Добавляем ответы в базу данных
            AddAnswer(animalsAnswer1_1);
            AddAnswer(animalsAnswer1_2);
            AddAnswer(animalsAnswer1_3);
            AddAnswer(animalsAnswer1_4);
            AddAnswer(animalsAnswer1_5);
        }

        public void UpdateAnswersInDatabase()
        {
            try
            {
                var answers = _context.Answers.ToList();

                foreach (var answer in answers)
                {
                    answer.IsSelected = false;
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении записей в базе данных: {ex.Message}");
            }
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

