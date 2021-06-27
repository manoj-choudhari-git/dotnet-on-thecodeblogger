namespace Blog.Api.Models
{
    public class TagModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}
