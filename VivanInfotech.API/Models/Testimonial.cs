namespace VivanInfotech.API.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = "";
        public string Company { get; set; } = "";
        public string Content { get; set; } = "";
        public bool IsFeatured { get; set; }
    }
}
