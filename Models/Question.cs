namespace StackOverflowLLD
{
    public class Question : Post, IAnswerable, ITaggable, ICommentable, IVotable, IClosable
    {
        public Question(int id, Member member, string title, string body) : base(id, member, PostType.Question, body)
        {
            Tags = new List<string>();
            Bounty = 0;
            Answers = new List<Answer>();
            Comments = new List<Comment>();
            IsClosed = false;
            Title = title;
        }

        public string Title { get; private set; }

        public List<string> Tags { get; private set; }
        public int Bounty { get; private set; }
        public List<Answer> Answers { get; private set; }
        public List<Comment> Comments { get; private set; }
        public bool IsClosed { get; private set; }

        public void AddAnswer(Answer answer) => this.Answers.Add(answer);

        public void AddComment(Comment comment) => this.Comments.Add(comment);

        public void AddTag(string tag) => this.Tags.Add(tag);
        public void AddBounty(int bounty) => this.Bounty += bounty;

        public void AddVote(VoteType voteType)
        {
            if (voteType == VoteType.UpVote)
                this.UpVotes++;
            else if (voteType == VoteType.DownVote)
                this.DownVotes++;
        }

        public void Close() => this.IsClosed = true;
    }
}