namespace StackOverflowLLD
{
    public class Forum
    {
        public Forum()
        {
            this.Users = new List<Member>();
            this.Moderators = new List<Member>();
            this.Questions = new List<Question>();
        }

        public List<Member> Users { get; private set; }
        public List<Member> Moderators { get; private set; }
        public List<Question> Questions { get; private set; }

        public void RegisterMember(Member member)
        {
            if (member.MemberType == MemberType.User)
                this.Users.Add(member);
            else
                this.Moderators.Add(member);
        }

        public void PostQuestion(Question question)
        {
            if (!this.Users.Contains(question.Author))
            {
                Console.WriteLine("Non Registered Member can not post");
                return;
            }

            this.Questions.Add(question);
        }

        public void AddAnswer(Answer answer)
        {
            if (!this.Users.Contains(answer.Author))
            {
                Console.WriteLine("Non Registered Member can not post");
                return;
            }

            answer.Question.AddAnswer(answer);
            ((User)answer.Author).AddPoints(10);

            int acceptedAnswersCount = 0;

            foreach (Question q in this.Questions)
                acceptedAnswersCount += q.Answers.Where(a => answer.IsAcceptedAnswer && answer.Author == a.Author).Count();

            ((User)answer.Author).AddBadge(acceptedAnswersCount);
        }

        public void AddComment(Comment comment)
        {
            if (!this.Users.Contains(comment.Author))
            {
                Console.WriteLine("Non Registered Member can not post");
                return;
            }

            if (comment.ParentPost.PostType == PostType.Question)
            {
                ((Question)comment.ParentPost).AddComment(comment);
            }
            else if (comment.ParentPost.PostType == PostType.Answer)
            {
                ((Answer)comment.ParentPost).AddComment(comment);
            }
        }

        public void AddBounty(Question question, Member member, int bounty)
        {
            if (!this.Users.Contains(question.Author))
            {
                Console.WriteLine("Non Registered Member can not post");
                return;
            }

            if (question.Author != member)
            {
                Console.WriteLine("Only Author of the question can put bounty");
                return;
            }

            if (question.Author.Points > bounty)
            {
                question.AddBounty(bounty);
                ((User)question.Author).AddPoints(-1 * bounty);
            }
        }

        public void AcceptAnswer(Question question, Member member, Answer answer)
        {
            if (!this.Users.Contains(member))
            {
                Console.WriteLine("Non Registered Member can not mark answer as accepted");
                return;
            }

            if (question.Author != member)
            {
                Console.WriteLine("Only Author of the question can mark the Question as answered");
                return;
            }

            Answer? ans = question.Answers.Where(x => x == answer).FirstOrDefault();

            if (ans != null)
            {
                ans.MarkAnswerAccepted();
                answer.Author.Points += question.Bounty;
                question.Close();
            }
        }

        public void Vote(Post post, Member member, VoteType voteType)
        {
            if (!this.Users.Contains(member))
            {
                Console.WriteLine("Non Registered Member can not up/down vote");
                return;
            }

            if (voteType == VoteType.UpVote)
                post.UpVotes++;
            if (voteType == VoteType.DownVote)
                post.DownVotes++;
        }
    }
}