namespace StackOverflowLLD
{
    public abstract class Post
    {
        protected Post(int id, Member member, PostType postType, string body)
        {
            Id = id;
            Author = member;
            CreatedAt = DateTime.Now;
            UpVotes = 0;
            DownVotes = 0;
            IsFlagged = false;
            PostType = postType;
            Body = body;
        }

        public int Id { get; set; }
        public Member Author { get; set; } // Owner
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public bool IsFlagged { get; set; }
        public PostType PostType { get; set; }
    }
}