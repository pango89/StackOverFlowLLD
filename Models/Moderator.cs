namespace StackOverflowLLD
{
    public class Moderator : Member
    {
        public Moderator(int id, string email) : base(id, email, MemberType.Moderator, 10000)
        {
        }

        public static void CloseQuestion(Question question) => question.Close();
    }
}