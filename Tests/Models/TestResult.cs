namespace Tests.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? TestId { get; set; }
        public int Score { get; set; }

        public virtual User User { get; set; }
        public virtual Test Test { get; set; }
    }
}