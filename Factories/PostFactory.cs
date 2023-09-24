
namespace StackOverflowLLD
{
    public class PostFactory
    {
        private static int Counter = 1;
        public static Question CreateQuestion(Member member, string title, string body)
        {
            return new Question(Counter++, member, title, body);
        }

        public static Answer CreateAnswer(Member member, Question question, string body)
        {
            return new Answer(Counter++, member, question, body);
        }

        public static Comment CreateComment(Member member, Post parent, string body)
        {
            return new Comment(Counter++, member, parent, body);
        }
    }
}