namespace AppFor66Bit.Models
{
    public class News
    {
        public string Title {  get; set; }
        public string Content { get; set; }
        public int Id { get; set; }
        public bool IsHidden { get; set; }
        public bool IsFeatured { get; set; }
    }
}
