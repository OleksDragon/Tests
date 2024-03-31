using System.Collections.Generic;

namespace Tests.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public int Points { get; set; }
        public int TestId { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Test Test { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
