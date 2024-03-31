using System.Collections.Generic;

namespace Tests.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }

        public Test()
        {
            Questions = new List<Question>();
            TestResults = new List<TestResult>();
        }
    }
}