namespace StackOverflowLLD
{
    public abstract class Member
    {
        public Member(int id, string email, MemberType memberType, int points)
        {
            Id = id;
            Email = email;
            MemberType = memberType;
            Points = points;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public int Points { get; set; }
        public MemberType MemberType { get; set; }
    }
}