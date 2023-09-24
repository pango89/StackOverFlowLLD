namespace StackOverflowLLD
{
    public class MemberFactory
    {
        private static int Counter = 1;
        public static Member Create(MemberType memberType, string email)
        {
            if (memberType == MemberType.User)
                return new User(Counter++, email);
            else
                return new Moderator(Counter++, email);
        }
    }
}