using System.ComponentModel.DataAnnotations.Schema;

namespace product_update_service.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public ICollection<Wine> Wines { get; set; } = new List<Wine>();
    }
}