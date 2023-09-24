namespace StackOverflowLLD
{
    public class Comment : Post
    {
        public Comment(int id, Member member, Post parentPost, string body) : base(id, member, PostType.Comment, body)
        {
            this.ParentPost = parentPost;
        }

        public Post ParentPost { get; set; }
    }
}