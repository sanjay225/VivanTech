namespace VivanInfotech.API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Category { get; set; } = "";
        public string Challenge { get; set; } = "";
        public bool IsFeatured { get; set; }
        public string ProjectImageUrl { get; set; } = "";
    }
}
