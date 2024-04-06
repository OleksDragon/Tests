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
            Question geographyQuestion6 = new Question { Text = "В каких из перечисленных стран расположены Альпы? (Выберите все правильные варианты)", Points = 10, TestId = geographyTest.Id };
            Question geographyQuestion7 = new Question { Text = "Какие из перечисленных стран имеют побережье на Черном море? (Выберите все правильные варианты)", Points = 10, TestId = geographyTest.Id };
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
            Question geographyQuestion10 = new Question { Text = "Какие из перечисленных городов являются столицами европейских стран? (Выберите все правильные варианты)", Points = 10, TestId = geographyTest.Id };


            Question musicQuestion1 = new Question { Text = "Кто написал симфонию 'Лунная соната'?", Points = 10, TestId = musicTest.Id };
            Question musicQuestion2 = new Question { Text = "Кто исполнял 'Bohemian Rhapsody'?", Points = 10, TestId = musicTest.Id };
            Question musicQuestion3 = new Question { Text = "Какое музыкальное событие является крупнейшим музыкальным конкурсом в мире и ежегодно собирает участников со всей Европы?", Points = 10, TestId = musicTest.Id };
            Question musicQuestion4 = new Question { Text = "Какой из перечисленных украинских певцов выиграл конкурс \"Евровидение\" в 2016 году, представив страну с песней \"1944\"?", Points = 10, TestId = musicTest.Id };
            Question musicQuestion5 = new Question { Text = "Какой из украинских певцов получил премию \"Грэмми\" за лучший новый альбом в 2020 году?", Points = 10, TestId = musicTest.Id };
            Question musicQuestion6 = new Question { Text = "Какие украинские исполнители выигрывали конкурс \"Евровидение\"? (Выберите все правильные варианты)", Points = 10, TestId = musicTest.Id };
            Question musicQuestion7 = new Question
            {
                Text = "Как называется музыкальный инструмент, представленный на рисунке?",
                Points = 10,
                TestId = musicTest.Id,
                ImagePath = "/Images/Questions images/music1.jpg"
            };
            Question musicQuestion8 = new Question
            {
                Text = "Как называется музыкальный инструмент, представленный на рисунке?",
                Points = 10,
                TestId = musicTest.Id,
                ImagePath = "/Images/Questions images/music2.jpg"
            };
            Question musicQuestion9 = new Question
            {
                Text = "Как называется музыкальная группа, представленная на рисунке?",
                Points = 10,
                TestId = musicTest.Id,
                ImagePath = "/Images/Questions images/music3.jpg"
            };
            Question musicQuestion10 = new Question
            {
                Text = "Как зовут певицу, представленную на рисунке?",
                Points = 10,
                TestId = musicTest.Id,
                ImagePath = "/Images/Questions images/music4.jpg"
            };


            Question sportsQuestion1 = new Question { Text = "В каком виде спорта выигравшая команда может быть награждена Кубком Стэнли?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion2 = new Question { Text = "Кто является рекордсменом по количеству золотых медалей на Олимпийских играх?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion3 = new Question { Text = "Какие из перечисленных видов спорта включаются в зимние Олимпийские игры? (Выберите все правильные варианты)", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion4 = new Question { Text = "Сколько игроков составляют команду в волейболе?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion5 = new Question { Text = "Какой вид спорта является национальным спортом Японии?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion6 = new Question { Text = "Какая из перечисленных дисциплин не входит в соревнования летних Олимпийских игр?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion7 = new Question { Text = "В какой из перечисленных дисциплин спортивная арена имеет форму кольца?", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion8 = new Question { Text = "Какие из перечисленных видов спорта относятся к водным? (Выберите все правильные варианты)", Points = 10, TestId = sportsTest.Id };            
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
            Question sportsQuestion14 = new Question { Text = "Какие из перечисленных видов спорта являются олимпийскими дисциплинами в плавании? (Выберите все правильные варианты)", Points = 10, TestId = sportsTest.Id };
            Question sportsQuestion15 = new Question { Text = "Какие из перечисленных видов спорта включаются в состав олимпийских соревнований по гимнастике? (Выберите все правильные варианты)", Points = 10, TestId = sportsTest.Id };


            Question animalsQuestion1 = new Question { Text = "Какие из перечисленных животных являются хищниками? (Выберите все правильные варианты)", Points = 10, TestId = animalTest.Id };
            Question animalsQuestion2 = new Question { Text = "Какие из перечисленных животных являются травоядными млекопитающими? (Выберите все правильные варианты)", Points = 10, TestId = animalTest.Id };
            Question animalsQuestion3 = new Question { Text = "Какие из перечисленных животных обитают в Арктике?", Points = 10, TestId = animalTest.Id };
            Question animalsQuestion4 = new Question { Text = "Какие из перечисленных животных могут менять окраску своей кожи?", Points = 10, TestId = animalTest.Id };
            Question animalsQuestion5 = new Question { Text = "Какие из перечисленных животных являются хищными птицами?", Points = 10, TestId = animalTest.Id };
            Question animalsQuestion6 = new Question { Text = "Какие из перечисленных животных являются носителями яда? (Выберите все правильные варианты)", Points = 10, TestId = animalTest.Id };
            Question animalsQuestion7 = new Question
            {
                Text = "Какое животное представлено на рисунке?",
                Points = 10,
                TestId = animalTest.Id,
                ImagePath = "/Images/Questions images/zebra.jpg"
            };
            Question animalsQuestion8 = new Question
            {
                Text = "Какое животное представлено на рисунке?",
                Points = 10,
                TestId = animalTest.Id,
                ImagePath = "/Images/Questions images/Hedgehog.jpg"
            };
            Question animalsQuestion9 = new Question
            {
                Text = "Какое животное представлено на рисунке?",
                Points = 10,
                TestId = animalTest.Id,
                ImagePath = "/Images/Questions images/Shark.jpg"
            };
            Question animalsQuestion10 = new Question
            {
                Text = "Какое животное представлено на рисунке?",
                Points = 10,
                TestId = animalTest.Id,
                ImagePath = "/Images/Questions images/Platypus.jpg"
            };

            Question historyQuestion1 = new Question { Text = "Кто стал первым президентом США?", Points = 10, TestId = historyTest.Id };
            Question historyQuestion2 = new Question { Text = "Когда началась Вторая Мировая война?", Points = 10, TestId = historyTest.Id };
            Question historyQuestion3 = new Question { Text = "Когда Украина обрела независимость после распада Советского Союза?", Points = 10, TestId = historyTest.Id };
            Question historyQuestion4 = new Question { Text = "Какой год считается началом Великой Французской революции?", Points = 10, TestId = historyTest.Id };
            Question historyQuestion5 = new Question { Text = "Какие из перечисленных стран являлись колониальными державами в Африке в XIX веке? (Выберите все правильные варианты)", Points = 10, TestId = historyTest.Id };
            Question historyQuestion6 = new Question { Text = "Какие страны были членами основателями Организации Объединенных Наций? (Выберите все правильные варианты)", Points = 10, TestId = historyTest.Id };
            Question historyQuestion7 = new Question { Text = "Какие страны воевали в Столетней войне? (Выберите все правильные варианты)", Points = 10, TestId = historyTest.Id };
            Question historyQuestion8 = new Question
            {
                Text = "Кто изображен на рисунке?",
                Points = 10,
                TestId = historyTest.Id,
                ImagePath = "/Images/Questions images/shevchenko.jpg"
            };
            Question historyQuestion9 = new Question
            {
                Text = "В какой стране находятся пирамиды, изображенные на рисунке?",
                Points = 10,
                TestId = historyTest.Id,
                ImagePath = "/Images/Questions images/Egypt.jpg"
            };
            Question historyQuestion10 = new Question
            {
                Text = "Кто изображен на рисунке?",
                Points = 10,
                TestId = historyTest.Id,
                ImagePath = "/Images/Questions images/leonardo.jpg"
            };

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
            AddQuestion(musicQuestion3);
            AddQuestion(musicQuestion4);
            AddQuestion(musicQuestion5);
            AddQuestion(musicQuestion6);
            AddQuestion(musicQuestion7);
            AddQuestion(musicQuestion8);
            AddQuestion(musicQuestion9);
            AddQuestion(musicQuestion10);

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
            AddQuestion(animalsQuestion2);
            AddQuestion(animalsQuestion3);
            AddQuestion(animalsQuestion4);
            AddQuestion(animalsQuestion5);
            AddQuestion(animalsQuestion6);
            AddQuestion(animalsQuestion7);
            AddQuestion(animalsQuestion8);
            AddQuestion(animalsQuestion9);
            AddQuestion(animalsQuestion10);

            AddQuestion(historyQuestion1);
            AddQuestion(historyQuestion2);
            AddQuestion(historyQuestion3);
            AddQuestion(historyQuestion4);
            AddQuestion(historyQuestion5);
            AddQuestion(historyQuestion6);
            AddQuestion(historyQuestion7);
            AddQuestion(historyQuestion8);
            AddQuestion(historyQuestion9);
            AddQuestion(historyQuestion10);

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

            Answer musicAnswer3_1 = new Answer { Text = "Евровидение", IsCorrect = true, QuestionId = musicQuestion3.Id };
            Answer musicAnswer3_2 = new Answer { Text = "Грэмми", IsCorrect = false, QuestionId = musicQuestion3.Id };
            Answer musicAnswer3_3 = new Answer { Text = "MTV Video Music Awards", IsCorrect = false, QuestionId = musicQuestion3.Id };
            Answer musicAnswer3_4 = new Answer { Text = "Billboard Music Awards", IsCorrect = false, QuestionId = musicQuestion3.Id };

            Answer musicAnswer4_1 = new Answer { Text = "Джамала", IsCorrect = true, QuestionId = musicQuestion4.Id };
            Answer musicAnswer4_2 = new Answer { Text = "Макс Барских", IsCorrect = false, QuestionId = musicQuestion4.Id };
            Answer musicAnswer4_3 = new Answer { Text = "Оля Поляковаs", IsCorrect = false, QuestionId = musicQuestion4.Id };
            Answer musicAnswer4_4 = new Answer { Text = "Тина Кароль", IsCorrect = false, QuestionId = musicQuestion4.Id };
            Answer musicAnswer4_5 = new Answer { Text = "Верка Сердючка", IsCorrect = false, QuestionId = musicQuestion4.Id };

            Answer musicAnswer5_1 = new Answer { Text = "ONUKA", IsCorrect = false, QuestionId = musicQuestion5.Id };
            Answer musicAnswer5_2 = new Answer { Text = "MONATIK", IsCorrect = false, QuestionId = musicQuestion5.Id };
            Answer musicAnswer5_3 = new Answer { Text = "KAZKA", IsCorrect = true, QuestionId = musicQuestion5.Id };
            Answer musicAnswer5_4 = new Answer { Text = "Тина Кароль", IsCorrect = false, QuestionId = musicQuestion5.Id };
            Answer musicAnswer5_5 = new Answer { Text = "Оля Полякова", IsCorrect = false, QuestionId = musicQuestion5.Id };

            Answer musicAnswer6_1 = new Answer { Text = "Kalush Orchestra", IsCorrect = true, QuestionId = musicQuestion6.Id };
            Answer musicAnswer6_2 = new Answer { Text = "Руслана", IsCorrect = true, QuestionId = musicQuestion6.Id };
            Answer musicAnswer6_3 = new Answer { Text = "KAZKA", IsCorrect = false, QuestionId = musicQuestion6.Id };
            Answer musicAnswer6_4 = new Answer { Text = "Джамала", IsCorrect = true, QuestionId = musicQuestion6.Id };
            Answer musicAnswer6_5 = new Answer { Text = "Верка Сердючка", IsCorrect = false, QuestionId = musicQuestion6.Id };

            Answer musicAnswer7_1 = new Answer { Text = "Скрипка", IsCorrect = false, QuestionId = musicQuestion7.Id };
            Answer musicAnswer7_2 = new Answer { Text = "Контрабас", IsCorrect = false, QuestionId = musicQuestion7.Id };
            Answer musicAnswer7_3 = new Answer { Text = "Гитара", IsCorrect = true, QuestionId = musicQuestion7.Id };
            Answer musicAnswer7_4 = new Answer { Text = "Домра", IsCorrect = false, QuestionId = musicQuestion7.Id };
            Answer musicAnswer7_5 = new Answer { Text = "Арфа", IsCorrect = false, QuestionId = musicQuestion7.Id };

            Answer musicAnswer8_1 = new Answer { Text = "Кларнет", IsCorrect = false, QuestionId = musicQuestion8.Id };
            Answer musicAnswer8_2 = new Answer { Text = "Тромбон", IsCorrect = false, QuestionId = musicQuestion8.Id };
            Answer musicAnswer8_3 = new Answer { Text = "Саксофон", IsCorrect = true, QuestionId = musicQuestion8.Id };
            Answer musicAnswer8_4 = new Answer { Text = "Валторна", IsCorrect = false, QuestionId = musicQuestion8.Id };
            Answer musicAnswer8_5 = new Answer { Text = "Труба", IsCorrect = false, QuestionId = musicQuestion8.Id };

            Answer musicAnswer9_1 = new Answer { Text = "Queen", IsCorrect = false, QuestionId = musicQuestion9.Id };
            Answer musicAnswer9_2 = new Answer { Text = "The Beatles", IsCorrect = true, QuestionId = musicQuestion9.Id };
            Answer musicAnswer9_3 = new Answer { Text = "Led Zeppelin", IsCorrect = false, QuestionId = musicQuestion9.Id };
            Answer musicAnswer9_4 = new Answer { Text = "The Rolling Stones", IsCorrect = false, QuestionId = musicQuestion9.Id };

            Answer musicAnswer10_1 = new Answer { Text = "Джамала", IsCorrect = false, QuestionId = musicQuestion10.Id };
            Answer musicAnswer10_2 = new Answer { Text = "Руслана", IsCorrect = false, QuestionId = musicQuestion10.Id };
            Answer musicAnswer10_3 = new Answer { Text = "Ирина Билык", IsCorrect = false, QuestionId = musicQuestion10.Id };
            Answer musicAnswer10_4 = new Answer { Text = "Тина Кароль", IsCorrect = false, QuestionId = musicQuestion10.Id };
            Answer musicAnswer10_5 = new Answer { Text = "Оля Полякова", IsCorrect = true, QuestionId = musicQuestion10.Id };

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
            Answer sportsAnswer15_3 = new Answer { Text = "Акробатические прыжки", IsCorrect = false, QuestionId = sportsQuestion15.Id };
            Answer sportsAnswer15_4 = new Answer { Text = "Прыжки на батуте", IsCorrect = true, QuestionId = sportsQuestion15.Id };
            Answer sportsAnswer15_5 = new Answer { Text = "Спортивная гимнастика", IsCorrect = true, QuestionId = sportsQuestion15.Id };

            // Варианты ответов на вопросы про животных
            Answer animalsAnswer1_1 = new Answer { Text = "Гепард", IsCorrect = true, QuestionId = animalsQuestion1.Id };
            Answer animalsAnswer1_2 = new Answer { Text = "Слон", IsCorrect = false, QuestionId = animalsQuestion1.Id };
            Answer animalsAnswer1_3 = new Answer { Text = "Лев", IsCorrect = true, QuestionId = animalsQuestion1.Id };
            Answer animalsAnswer1_4 = new Answer { Text = "Кенгуру", IsCorrect = false, QuestionId = animalsQuestion1.Id };
            Answer animalsAnswer1_5 = new Answer { Text = "Гиппопотам", IsCorrect = false, QuestionId = animalsQuestion1.Id };

            Answer animalsAnswer2_1 = new Answer { Text = "Жираф", IsCorrect = true, QuestionId = animalsQuestion2.Id };
            Answer animalsAnswer2_2 = new Answer { Text = "Волк", IsCorrect = false, QuestionId = animalsQuestion2.Id };
            Answer animalsAnswer2_3 = new Answer { Text = "Кенгуру", IsCorrect = true, QuestionId = animalsQuestion2.Id };
            Answer animalsAnswer2_4 = new Answer { Text = "Тигр", IsCorrect = false, QuestionId = animalsQuestion2.Id };
            Answer animalsAnswer2_5 = new Answer { Text = "Корова", IsCorrect = true, QuestionId = animalsQuestion2.Id };

            Answer animalsAnswer3_1 = new Answer { Text = "Пингвин", IsCorrect = false, QuestionId = animalsQuestion3.Id };
            Answer animalsAnswer3_2 = new Answer { Text = "Волк", IsCorrect = false, QuestionId = animalsQuestion3.Id };
            Answer animalsAnswer3_3 = new Answer { Text = "Капибара", IsCorrect = false, QuestionId = animalsQuestion3.Id };
            Answer animalsAnswer3_4 = new Answer { Text = "Лось", IsCorrect = false, QuestionId = animalsQuestion3.Id };
            Answer animalsAnswer3_5 = new Answer { Text = "Белый медведь", IsCorrect = true, QuestionId = animalsQuestion3.Id };

            Answer animalsAnswer4_1 = new Answer { Text = "Павлин", IsCorrect = false, QuestionId = animalsQuestion4.Id };
            Answer animalsAnswer4_2 = new Answer { Text = "Птица-секретарь", IsCorrect = false, QuestionId = animalsQuestion4.Id };
            Answer animalsAnswer4_3 = new Answer { Text = "Гиена", IsCorrect = false, QuestionId = animalsQuestion4.Id };
            Answer animalsAnswer4_4 = new Answer { Text = "Леопард", IsCorrect = false, QuestionId = animalsQuestion4.Id };
            Answer animalsAnswer4_5 = new Answer { Text = "Хамелеон", IsCorrect = true, QuestionId = animalsQuestion4.Id };

            Answer animalsAnswer5_1 = new Answer { Text = "Попугай", IsCorrect = false, QuestionId = animalsQuestion5.Id };
            Answer animalsAnswer5_2 = new Answer { Text = "Голубь", IsCorrect = false, QuestionId = animalsQuestion5.Id };
            Answer animalsAnswer5_3 = new Answer { Text = "Сокол", IsCorrect = true, QuestionId = animalsQuestion5.Id };
            Answer animalsAnswer5_4 = new Answer { Text = "Канарейка", IsCorrect = false, QuestionId = animalsQuestion5.Id };

            Answer animalsAnswer6_1 = new Answer { Text = "Пчела", IsCorrect = true, QuestionId = animalsQuestion6.Id };
            Answer animalsAnswer6_2 = new Answer { Text = "Голубь", IsCorrect = false, QuestionId = animalsQuestion6.Id };
            Answer animalsAnswer6_3 = new Answer { Text = "Кобра", IsCorrect = true, QuestionId = animalsQuestion6.Id };
            Answer animalsAnswer6_4 = new Answer { Text = "Таракан", IsCorrect = false, QuestionId = animalsQuestion6.Id };
            Answer animalsAnswer6_5 = new Answer { Text = "Лемур", IsCorrect = false, QuestionId = animalsQuestion6.Id };
            Answer animalsAnswer6_6 = new Answer { Text = "Уж", IsCorrect = false, QuestionId = animalsQuestion6.Id };

            Answer animalsAnswer7_1 = new Answer { Text = "Осел", IsCorrect = false, QuestionId = animalsQuestion7.Id };
            Answer animalsAnswer7_2 = new Answer { Text = "Носорог", IsCorrect = false, QuestionId = animalsQuestion7.Id };
            Answer animalsAnswer7_3 = new Answer { Text = "Зебра", IsCorrect = true, QuestionId = animalsQuestion7.Id };
            Answer animalsAnswer7_4 = new Answer { Text = "Лошадь", IsCorrect = false, QuestionId = animalsQuestion7.Id };
            Answer animalsAnswer7_5 = new Answer { Text = "Олень", IsCorrect = false, QuestionId = animalsQuestion7.Id };

            Answer animalsAnswer8_1 = new Answer { Text = "Заяц", IsCorrect = false, QuestionId = animalsQuestion8.Id };
            Answer animalsAnswer8_2 = new Answer { Text = "Крыса", IsCorrect = false, QuestionId = animalsQuestion8.Id };
            Answer animalsAnswer8_3 = new Answer { Text = "Ёжик", IsCorrect = true, QuestionId = animalsQuestion8.Id };
            Answer animalsAnswer8_4 = new Answer { Text = "Крот", IsCorrect = false, QuestionId = animalsQuestion8.Id };
            Answer animalsAnswer8_5 = new Answer { Text = "Выдра", IsCorrect = false, QuestionId = animalsQuestion8.Id };

            Answer animalsAnswer9_1 = new Answer { Text = "Скат", IsCorrect = false, QuestionId = animalsQuestion9.Id };
            Answer animalsAnswer9_2 = new Answer { Text = "Медуза", IsCorrect = false, QuestionId = animalsQuestion9.Id };
            Answer animalsAnswer9_3 = new Answer { Text = "Акула", IsCorrect = true, QuestionId = animalsQuestion9.Id };
            Answer animalsAnswer9_4 = new Answer { Text = "Кит", IsCorrect = false, QuestionId = animalsQuestion9.Id };
            Answer animalsAnswer9_5 = new Answer { Text = "Морская черепаха", IsCorrect = false, QuestionId = animalsQuestion9.Id };

            Answer animalsAnswer10_1 = new Answer { Text = "Заяц", IsCorrect = false, QuestionId = animalsQuestion10.Id };
            Answer animalsAnswer10_2 = new Answer { Text = "Бобер", IsCorrect = false, QuestionId = animalsQuestion10.Id };
            Answer animalsAnswer10_3 = new Answer { Text = "Утконос", IsCorrect = true, QuestionId = animalsQuestion10.Id };
            Answer animalsAnswer10_4 = new Answer { Text = "Щука", IsCorrect = false, QuestionId = animalsQuestion10.Id };
            Answer animalsAnswer10_5 = new Answer { Text = "Черепаха", IsCorrect = false, QuestionId = animalsQuestion10.Id };

            // Варианты ответов на вопросы по истории
            Answer historyAnswer1_1 = new Answer { Text = "Джорш Буш", IsCorrect = false, QuestionId = historyQuestion1.Id };
            Answer historyAnswer1_2 = new Answer { Text = "Джордж Вашингтон", IsCorrect = true, QuestionId = historyQuestion1.Id };
            Answer historyAnswer1_3 = new Answer { Text = "Авраам Линкольн", IsCorrect = false, QuestionId = historyQuestion1.Id };
            Answer historyAnswer1_4 = new Answer { Text = "Джо Байден", IsCorrect = false, QuestionId = historyQuestion1.Id };
            Answer historyAnswer1_5 = new Answer { Text = "Джон Кеннеди", IsCorrect = false, QuestionId = historyQuestion1.Id };

            Answer historyAnswer2_1 = new Answer { Text = "7 декабря 1941 года", IsCorrect = false, QuestionId = historyQuestion2.Id };
            Answer historyAnswer2_2 = new Answer { Text = "1 сентября 1939 года", IsCorrect = true, QuestionId = historyQuestion2.Id };
            Answer historyAnswer2_3 = new Answer { Text = "22 июня 1941 года", IsCorrect = false, QuestionId = historyQuestion2.Id };
            Answer historyAnswer2_4 = new Answer { Text = "3 сентября 1937 года", IsCorrect = false, QuestionId = historyQuestion2.Id };
            Answer historyAnswer2_5 = new Answer { Text = "9 мая 1945 года", IsCorrect = false, QuestionId = historyQuestion2.Id };

            Answer historyAnswer3_1 = new Answer { Text = "1918 год", IsCorrect = false, QuestionId = historyQuestion3.Id };
            Answer historyAnswer3_2 = new Answer { Text = "1991 год", IsCorrect = true, QuestionId = historyQuestion3.Id };
            Answer historyAnswer3_3 = new Answer { Text = "1954 год", IsCorrect = false, QuestionId = historyQuestion3.Id };
            Answer historyAnswer3_4 = new Answer { Text = "2004 год", IsCorrect = false, QuestionId = historyQuestion3.Id };
            Answer historyAnswer3_5 = new Answer { Text = "1645 год", IsCorrect = false, QuestionId = historyQuestion3.Id };

            Answer historyAnswer4_1 = new Answer { Text = "1789 год", IsCorrect = true, QuestionId = historyQuestion4.Id };
            Answer historyAnswer4_2 = new Answer { Text = "1812 год", IsCorrect = false, QuestionId = historyQuestion4.Id };
            Answer historyAnswer4_3 = new Answer { Text = "1917 год", IsCorrect = false, QuestionId = historyQuestion4.Id };
            Answer historyAnswer4_4 = new Answer { Text = "2004 год", IsCorrect = false, QuestionId = historyQuestion4.Id };
            Answer historyAnswer4_5 = new Answer { Text = "1629 год", IsCorrect = false, QuestionId = historyQuestion4.Id };

            Answer historyAnswer5_1 = new Answer { Text = "Франция", IsCorrect = true, QuestionId = historyQuestion5.Id };
            Answer historyAnswer5_2 = new Answer { Text = "Дания", IsCorrect = false, QuestionId = historyQuestion5.Id };
            Answer historyAnswer5_3 = new Answer { Text = "Великобритания", IsCorrect = true, QuestionId = historyQuestion5.Id };
            Answer historyAnswer5_4 = new Answer { Text = "Голландия", IsCorrect = false, QuestionId = historyQuestion5.Id };
            Answer historyAnswer5_5 = new Answer { Text = "Швеция", IsCorrect = false, QuestionId = historyQuestion5.Id };

            Answer historyAnswer6_1 = new Answer { Text = "Франция", IsCorrect = true, QuestionId = historyQuestion6.Id };
            Answer historyAnswer6_2 = new Answer { Text = "США", IsCorrect = true, QuestionId = historyQuestion6.Id };
            Answer historyAnswer6_3 = new Answer { Text = "Великобритания", IsCorrect = true, QuestionId = historyQuestion6.Id };
            Answer historyAnswer6_4 = new Answer { Text = "Бразилия", IsCorrect = false, QuestionId = historyQuestion6.Id };
            Answer historyAnswer6_5 = new Answer { Text = "Япония", IsCorrect = false, QuestionId = historyQuestion6.Id };

            Answer historyAnswer7_1 = new Answer { Text = "Франция", IsCorrect = true, QuestionId = historyQuestion7.Id };
            Answer historyAnswer7_2 = new Answer { Text = "США", IsCorrect = false, QuestionId = historyQuestion7.Id };
            Answer historyAnswer7_3 = new Answer { Text = "Англия", IsCorrect = true, QuestionId = historyQuestion7.Id };
            Answer historyAnswer7_4 = new Answer { Text = "Испания", IsCorrect = false, QuestionId = historyQuestion7.Id };
            Answer historyAnswer7_5 = new Answer { Text = "Голандия", IsCorrect = false, QuestionId = historyQuestion7.Id };
            Answer historyAnswer7_6 = new Answer { Text = "Япония", IsCorrect = false, QuestionId = historyQuestion7.Id };

            Answer historyAnswer8_1 = new Answer { Text = "Франсуа де ля Фон", IsCorrect = false, QuestionId = historyQuestion8.Id };
            Answer historyAnswer8_2 = new Answer { Text = "Тарас Шевченко", IsCorrect = true, QuestionId = historyQuestion8.Id };
            Answer historyAnswer8_3 = new Answer { Text = "Фридрих Ницше", IsCorrect = false, QuestionId = historyQuestion8.Id };
            Answer historyAnswer8_4 = new Answer { Text = "Андрей Шевченко", IsCorrect = false, QuestionId = historyQuestion8.Id };
            Answer historyAnswer8_5 = new Answer { Text = "Гюстав Эйфель", IsCorrect = false, QuestionId = historyQuestion8.Id };

            Answer historyAnswer9_1 = new Answer { Text = "Франция", IsCorrect = false, QuestionId = historyQuestion9.Id };
            Answer historyAnswer9_2 = new Answer { Text = "Египет", IsCorrect = true, QuestionId = historyQuestion9.Id };
            Answer historyAnswer9_3 = new Answer { Text = "Израиль", IsCorrect = false, QuestionId = historyQuestion9.Id };
            Answer historyAnswer9_4 = new Answer { Text = "Турция", IsCorrect = false, QuestionId = historyQuestion9.Id };
            Answer historyAnswer9_5 = new Answer { Text = "Кипр", IsCorrect = false, QuestionId = historyQuestion9.Id };

            Answer historyAnswer10_1 = new Answer { Text = "Карл Маркс", IsCorrect = false, QuestionId = historyQuestion10.Id };
            Answer historyAnswer10_2 = new Answer { Text = "Леонардо да Винчи", IsCorrect = true, QuestionId = historyQuestion10.Id };
            Answer historyAnswer10_3 = new Answer { Text = "Лев Толстой", IsCorrect = false, QuestionId = historyQuestion10.Id };
            Answer historyAnswer10_4 = new Answer { Text = "Леонардо ди Каприо", IsCorrect = false, QuestionId = historyQuestion10.Id };
            Answer historyAnswer10_5 = new Answer { Text = "Фидель Кастро", IsCorrect = false, QuestionId = historyQuestion10.Id };

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

            AddAnswer(musicAnswer3_1);
            AddAnswer(musicAnswer3_2);
            AddAnswer(musicAnswer3_3);
            AddAnswer(musicAnswer3_4);

            AddAnswer(musicAnswer4_1);
            AddAnswer(musicAnswer4_2);
            AddAnswer(musicAnswer4_3);
            AddAnswer(musicAnswer4_4);
            AddAnswer(musicAnswer4_5);

            AddAnswer(musicAnswer5_1);
            AddAnswer(musicAnswer5_2);
            AddAnswer(musicAnswer5_3);
            AddAnswer(musicAnswer5_4);
            AddAnswer(musicAnswer5_5);

            AddAnswer(musicAnswer6_1);
            AddAnswer(musicAnswer6_2);
            AddAnswer(musicAnswer6_3);
            AddAnswer(musicAnswer6_4);
            AddAnswer(musicAnswer6_5);

            AddAnswer(musicAnswer7_1);
            AddAnswer(musicAnswer7_2);
            AddAnswer(musicAnswer7_3);
            AddAnswer(musicAnswer7_4);
            AddAnswer(musicAnswer7_5);

            AddAnswer(musicAnswer8_1);
            AddAnswer(musicAnswer8_2);
            AddAnswer(musicAnswer8_3);
            AddAnswer(musicAnswer8_4);
            AddAnswer(musicAnswer8_5);

            AddAnswer(musicAnswer9_1);
            AddAnswer(musicAnswer9_2);
            AddAnswer(musicAnswer9_3);
            AddAnswer(musicAnswer9_4);

            AddAnswer(musicAnswer10_1);
            AddAnswer(musicAnswer10_2);
            AddAnswer(musicAnswer10_3);
            AddAnswer(musicAnswer10_4);
            AddAnswer(musicAnswer10_5);

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

            AddAnswer(animalsAnswer2_1);
            AddAnswer(animalsAnswer2_2);
            AddAnswer(animalsAnswer2_3);
            AddAnswer(animalsAnswer2_4);
            AddAnswer(animalsAnswer2_5);

            AddAnswer(animalsAnswer3_1);
            AddAnswer(animalsAnswer3_2);
            AddAnswer(animalsAnswer3_3);
            AddAnswer(animalsAnswer3_4);
            AddAnswer(animalsAnswer3_5);

            AddAnswer(animalsAnswer4_1);
            AddAnswer(animalsAnswer4_2);
            AddAnswer(animalsAnswer4_3);
            AddAnswer(animalsAnswer4_4);
            AddAnswer(animalsAnswer4_5);

            AddAnswer(animalsAnswer5_1);
            AddAnswer(animalsAnswer5_2);
            AddAnswer(animalsAnswer5_3);
            AddAnswer(animalsAnswer5_4);

            AddAnswer(animalsAnswer6_1);
            AddAnswer(animalsAnswer6_2);
            AddAnswer(animalsAnswer6_3);
            AddAnswer(animalsAnswer6_4);
            AddAnswer(animalsAnswer6_5);
            AddAnswer(animalsAnswer6_6);

            AddAnswer(animalsAnswer7_1);
            AddAnswer(animalsAnswer7_2);
            AddAnswer(animalsAnswer7_3);
            AddAnswer(animalsAnswer7_4);
            AddAnswer(animalsAnswer7_5);

            AddAnswer(animalsAnswer8_1);
            AddAnswer(animalsAnswer8_2);
            AddAnswer(animalsAnswer8_3);
            AddAnswer(animalsAnswer8_4);
            AddAnswer(animalsAnswer8_5);

            AddAnswer(animalsAnswer9_1);
            AddAnswer(animalsAnswer9_2);
            AddAnswer(animalsAnswer9_3);
            AddAnswer(animalsAnswer9_4);
            AddAnswer(animalsAnswer9_5);

            AddAnswer(animalsAnswer10_1);
            AddAnswer(animalsAnswer10_2);
            AddAnswer(animalsAnswer10_3);
            AddAnswer(animalsAnswer10_4);
            AddAnswer(animalsAnswer10_5);

            // Добавляем ответы в базу данных
            AddAnswer(historyAnswer1_1);
            AddAnswer(historyAnswer1_2);
            AddAnswer(historyAnswer1_3);
            AddAnswer(historyAnswer1_4);
            AddAnswer(historyAnswer1_5);

            AddAnswer(historyAnswer2_1);
            AddAnswer(historyAnswer2_2);
            AddAnswer(historyAnswer2_3);
            AddAnswer(historyAnswer2_4);
            AddAnswer(historyAnswer2_5);

            AddAnswer(historyAnswer3_1);
            AddAnswer(historyAnswer3_2);
            AddAnswer(historyAnswer3_3);
            AddAnswer(historyAnswer3_4);
            AddAnswer(historyAnswer3_5);

            AddAnswer(historyAnswer4_1);
            AddAnswer(historyAnswer4_2);
            AddAnswer(historyAnswer4_3);
            AddAnswer(historyAnswer4_4);
            AddAnswer(historyAnswer4_5);

            AddAnswer(historyAnswer5_1);
            AddAnswer(historyAnswer5_2);
            AddAnswer(historyAnswer5_3);
            AddAnswer(historyAnswer5_4);
            AddAnswer(historyAnswer5_5);

            AddAnswer(historyAnswer6_1);
            AddAnswer(historyAnswer6_2);
            AddAnswer(historyAnswer6_3);
            AddAnswer(historyAnswer6_4);
            AddAnswer(historyAnswer6_5);

            AddAnswer(historyAnswer7_1);
            AddAnswer(historyAnswer7_2);
            AddAnswer(historyAnswer7_3);
            AddAnswer(historyAnswer7_4);
            AddAnswer(historyAnswer7_5);
            AddAnswer(historyAnswer7_6);

            AddAnswer(historyAnswer8_1);
            AddAnswer(historyAnswer8_2);
            AddAnswer(historyAnswer8_3);
            AddAnswer(historyAnswer8_4);
            AddAnswer(historyAnswer8_5);

            AddAnswer(historyAnswer9_1);
            AddAnswer(historyAnswer9_2);
            AddAnswer(historyAnswer9_3);
            AddAnswer(historyAnswer9_4);
            AddAnswer(historyAnswer9_5);

            AddAnswer(historyAnswer10_1);
            AddAnswer(historyAnswer10_2);
            AddAnswer(historyAnswer10_3);
            AddAnswer(historyAnswer10_4);
            AddAnswer(historyAnswer10_5);
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

