namespace Blog.Data.EF.Entities
{
    public class Comment : BaseEntity
    {
        public string CommentContents { get; set; }
        
        public string PostedBy { get; set; }

        public Comment Parent { get; set; }

        public Post ParentPost { get; set; }
    }
}
