namespace StackOverflowLLD
{
    public class Answer : Post, ICommentable, IVotable
    {
        public Answer(int id, Member member, Question question, string body) : base(id, member, PostType.Answer, body)
        {
            this.Question = question;
            IsAcceptedAnswer = false;
            Comments = new List<Comment>();
        }

        public Question Question { get; private set; }
        public bool IsAcceptedAnswer { get; private set; }
        public List<Comment> Comments { get; private set; }

        public void AddComment(Comment comment) => this.Comments.Add(comment);
        public void MarkAnswerAccepted() => this.IsAcceptedAnswer = true;

        public void AddVote(VoteType voteType)
        {
            if (voteType == VoteType.UpVote)
                this.UpVotes++;
            else if (voteType == VoteType.DownVote)
                this.DownVotes++;
        }
    }
}