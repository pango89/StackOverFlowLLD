namespace StackOverflowLLD
{
    public class User : Member
    {
        public User(int id, string email) : base(id, email, MemberType.User, 1000)
        {
            Badges = new List<Badge>();
        }

        public List<Badge> Badges { get; set; }

        public void AddPoints(int points) => this.Points += points;

        public void AddBadge(int acceptedAnswersCount)
        {
            if (acceptedAnswersCount >= 10 && !this.Badges.Contains(Badge.Blue))
                this.Badges.Add(Badge.Blue);
            else if (acceptedAnswersCount >= 20 && !this.Badges.Contains(Badge.Bronze))
                this.Badges.Add(Badge.Bronze);
            else if (acceptedAnswersCount >= 30 && !this.Badges.Contains(Badge.Silver))
                this.Badges.Add(Badge.Silver);
            else if (acceptedAnswersCount >= 40 && !this.Badges.Contains(Badge.Gold))
                this.Badges.Add(Badge.Gold);
            else if (acceptedAnswersCount >= 50 && !this.Badges.Contains(Badge.Black))
                this.Badges.Add(Badge.Black);
        }
    }
}