namespace Nerdify.Model
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string BookNumber { get; set; }
        public string BookLink { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
