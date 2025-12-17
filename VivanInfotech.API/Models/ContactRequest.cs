namespace VivanInfotech.API.Models
{
    public class ContactRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Message { get; set; } = "";
        public string Status { get; set; } = "New";
    }
}

