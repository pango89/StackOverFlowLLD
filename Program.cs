namespace StackOverflowLLD
{
    class Program
    {
        static void Main(string[] args)
        {
            Forum forum = ForumFactory.Create();

            Member u1 = MemberFactory.Create(MemberType.User, "u1@gmail.com");
            forum.RegisterMember(u1);

            Member u2 = MemberFactory.Create(MemberType.User, "u2@gmail.com");
            forum.RegisterMember(u2);

            Member u3 = MemberFactory.Create(MemberType.User, "u3@gmail.com");
            forum.RegisterMember(u3);

            Member u4 = MemberFactory.Create(MemberType.User, "u4@gmail.com");
            forum.RegisterMember(u4);

            Question q1 = PostFactory.CreateQuestion(u1, "Question - 1", "Who is the PM of India");
            forum.PostQuestion(q1);
            forum.AddBounty(q1, u1, 200);

            forum.Vote(q1, u2, VoteType.UpVote);

            forum.AddComment(PostFactory.CreateComment(u4, q1, "Are you asking about Prime Minister?"));
            // forum.AddComment(PostFactory.CreateComment(u3, q1, "Yes He is talking about Prime Minister of India."));

            // forum.AddAnswer(PostFactory.CreateAnswer(u3, q1, "The PM of India is Manmohan Singh"));
            forum.AddAnswer(PostFactory.CreateAnswer(u4, q1, "The PM of India is Indira Gandhi"));

            Answer a1 = PostFactory.CreateAnswer(u2, q1, "The PM of India is Narendra Modi");
            forum.AddAnswer(a1);
            forum.Vote(a1, u4, VoteType.UpVote);

            forum.AddComment(PostFactory.CreateComment(u3, a1, "Looks Like right answer to me!"));

            forum.AcceptAnswer(q1, u1, a1);

            Console.ReadLine();

            // TODO: Add Tags, Search Question By Tags
        }
    }
}