using System.ComponentModel.DataAnnotations.Schema;

namespace product_update_service
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}