namespace ASP.NET_Core_MVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Item>? Items { get; set; }
    }
}
