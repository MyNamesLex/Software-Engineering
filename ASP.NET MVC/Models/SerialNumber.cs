using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Core_MVC.Models
{
    public class SerialNumber
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item? Item { get; set; }

    }
}
