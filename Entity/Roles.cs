namespace WebAppMVC.Entity
{
    public class Roles
    {
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;
        public List<Users> Users { get; set; } = new(); // Navigation property
    }
}